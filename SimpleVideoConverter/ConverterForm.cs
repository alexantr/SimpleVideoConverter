using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Alexantr.SimpleVideoConverter
{
    public partial class ConverterForm : Form
    {
        private readonly string inputFile;
        private readonly string outputFile;
        private readonly string[] arguments;
        private readonly double duration;

        private FFmpegProcess ffmpegProcess;

        private Timer timer;
        private bool processEnded;
        private bool processPanic;

        private int currentPass;
        private bool isTwoPass;
        private bool cancelTwoPass;

        private TaskbarManager taskbarManager;

        private string formTitle;

        /// <summary>
        /// Converter Form. Based on code from nixx's WebMConverter.
        /// </summary>
        /// <param name="inFile">Path to input file</param>
        /// <param name="outFile">Path to output file</param>
        /// <param name="args">ffmpeg arguments without input and output files</param>
        /// <param name="inDuration">Video duration for progress</param>
        public ConverterForm(string inFile, string outFile, string[] args, double inDuration)
        {
            InitializeComponent();

            inputFile = inFile;
            outputFile = outFile;
            arguments = args;
            duration = inDuration;

            taskbarManager = TaskbarManager.Instance;
        }

        private void ConverterForm_Load(object sender, EventArgs e)
        {
            formTitle = Text;

            taskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);

            isTwoPass = !(arguments.Length == 1);

            for (var i = 0; i < arguments.Length; i++)
            {
                arguments[i] = string.Format("-i \"{0}\" {2} {1}", inputFile, (isTwoPass && i == 0 ? "NUL" : $"\"{outputFile}\""), arguments[i]);
            }

            if (isTwoPass)
            {
                richTextBoxOutput.AppendText($"Arguments for pass 1: {arguments[0]}{Environment.NewLine}");
                richTextBoxOutput.AppendText($"Arguments for pass 2: {arguments[1]}{Environment.NewLine}");
            }
            else
            {
                richTextBoxOutput.AppendText($"Arguments: {arguments[0]}{Environment.NewLine}");
            }

            richTextBoxOutput.ReadOnly = true;
            textBoxCurrentOutput.ReadOnly = true;

            progressBarEncoding.Value = 0;
            buttonPlay.Enabled = false;

            if (isTwoPass)
                MultiPass(arguments);
            else
                SinglePass(arguments[0]);
        }

        private void ConverterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            processPanic = true; //Shut down while avoiding exceptions
            buttonCancel_Click(sender, e);
            taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
        }

        private void ConverterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ffmpegProcess.Dispose();
        }

        private void SinglePass(string argument)
        {
            ffmpegProcess = new FFmpegProcess(argument);

            ffmpegProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            ffmpegProcess.OutputDataReceived += ProcessOnOutputDataReceived;
            ffmpegProcess.Exited += (o, args) => richTextBoxOutput.Invoke((Action)(() =>
            {
                if (processPanic) return; //This should stop that one exception when closing the converter

                buttonCancel.Enabled = false;

                timer = new Timer();
                timer.Interval = 500;
                timer.Tick += Exited;
                timer.Start();
            }));

            progressBarEncoding.Value = 0;
            taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
            labelStatus.Text = "Выполняется конвертирование";

            ffmpegProcess.Start();
        }

        private void MultiPass(string[] arguments)
        {
            int passes = arguments.Length;

            ffmpegProcess = new FFmpegProcess(arguments[currentPass]);

            ffmpegProcess.ErrorDataReceived += ProcessOnErrorDataReceived;
            ffmpegProcess.OutputDataReceived += ProcessOnOutputDataReceived;
            ffmpegProcess.Exited += (o, args) => richTextBoxOutput.Invoke((Action)(() =>
            {
                if (processPanic) return; //This should stop that one exception when closing the converter

                currentPass++;
                if (currentPass < passes && !cancelTwoPass)
                {
                    richTextBoxOutput.AppendText(Environment.NewLine);

                    MultiPass(arguments);
                    return;
                }

                buttonCancel.Enabled = false;

                timer = new Timer();
                timer.Interval = 500;
                timer.Tick += Exited;
                timer.Start();
            }));

            progressBarEncoding.Value = 0;
            taskbarManager.SetProgressState(TaskbarProgressBarState.Normal);
            labelStatus.Text = $"Выполняется конвертирование (проход {currentPass + 1})";

            ffmpegProcess.Start();
        }

        private void Exited(object sender, EventArgs eventArgs)
        {
            timer.Stop();

            var process = ffmpegProcess;

            if (process.ExitCode != 0)
            {
                if (cancelTwoPass)
                {
                    //richTextBoxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}Converting cancelled.");
                    textBoxCurrentOutput.Text = "Converting cancelled.";

                    taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                    labelStatus.Text = "Конвертирование отменено";
                }
                else
                {
                    //richTextBoxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}ffmpeg.exe exited with exit code {process.ExitCode}.");
                    textBoxCurrentOutput.Text = $"ffmpeg.exe exited with exit code {process.ExitCode}.";

                    taskbarManager.SetProgressValue(1000, 1000);
                    taskbarManager.SetProgressState(TaskbarProgressBarState.Error);
                    labelStatus.Text = "Ошибка конвертирования";
                }
                progressBarEncoding.Value = 0;
                Text = formTitle;
            }
            else
            {
                //richTextBoxOutput.AppendText($"{Environment.NewLine}{Environment.NewLine}Video converted succesfully.");
                textBoxCurrentOutput.Text = "Video converted succesfully.";
                progressBarEncoding.Value = 1000;
                Text = $"{formTitle} - 100%";
                taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                labelStatus.Text = "Конвертирование выполнено";
                buttonPlay.Enabled = true;
            }
            buttonCancel.Text = "Закрыть";
            buttonCancel.Enabled = true;
            buttonCancel.Focus();
            processEnded = true;
        }

        private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                if (args.Data.StartsWith("frame="))
                {
                    textBoxCurrentOutput.Invoke((Action)(() => textBoxCurrentOutput.Text = args.Data.TrimEnd()));
                }
                else
                {
                    richTextBoxOutput.Invoke((Action)(() => richTextBoxOutput.AppendText(Environment.NewLine + args.Data.TrimEnd())));
                    textBoxCurrentOutput.Invoke((Action)(() => textBoxCurrentOutput.Text = ""));
                }
                ParseAndUpdateProgress(args.Data);
            }
        }

        private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
            {
                richTextBoxOutput.Invoke((Action)(() => richTextBoxOutput.AppendText(Environment.NewLine + args.Data.TrimEnd())));
                textBoxCurrentOutput.Invoke((Action)(() => textBoxCurrentOutput.Text = ""));
            }
        }

        private void ParseAndUpdateProgress(string input)
        {
            TimeSpan processed = TimeSpan.Zero;
            if (input.StartsWith("frame="))
            {
                Regex progressRegex = new Regex("time=(?<progress>[0-9:.]+)\\s", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
                Match progressMatch = progressRegex.Match(input);
                if (progressMatch.Success)
                {
                    try
                    {
                        processed = TimeSpan.Parse(progressMatch.Groups["progress"].Value);
                    }
                    catch { }
                }
            }
            int progressPercentage = (int)Math.Round((processed.TotalSeconds / duration) * 1000.0);
            progressPercentage = Math.Min(1000, progressPercentage);
            if (progressPercentage > 0)
            {
                progressBarEncoding.InvokeIfRequired(() =>
                {
                    progressBarEncoding.Value = progressPercentage;
                });
                taskbarManager.SetProgressValue(progressPercentage, 1000);
                this.InvokeIfRequired(() =>
                {
                    int titlePercentage = (int)Math.Floor(progressPercentage / 10.0);
                    Text = $"{formTitle} - {titlePercentage}%";
                });
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cancelTwoPass = true;

            if (!processEnded || processPanic)
            {
                if (!ffmpegProcess.HasExited)
                    ffmpegProcess.Kill();
            }
            else
            {
                Close();
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (!File.Exists(outputFile))
                MessageBox.Show("Выходной файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Process.Start(outputFile);
        }

        // manually scroll to bottom cause AppendText doesn't do it if it doesn't have focus
        private void richTextBoxOutput_TextChanged(object sender, EventArgs e) => NativeMethods.SendMessage(richTextBoxOutput.Handle, 0x115, 7, 0); // 0x115: WM_VSCROLL, 7: SB_BOTTOM
    }
}
