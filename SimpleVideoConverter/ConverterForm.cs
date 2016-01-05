using System;
using System.Diagnostics;
using System.Windows.Forms;
using SysTimer = System.Windows.Forms.Timer;

namespace SimpleVideoConverter
{
    public partial class ConverterForm : Form
    {
        private readonly MainForm _owner;
        private readonly string[] _arguments;
        private FFmpeg _ffmpegProcess;

        private SysTimer _timer;
        private bool _ended;
        private bool _panic;

        private int _currentPass = 0;
        private bool _multipass;
        private bool _cancelMultipass;

        public ConverterForm(MainForm owner, string[] args)
        {
            InitializeComponent();

            _owner = owner;
            _arguments = args;
        }

        private void ProcessOnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
                textBoxOutput.Invoke((Action)(() => textBoxOutput.AppendText("\n" + args.Data)));
        }

        private void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data != null)
                textBoxOutput.Invoke((Action)(() => textBoxOutput.AppendText("\n" + args.Data)));
        }

        private void ConverterForm_Load(object sender, EventArgs e)
        {
            string argument = null;
            _multipass = true;

            if (_arguments.Length == 1)
            {
                _multipass = false;
                argument = _arguments[0];
            }

            if (_multipass)
            {
                for (int i = 0; i < _arguments.Length; i++)
                    textBoxOutput.AppendText(string.Format("Аргументы для прохода {0}: {1}\n", i + 1, _arguments[i]));
            }
            else
                textBoxOutput.AppendText("Аргументы: " + argument + "\n");

            if (_multipass)
                MultiPass(_arguments);
            else
                SinglePass(argument);
        }

        private void SinglePass(string argument)
        {
            _ffmpegProcess = new FFmpeg(argument);

            _ffmpegProcess.Process.ErrorDataReceived += ProcessOnErrorDataReceived;
            _ffmpegProcess.Process.OutputDataReceived += ProcessOnOutputDataReceived;
            _ffmpegProcess.Process.Exited += (o, args) => textBoxOutput.Invoke((Action)(() =>
            {
                if (_panic) return; //This should stop that one exception when closing the converter
                textBoxOutput.AppendText("\n--- FFMPEG HAS EXITED ---");
                buttonCancel.Enabled = false;

                _timer = new SysTimer();
                _timer.Interval = 500;
                _timer.Tick += Exited;
                _timer.Start();
            }));

            _ffmpegProcess.Start();
        }

        private void MultiPass(string[] arguments)
        {
            int passes = arguments.Length;

            try
            {
                _ffmpegProcess = new FFmpeg(arguments[_currentPass]);
            }
            catch (Exception ex)
            {
                textBoxOutput.AppendText("\nНевозможно запустить ffmpeg.exe: " + ex.Message);
                pictureBox.BackgroundImage = Properties.Resources.critical;
                buttonCancel.Text = "Закрыть";
                buttonCancel.Enabled = true;
                _ended = true;
                return;
            }

            _ffmpegProcess.Process.ErrorDataReceived += ProcessOnErrorDataReceived;
            _ffmpegProcess.Process.OutputDataReceived += ProcessOnOutputDataReceived;
            _ffmpegProcess.Process.Exited += (o, args) => textBoxOutput.Invoke((Action)(() =>
            {
                if (_panic) return; //This should stop that one exception when closing the converter
                textBoxOutput.AppendText("\n--- FFMPEG HAS EXITED ---\n");

                _currentPass++;
                if (_currentPass < passes && !_cancelMultipass)
                {
                    textBoxOutput.AppendText(string.Format("\n--- ENTERING PASS {0} ---\n", _currentPass + 1));

                    MultiPass(arguments); //Sort of recursion going on here, be careful with stack overflows and shit
                    return;
                }

                buttonCancel.Enabled = false;

                _timer = new SysTimer();
                _timer.Interval = 500;
                _timer.Tick += Exited;
                _timer.Start();
            }));

            _ffmpegProcess.Start();
        }

        private void Exited(object sender, EventArgs eventArgs)
        {
            _timer.Stop();

            var process = _ffmpegProcess.Process;

            if (process.ExitCode != 0)
            {
                if (_cancelMultipass)
                    textBoxOutput.AppendText("\n\nКонвертация отменена.");
                else
                {
                    textBoxOutput.AppendText(string.Format("\n\nffmpeg.exe exited with exit code {0}. That's usually bad.", process.ExitCode));
                    //textBoxOutput.AppendText("\nIf you have no idea what went wrong, open an issue on GitHub and copy paste the output of this window there.");
                }
                pictureBox.BackgroundImage = Properties.Resources.critical;

                if (process.ExitCode == -1073741819) //This error keeps happening for me if I set threads to anything above 1, might happen for other people too
                    MessageBox.Show("It appears ffmpeg.exe crashed because of a thread error.", "FYI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBoxOutput.AppendText("\n\nВидео успешно переконвертировано!");
                pictureBox.BackgroundImage = Properties.Resources.complete;

                buttonPlay.Enabled = true;
            }

            buttonCancel.Text = "Закрыть";
            buttonCancel.Enabled = true;
            _ended = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _cancelMultipass = true;

            if (!_ended || _panic) //Prevent stack overflow
            {
                if (!_ffmpegProcess.Process.HasExited)
                    _ffmpegProcess.Process.Kill();
            }
            else
                Close();
        }

        private void ConverterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _panic = true; //Shut down while avoiding exceptions
            buttonCancel_Click(sender, e);
        }

        private void ConverterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ffmpegProcess.Process.Dispose();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(_owner.textBoxOut.Text); //Play result video
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
