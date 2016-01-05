using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SysTimer = System.Timers.Timer;

namespace SimpleVideoConverter
{
    public partial class MainForm : Form
    {
        private const string FormatMP4 = "mp4";
        private const string FormatWebM = "webm";

        private const int MinWidth = 128;
        private const int MaxWidth = 1920;

        private const int MinHeight = 96;
        private const int MaxHeight = 1080;

        private const int MinBitrate = 100;
        private const int MaxBitrate = 14000;

        private const int MinAudioBitrate = 8;
        private const int MaxAudioBitrate = 320;
        
        private string format; // mp4 or webm

        private List<string> frequencyList;
        private Dictionary<string, string> channelsList;

        private List<string> tempFilesList;

        private BackgroundWorker bw;
        private bool converting = false;

        private string buttonGoText;

        private SysTimer toolTipTimer;
        private string prevToolTipMessage;

        private bool closeApp = false;

        public MainForm()
        {
            InitializeComponent();

            tempFilesList = new List<string>();

            AllowDrop = true;
            DragEnter += HandleDragEnter;
            DragDrop += HandleDragDrop;

            frequencyList = new List<string>();
            frequencyList.Add("8000");
            frequencyList.Add("12000");
            frequencyList.Add("16000");
            frequencyList.Add("22050");
            frequencyList.Add("24000");
            frequencyList.Add("32000");
            frequencyList.Add("44100");
            frequencyList.Add("48000");

            channelsList = new Dictionary<string, string>();
            channelsList.Add("1", "моно");
            channelsList.Add("2", "стерео");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonGoText = buttonGo.Text;

            if (Properties.Settings.Default.KeepOutPath)
                checkBoxKeepOutPath.Checked = true;

            // 0 - mp4
            // 1 - webm
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.Format) && Properties.Settings.Default.Format == FormatWebM)
            {
                comboBoxFileType.SelectedIndex = 1;
                format = FormatWebM;
            }
            else
            {
                comboBoxFileType.SelectedIndex = 0;
                format = FormatMP4;
            }

            numericUpDownWidth.Enabled = false;
            numericUpDownHeight.Enabled = false;
            labelX.Enabled = false;

            checkBoxEnableAudio.Checked = true;

            // Frequency
            comboBoxFrequency.Items.Clear();
            comboBoxFrequency.Items.Add(new ComboBoxItem(string.Empty, "авто"));
            foreach (string frequencyItem in frequencyList)
                comboBoxFrequency.Items.Add(new ComboBoxItem(frequencyItem, frequencyItem));
            comboBoxFrequency.SelectedIndex = 0;

            // Channels
            comboBoxChannels.Items.Clear();
            comboBoxChannels.Items.Add(new ComboBoxItem(string.Empty, "авто"));
            foreach (KeyValuePair<string, string> kvp in channelsList)
            {
                comboBoxChannels.Items.Add(new ComboBoxItem(kvp.Key, kvp.Value));
            }
            comboBoxChannels.SelectedIndex = 0;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                textBoxIn.Text = args[1];
                SetOutFilePath(args[1]);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (converting)
            {
                if (MessageBox.Show("Отменить конвертирование и выйти?", "Подтвердить выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bw.CancelAsync();
                    closeApp = true;
                    buttonGo.Enabled = false;

                    e.Cancel = true;
                    Activate();
                    return;
                }
                else
                {
                    e.Cancel = true;
                    Activate();
                    return;
                }
            }

            Properties.Settings.Default.Save();

            foreach (var tempFile in tempFilesList)
            {
                File.Delete(tempFile);
            }
        }

        #region ToolTips

        [DebuggerStepThrough]
        void setToolTip(string message)
        {
            if (this.IsDisposed || toolStripStatusLabel.IsDisposed)
                return;

            this.InvokeIfRequired(() =>
            {
                toolStripStatusLabel.Text = message;
            });
        }

        [DebuggerStepThrough]
        void showToolTip(string message, int timer = 0)
        {
            // remember prev message if it's timer = 0
            if (toolTipTimer == null && !string.IsNullOrWhiteSpace(toolStripStatusLabel.Text))
                prevToolTipMessage = toolStripStatusLabel.Text;

            clearToolTip();

            setToolTip(message);

            if (timer > 0)
            {
                toolTipTimer = new SysTimer(timer);

                //toolTipTimer.Elapsed += (sender, e) => clearToolTip();
                toolTipTimer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
                {
                    clearToolTip();
                    restoreToolTip();
                };

                toolTipTimer.AutoReset = false;
                toolTipTimer.Enabled = true;
            }
        }

        [DebuggerStepThrough]
        void clearToolTip(object sender = null, EventArgs e = null)
        {
            if (toolTipTimer != null)
                toolTipTimer.Close();

            setToolTip("");
        }

        [DebuggerStepThrough]
        void restoreToolTip()
        {
            if (!string.IsNullOrWhiteSpace(prevToolTipMessage))
            {
                setToolTip(prevToolTipMessage);
                prevToolTipMessage = "";
            }
        }

        #endregion

        private void buttonBrowseIn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.InPath) && Directory.Exists(Properties.Settings.Default.InPath))
                    dialog.InitialDirectory = Properties.Settings.Default.InPath;
                else
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.ValidateNames = true;

                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    textBoxIn.Text = dialog.FileName;
                    SetOutFilePath(dialog.FileName);
                }
            }
        }

        private void HandleDragEnter(object sender, DragEventArgs e)
        {
            // show copy cursor for files
            bool dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
            e.Effect = dataPresent ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void HandleDragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxIn.Text = files[0];
            SetOutFilePath(files[0]);
        }

        private void buttonBrowseOut_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.OverwritePrompt = false; // ask later
                dialog.ValidateNames = true;
                if (format == FormatWebM)
                    dialog.Filter = "WebM файлы|*.webm";
                else
                    dialog.Filter = "MP4 файлы|*.mp4";

                if (!string.IsNullOrWhiteSpace(textBoxOut.Text))
                {
                    try
                    {
                        dialog.InitialDirectory = Path.GetDirectoryName(textBoxOut.Text);
                        dialog.FileName = Path.GetFileName(textBoxOut.Text);
                    }
                    catch (Exception) { }
                }
                else if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OutPath))
                    dialog.InitialDirectory = Properties.Settings.Default.OutPath;

                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    textBoxOut.Text = dialog.FileName;
                    Properties.Settings.Default.OutPath = Path.GetDirectoryName(dialog.FileName);
                }
            }
        }

        private void checkBoxKeepOutPath_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeepOutPath = checkBoxKeepOutPath.Checked;
        }

        private void SetOutFilePath(string path)
        {
            clearToolTip();
            ResetProgressBar();

            if (string.IsNullOrWhiteSpace(path)) return;

            Properties.Settings.Default.InPath = Path.GetDirectoryName(path);

            checkBoxDeinterlace.Checked = false;

            try
            {
                string outDir = "";
                string outName = Path.GetFileNameWithoutExtension(path);

                if (Properties.Settings.Default.KeepOutPath)
                {
                    if (!string.IsNullOrWhiteSpace(textBoxOut.Text))
                        outDir = Path.GetDirectoryName(textBoxOut.Text);
                    else if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OutPath))
                        outDir = Properties.Settings.Default.OutPath;
                }

                if (string.IsNullOrWhiteSpace(outDir) || !Directory.Exists(outDir))
                    outDir = Path.GetDirectoryName(path);

                Properties.Settings.Default.OutPath = outDir;

                textBoxOut.Text = Path.Combine(outDir, outName + "-new." + format);
            }
            catch (Exception) { }
        }

        private void comboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFileType.SelectedIndex == 1)
                format = FormatWebM;
            else
                format = FormatMP4;

            Properties.Settings.Default.Format = format;

            // change extension in textbox
            if (!string.IsNullOrWhiteSpace(textBoxOut.Text))
            {
                try
                {
                    string outDir = Path.GetDirectoryName(textBoxOut.Text);
                    string outName = Path.GetFileNameWithoutExtension(textBoxOut.Text);
                    textBoxOut.Text = Path.Combine(outDir, outName + "." + format);
                }
                catch (Exception) { }
            }
        }

        private void checkBoxResizePicture_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownWidth.Enabled = checkBoxResizePicture.Checked;
            numericUpDownHeight.Enabled = checkBoxResizePicture.Checked;
            labelX.Enabled = checkBoxResizePicture.Checked;
        }

        private void checkBoxEnableAudio_CheckedChanged(object sender, EventArgs e)
        {
            labelAudioBitrate.Enabled = checkBoxEnableAudio.Checked;
            numericUpDownAudioBitrate.Enabled = checkBoxEnableAudio.Checked;
            labelChannels.Enabled = checkBoxEnableAudio.Checked;
            comboBoxChannels.Enabled = checkBoxEnableAudio.Checked;
            labelFrequency.Enabled = checkBoxEnableAudio.Checked;
            comboBoxFrequency.Enabled = checkBoxEnableAudio.Checked;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (converting)
            {
                if (MessageBox.Show("Отменить конвертирование?", "Подтвердить отмену", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bw.CancelAsync();
                    (sender as Button).Enabled = false;
                }
                return;
            }

            try
            {
                ConvertVideo();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConvertVideo()
        {
            string input = textBoxIn.Text;
            string output = textBoxOut.Text;

            var comboBoxItemChannels = (ComboBoxItem)comboBoxChannels.SelectedItem;
            var comboBoxItemFrequency = (ComboBoxItem)comboBoxFrequency.SelectedItem;

            int width = Convert.ToInt32(Math.Round(numericUpDownWidth.Value, 0));
            int height = Convert.ToInt32(Math.Round(numericUpDownHeight.Value, 0));
            int bitrate = Convert.ToInt32(Math.Round(numericUpDownBitrate.Value, 0));
            int audioBitrate = Convert.ToInt32(Math.Round(numericUpDownAudioBitrate.Value, 0));

            string audioChannels = comboBoxItemChannels.Value;
            string audioFrequency = comboBoxItemFrequency.Value;

            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Не выбран исходный файл!");
            if (string.IsNullOrWhiteSpace(output))
                throw new Exception("Не указан путь к итоговому файлу!");

            input = Path.GetFullPath(input);
            output = Path.GetFullPath(output);

            if (!File.Exists(input))
                throw new Exception("Не найден исходный файл!");

            if (input.Equals(output, StringComparison.OrdinalIgnoreCase))
                throw new Exception("Пути не должны совпадать!");

            if (width < MinWidth || width > MaxWidth || height < MinHeight || height > MaxHeight)
                throw new Exception("Неверно задано разрешение видео!");

            if (bitrate < MinBitrate || bitrate > MaxBitrate)
                throw new Exception("Неверно задано значение битрейта для видео!");

            if (audioBitrate < MinAudioBitrate || audioBitrate > MaxAudioBitrate)
                throw new Exception("Неверно задано значение битрейта для аудио!");

            string outputDir = Path.GetDirectoryName(output);

            // try to create out folder
            if (!string.IsNullOrWhiteSpace(outputDir) && !Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            if (File.Exists(output))
            {
                string question = Path.GetFileName(output) + " уже существует.\nХотите заменить его?";
                if (MessageBox.Show(question, "Подтвердить перезапись", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            string[] arguments = new string[2];

            string argsVideo;
            string argsAudio;
            string audioCodec;

            // set video args
            if (format == "mp4")
            {
                // main profile or high profile
                string h264Profile = "main";
                string h264Level = "3.1";
                argsVideo = string.Format(" -b:v {0}k -codec:v libx264 -preset:v slow -profile:v {1} -level {2} -pix_fmt yuv420p", bitrate, h264Profile, h264Level);
                audioCodec = "aac -strict -2";
            }
            else
            {
                // vp8
                string webmVideoCodec = "libvpx";
                argsVideo = string.Format(" -b:v {0}k -codec:v {1}", bitrate, webmVideoCodec);
                audioCodec = "libvorbis";
            }

            List<string> filters = new List<string>();

            if (checkBoxDeinterlace.Checked)
                filters.Add("yadif");
            
            if (checkBoxResizePicture.Checked)
                filters.Add(string.Format("scale={0}x{1},setsar=1:1", width, height));

            // set audio args
            if (!checkBoxEnableAudio.Checked)
                argsAudio = " -an";
            else
            {
                argsAudio = string.Format(" -codec:a {0} -b:a {1}k", audioCodec, audioBitrate);
                // resampling
                if (!string.IsNullOrWhiteSpace(audioFrequency))
                    argsAudio += string.Format(" -ar {0}", audioFrequency);
                // channels
                if (!string.IsNullOrWhiteSpace(audioChannels))
                    argsAudio += string.Format(" -ac {0}", audioChannels);
            }

            string moreArgs = (filters.Count > 0 ? " -vf " + string.Join(",", filters) : "");
            moreArgs += " -map_metadata -1";

            // {0} is pass args
            // {1} is video codec
            // {2} is filters
            // {3} is audio params
            string template = "{0}{1}{2}{3}";

            var passlogfile = GetTemporaryLogFile();

            // {0} is pass number (1 or 2)
            // {1} is the prefix for the pass .log file
            string passArgsTemplate = " -pass {0} -passlogfile \"{1}\"";

            arguments[0] = string.Format(template, string.Format(passArgsTemplate, 1, passlogfile), argsVideo, " -an", moreArgs);
            arguments[1] = string.Format(template, string.Format(passArgsTemplate, 2, passlogfile), argsVideo, argsAudio, moreArgs);

            RunConvertWorker(input, output, format, arguments, 0);
        }

        private void RunConvertWorker(string inputPath, string outputPath, string format, string[] arguments, int passNumber)
        {
            int passCount = arguments.Length;
            if (passNumber > passCount - 1) return;

            string currentPassArguments = arguments[passNumber];
            string currentOutputPath = outputPath;
            string toolTipText = "Выполняется конвертирование...";

            if (passCount > 1)
            {
                toolTipText = string.Format("Выполняется проход №{0}...", (passNumber + 1));
                if (passNumber < (passCount - 1))
                    currentOutputPath = "NUL";
            }
            
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += new ProgressChangedEventHandler(delegate (object sender, ProgressChangedEventArgs e)
            {
                int progressPercentage = Math.Min(100, e.ProgressPercentage);
                if (progressPercentage > 0)
                {
                    ProgressBarPercentage(progressPercentage);
                }
                showToolTip(toolTipText);
            });
            bw.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                try
                {
                    FFMpegConverter ffMpeg = new FFMpegConverter();
                    ffMpeg.FFMpegProcessPriority = ProcessPriorityClass.Idle;
                    ffMpeg.FFMpegToolPath = Path.Combine(Environment.CurrentDirectory, "Binaries");

                    ConvertSettings settings = new ConvertSettings();
                    settings.CustomOutputArgs = currentPassArguments;

                    ffMpeg.ConvertProgress += delegate (object sendertwo, ConvertProgressEventArgs etwo)
                    {
                        int perc = (int)((etwo.Processed.TotalMilliseconds / etwo.TotalDuration.TotalMilliseconds) * 100);
                        bw.ReportProgress(perc);
                        if (bw.CancellationPending)
                            ffMpeg.Stop();
                    };

                    ffMpeg.ConvertMedia(inputPath, null, currentOutputPath, format, settings);
                }
                catch (Exception ex)
                {
                    if (!ex.Message.StartsWith("Exiting normally"))
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            };
            bw.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled)
                {
                    converting = false;

                    // reset pbar
                    ResetProgressBar();

                    buttonGo.Text = buttonGoText;
                    buttonGo.Enabled = true;

                    showToolTip("Конвертирование отменено");

                    if (closeApp)
                        Application.Exit();

                    return;
                }
                
                // run next pass
                if (passCount > 1 && passNumber < (passCount - 1))
                {
                    RunConvertWorker(inputPath, outputPath, format, arguments, passNumber + 1);
                }
                else
                {
                    converting = false;

                    // 100% done!
                    ProgressBarPercentage(100);

                    buttonGo.Text = buttonGoText;
                    buttonGo.Enabled = true;

                    showToolTip("Готово");
                    if (MessageBox.Show("Конвертирование выполнено. Открыть файл?", "Конвертирование выполнено", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start(outputPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            };

            ResetProgressBar();

            buttonGo.Text = "Отменить";
            buttonGo.Enabled = true;

            converting = true;
            showToolTip(toolTipText);
            bw.RunWorkerAsync();
        }

        private void ResetProgressBar()
        {
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
        }

        private void ProgressBarPercentage(int percentage)
        {
            toolStripProgressBar.Value = percentage;
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
        }

        private string GetTemporaryLogFile(int streamIndex = 0)
        {
            var tempLogFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var tempLogFileRealName = string.Format("{0}-{1}.log", tempLogFile, streamIndex);
            var tempLogMbtreeFileRealName = string.Format("{0}-{1}.log.mbtree", tempLogFile, streamIndex);
            tempFilesList.Add(tempLogFileRealName);
            tempFilesList.Add(tempLogMbtreeFileRealName);
            return tempLogFile;
        }
    }
}
