using NReco.VideoConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SysTimer = System.Timers.Timer;

namespace Alexantr.SimpleVideoConverter
{
    public partial class MainForm : Form
    {
        private char[] invalidChars = Path.GetInvalidPathChars();

        private const string FileTypeMP4 = "mp4";
        private const string FileTypeWebM = "webm";

        private const int MinWidth = 128;
        private const int MaxWidth = 1920;

        private const int MinHeight = 96;
        private const int MaxHeight = 1080;

        private const int MinBitrate = 100;
        private const int MaxBitrate = 50000;

        private const int MinAudioBitrate = 8;
        private const int MaxAudioBitrate = 320;

        private string fileType; // mp4 or webm

        private List<string> frequencyList;
        private Dictionary<string, string> channelsList;

        private List<string> tempFilesList;

        private BackgroundWorker bw;
        private bool converting = false;

        private string buttonGoText;

        private SysTimer toolTipTimer;
        private string prevToolTipMessage;

        private bool closeApp = false;

        #region Main Form

        public MainForm()
        {
            InitializeComponent();

            tempFilesList = new List<string>();

            AllowDrop = true;
            DragEnter += HandleDragEnter;
            DragDrop += HandleDragDrop;

            frequencyList = new List<string>
            {
                "8000",
                "12000",
                "16000",
                "22050",
                "24000",
                "32000",
                "44100",
                "48000"
            };

            channelsList = new Dictionary<string, string>
            {
                { "1", "моно" },
                { "2", "стерео" }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonGoText = buttonGo.Text;
            buttonGo.Enabled = false;

            if (Properties.Settings.Default.RememberOutPath)
            {
                checkBoxKeepOutPath.Checked = true;
            }

            // Format: 0 - mp4, 1 - webm
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OutFileType) && Properties.Settings.Default.OutFileType == FileTypeWebM)
            {
                comboBoxFileType.SelectedIndex = 1;
                fileType = FileTypeWebM;
            }
            else
            {
                comboBoxFileType.SelectedIndex = 0;
                fileType = FileTypeMP4;
            }

            // Size
            numericUpDownWidth.Enabled = false;
            numericUpDownHeight.Enabled = false;
            labelX.Enabled = false;

            checkBoxEnableAudio.Checked = true;

            // Frequency
            comboBoxFrequency.Items.Clear();
            comboBoxFrequency.Items.Add(new ComboBoxItem(string.Empty, "авто"));
            foreach (string frequencyItem in frequencyList)
            {
                comboBoxFrequency.Items.Add(new ComboBoxItem(frequencyItem, frequencyItem));
            }
            comboBoxFrequency.SelectedIndex = 0;

            // Channels
            comboBoxChannels.Items.Clear();
            comboBoxChannels.Items.Add(new ComboBoxItem(string.Empty, "авто"));
            foreach (KeyValuePair<string, string> kvp in channelsList)
            {
                comboBoxChannels.Items.Add(new ComboBoxItem(kvp.Key, kvp.Value));
            }
            comboBoxChannels.SelectedIndex = 0;

            toolStripProgressBar.Visible = false;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                textBoxIn.Text = commandLineArgs[1];
                SetOutFilePath(commandLineArgs[1]);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (converting)
            {
                if (MessageBox.Show("Отменить конвертирование и выйти?", "Подтвердить выход", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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

            foreach (string tempFile in tempFilesList)
            {
                File.Delete(tempFile);
            }
        }

        #endregion

        #region ToolTips

        [DebuggerStepThrough]
        void SetToolTip(string message)
        {
            if (IsDisposed || toolStripStatusLabel.IsDisposed)
            {
                return;
            }

            this.InvokeIfRequired(() =>
            {
                toolStripStatusLabel.Text = message;
            });
        }

        [DebuggerStepThrough]
        void ShowToolTip(string message, int timer = 0)
        {
            // remember prev message if it's timer = 0
            if (toolTipTimer == null && !string.IsNullOrWhiteSpace(toolStripStatusLabel.Text))
            {
                prevToolTipMessage = toolStripStatusLabel.Text;
            }

            ClearToolTip();

            SetToolTip(message);

            if (timer > 0)
            {
                toolTipTimer = new SysTimer(timer);

                //toolTipTimer.Elapsed += (sender, e) => clearToolTip();
                toolTipTimer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
                {
                    ClearToolTip();
                    RestoreToolTip();
                };

                toolTipTimer.AutoReset = false;
                toolTipTimer.Enabled = true;
            }
        }

        [DebuggerStepThrough]
        void ClearToolTip(object sender = null, EventArgs e = null)
        {
            if (toolTipTimer != null)
            {
                toolTipTimer.Close();
            }

            SetToolTip("");
        }

        [DebuggerStepThrough]
        void RestoreToolTip()
        {
            if (!string.IsNullOrWhiteSpace(prevToolTipMessage))
            {
                SetToolTip(prevToolTipMessage);
                prevToolTipMessage = "";
            }
        }

        #endregion

        #region In, Out

        private void buttonBrowseIn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.InPath) && Directory.Exists(Properties.Settings.Default.InPath))
                {
                    dialog.InitialDirectory = Properties.Settings.Default.InPath;
                }
                else
                {
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                }

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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxIn.Text = files[0];
            SetOutFilePath(files[0]);
        }

        private void buttonBrowseOut_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.OverwritePrompt = false; // ask later
                dialog.ValidateNames = true;
                dialog.Filter = fileType == FileTypeWebM ? "WebM файлы|*.webm" : "MP4 файлы|*.mp4";

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
                {
                    dialog.InitialDirectory = Properties.Settings.Default.OutPath;
                }

                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.FileName))
                {
                    textBoxOut.Text = dialog.FileName;
                    Properties.Settings.Default.OutPath = Path.GetDirectoryName(dialog.FileName);
                }
            }
        }

        private void checkBoxKeepOutPath_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberOutPath = checkBoxKeepOutPath.Checked;
        }

        #endregion

        #region Format

        private void comboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileType = comboBoxFileType.SelectedIndex == 1 ? FileTypeWebM : FileTypeMP4;
            Properties.Settings.Default.OutFileType = fileType;
            ChangeOutExtension();
        }

        #endregion

        #region Resize Picture

        private void checkBoxResizePicture_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownWidth.Enabled = checkBoxResizePicture.Checked;
            numericUpDownHeight.Enabled = checkBoxResizePicture.Checked;
            labelX.Enabled = checkBoxResizePicture.Checked;
        }

        #endregion

        #region Audio

        private void checkBoxEnableAudio_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckGroupBox(checkBoxEnableAudio, groupBoxAudioParams);
        }

        #endregion

        #region Buttons

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (converting)
            {
                if (MessageBox.Show("Отменить конвертирование?", "Подтвердить отмену", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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

        #endregion

        #region Functions

        private void ChangeOutExtension()
        {
            if (!string.IsNullOrWhiteSpace(textBoxOut.Text))
            {
                try
                {
                    textBoxOut.Text = Path.Combine(Path.GetDirectoryName(textBoxOut.Text), Path.GetFileNameWithoutExtension(textBoxOut.Text) + "." + fileType);
                }
                catch (Exception) { }
            }
        }

        private void SetOutFilePath(string path)
        {
            if (!converting)
            {
                ClearToolTip();
                ResetProgressBar();
                toolStripProgressBar.Visible = false;
            }

            try
            {
                ValidateInputFile(path);
            }
            catch (Exception ex)
            {
                textBoxIn.Text = "";
                textBoxOut.Text = "";
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Properties.Settings.Default.InPath = Path.GetDirectoryName(path);

            checkBoxDeinterlace.Checked = false;
            buttonGo.Enabled = true;

            try
            {
                string outDir = "";
                string withoutExtension = Path.GetFileNameWithoutExtension(path);

                if (Properties.Settings.Default.RememberOutPath)
                {
                    if (!string.IsNullOrWhiteSpace(textBoxOut.Text))
                    {
                        outDir = Path.GetDirectoryName(textBoxOut.Text);
                    }
                    else if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OutPath))
                    {
                        outDir = Properties.Settings.Default.OutPath;
                    }
                }

                if (string.IsNullOrWhiteSpace(outDir) || !Directory.Exists(outDir))
                {
                    outDir = Path.GetDirectoryName(path);
                }

                Properties.Settings.Default.OutPath = outDir;

                string outPath = Path.Combine(outDir, withoutExtension + "." + fileType);
                int num = 2;
                while (File.Exists(outPath))
                {
                    outPath = Path.Combine(outDir, withoutExtension + " (" + num.ToString() + ")." + fileType);
                    num++;
                }
                textBoxOut.Text = outPath;
            }
            catch (Exception) { }
        }

        private void ValidateInputFile(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Не выбран исходный файл!");
            }
            if (input.IndexOfAny(invalidChars) >= 0)
            {
                throw new Exception("Путь к исходному файлу содержит невалидные символы!");
            }
            if (!File.Exists(input))
            {
                throw new Exception("Не найден исходный файл!");
            }
        }

        private void ValidateOutputFile(string output)
        {
            if (string.IsNullOrWhiteSpace(output))
            {
                throw new Exception("Не указан путь к итоговому файлу!");
            }
            if (output.IndexOfAny(invalidChars) >= 0)
            {
                throw new Exception("Путь к итоговому файлу содержит невалидные символы!");
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
            int videoBitrate = Convert.ToInt32(Math.Round(numericUpDownBitrate.Value, 0));
            int audioBitrate = Convert.ToInt32(Math.Round(numericUpDownAudioBitrate.Value, 0));

            string audioChannels = comboBoxItemChannels.Value;
            string audioFrequency = comboBoxItemFrequency.Value;

            ValidateInputFile(input);
            ValidateOutputFile(output);

            input = Path.GetFullPath(input);
            output = Path.GetFullPath(output);

            if (input.Equals(output, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Пути не должны совпадать!");
            }

            if (width < MinWidth || width > MaxWidth || height < MinHeight || height > MaxHeight)
            {
                throw new Exception("Неверно задано разрешение видео!");
            }

            if (videoBitrate < MinBitrate || videoBitrate > MaxBitrate)
            {
                throw new Exception("Неверно задано значение битрейта для видео!");
            }

            if (audioBitrate < MinAudioBitrate || audioBitrate > MaxAudioBitrate)
            {
                throw new Exception("Неверно задано значение битрейта для аудио!");
            }

            string outputDir = Path.GetDirectoryName(output);

            // try to create out folder
            if (!string.IsNullOrWhiteSpace(outputDir) && !Directory.Exists(outputDir))
            {
                try
                {
                    Directory.CreateDirectory(outputDir);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка создания выходной папки!\n" + ex.Message);
                }
            }

            if (File.Exists(output))
            {
                string question = Path.GetFileName(output) + " уже существует.\nХотите заменить его?";
                if (MessageBox.Show(question, "Подтвердить перезапись", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            bool twoPass = true; // for future releases

            string videoArgs;
            string audioArgs;

            // Video and audio args

            if (fileType == FileTypeMP4)
            {
                string videoCodec = "libx264";
                string audioCodec = "aac";

                // must be configurable
                string videoPreset = "slow";
                string videoProfile = "high"; // or "main" and more
                string videoLevel = "4.1"; // or "3.1" and more
                string videoParams = "-fast-pskip 0 -mbtree 0 -pix_fmt yuv420p -movflags +faststart";

                string moreVideoArgs = string.Format("-preset:v {0} -profile:v {1} -level {2} {3}", videoPreset, videoProfile, videoLevel, videoParams);
                string moreAudioArgs = "-strict -2"; // for "aac" codec

                videoArgs = string.Format("-c:v {0} -b:v {1}k {2}", videoCodec, videoBitrate, moreVideoArgs);
                audioArgs = string.Format("-c:a {0} -b:a {1}k {2}", audioCodec, audioBitrate, moreAudioArgs);
            }
            else if (fileType == FileTypeWebM)
            {
                string videoCodec = "libvpx"; // or "libvpx-vp9"
                string audioCodec = "libvorbis"; // or "libopus"

                videoArgs = string.Format("-c:v {0} -b:v {1}k", videoCodec, videoBitrate);
                audioArgs = string.Format("-c:a {0} -b:a {1}k", audioCodec, audioBitrate);
            }
            else
            {
                throw new Exception("Неверный выходной тип файла!"); // Possible?
            }

            // Video filters

            List<string> filters = new List<string>();

            if (checkBoxDeinterlace.Checked)
            {
                filters.Add("yadif");
                // add field order
            }

            if (checkBoxResizePicture.Checked)
            {
                filters.Add(string.Format("scale={0}x{1},setsar=1:1", width, height));
            }

            // More video args

            if (filters.Count > 0)
            {
                videoArgs += " -vf " + string.Join(",", filters);
            }

            // More audio args

            if (!checkBoxEnableAudio.Checked)
            {
                audioArgs = "-an";
            }
            else
            {
                // resampling
                if (!string.IsNullOrWhiteSpace(audioFrequency))
                {
                    audioArgs += string.Format(" -ar {0}", audioFrequency);
                }
                // channels
                if (!string.IsNullOrWhiteSpace(audioChannels))
                {
                    audioArgs += string.Format(" -ac {0}", audioChannels);
                }
            }

            // More args

            string moreArgs = "-map_metadata -1";

            // Convert

            if (twoPass)
            {
                // {0} is video args
                // {1} is audio args
                // {2} is more args
                // {4} is pass args
                string template = "{3} {0} {1} {2}";

                var passlogfile = GetTempLogFile();

                // {0} is pass number (1 or 2)
                // {1} is the prefix for the pass .log file
                string passArgsTemplate = " -pass {0} -passlogfile \"{1}\"";

                string[] arguments = new string[2];
                arguments[0] = string.Format(template, videoArgs, "-an", moreArgs, string.Format(passArgsTemplate, 1, passlogfile));
                arguments[1] = string.Format(template, videoArgs, audioArgs, moreArgs, string.Format(passArgsTemplate, 2, passlogfile));

                RunConvertWorker(input, output, fileType, arguments, 0);
            }
            else
            {
                // {0} is video args
                // {1} is audio args
                // {2} is more args
                string argsTemplate = "{0} {1} {2}";

                string[] arguments = new string[1];
                arguments[0] = string.Format(argsTemplate, videoArgs, audioArgs, moreArgs);

                RunConvertWorker(input, output, fileType, arguments, 0);
            }
        }

        /// <summary>
        /// Run Convert Worker
        /// </summary>
        /// <param name="inputPath">Input file path</param>
        /// <param name="outputPath">Output file path</param>
        /// <param name="format">Video file format</param>
        /// <param name="arguments">Arguments for ffmpeg</param>
        /// <param name="passNumber">Pass number</param>
        private void RunConvertWorker(string inputPath, string outputPath, string format, string[] arguments, int passNumber)
        {
            int passCount = arguments.Length;
            if (passNumber > passCount - 1)
            {
                return;
            }

            string currentPassArguments = arguments[passNumber];
            string currentOutputPath = outputPath;
            string toolTipText = "Выполняется конвертирование";

#if DEBUG
            Console.WriteLine(currentPassArguments);
#endif

            if (passCount > 1)
            {
                toolTipText = string.Format("Выполняется проход {0} из {1}", (passNumber + 1), passCount);
                if (passNumber < (passCount - 1))
                {
                    currentOutputPath = "NUL";
                }
            }

            bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };
            bw.ProgressChanged += (sender, e) =>
            {
                int progressPercentage = Math.Min(100, e.ProgressPercentage);
                if (progressPercentage > 0)
                {
                    ProgressBarPercentage(progressPercentage);
                }
                ShowToolTip(toolTipText);
            };
            bw.DoWork += (sender, e) =>
            {
                try
                {
                    FFMpegConverter ffMpeg = new FFMpegConverter
                    {
                        FFMpegProcessPriority = ProcessPriorityClass.Idle,
                        FFMpegToolPath = Path.Combine(Environment.CurrentDirectory, "ffmpeg")
                    };

                    ConvertSettings settings = new ConvertSettings
                    {
                        CustomOutputArgs = currentPassArguments
                    };

                    ffMpeg.ConvertProgress += (sendertwo, etwo) =>
                    {
                        if (bw.CancellationPending)
                        {
                            if (!ffMpeg.Stop())
                            {
                                ffMpeg.Abort();
                            }
                            e.Cancel = true;
                            return;
                        }

                        int perc = (int)((etwo.Processed.TotalMilliseconds / etwo.TotalDuration.TotalMilliseconds) * 100.0);
                        bw.ReportProgress(perc);
                    };

                    ffMpeg.ConvertMedia(inputPath, null, currentOutputPath, format, settings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            };
            bw.RunWorkerCompleted += (sender, e) =>
            {
                if (e.Cancelled)
                {
                    converting = false;

                    // reset pbar
                    ResetProgressBar();
                    toolStripProgressBar.Visible = false;

                    buttonGo.Text = buttonGoText;
                    buttonGo.Enabled = true;

                    ShowToolTip("Конвертирование отменено");

                    if (closeApp)
                    {
                        Application.Exit();
                    }

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

                    ShowToolTip("Готово");
                    if (MessageBox.Show("Открыть полученный файл?", "Конвертирование выполнено", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
            toolStripProgressBar.Visible = true;

            buttonGo.Text = "Отменить";
            buttonGo.Enabled = true;

            converting = true;
            ShowToolTip(toolTipText);
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

        private void ManageCheckGroupBox(CheckBox chk, GroupBox grp)
        {
            if (chk.Parent == grp)
            {
                grp.Parent.Controls.Add(chk);
                chk.Location = new Point(chk.Left + grp.Left, chk.Top + grp.Top);
                chk.BringToFront();
            }
            grp.Enabled = chk.Checked;
        }

        private string GetTempFile()
        {
            string tempFileName = Path.GetTempFileName();
            tempFilesList.Add(tempFileName);
            return tempFileName;
        }

        private string GetTempLogFile(int streamIndex = 0)
        {
            var tempLogFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var tempLogFileRealName = string.Format("{0}-{1}.log", tempLogFile, streamIndex);
            var tempLogMbtreeFileRealName = string.Format("{0}-{1}.log.mbtree", tempLogFile, streamIndex);
            tempFilesList.Add(tempLogFileRealName);
            tempFilesList.Add(tempLogMbtreeFileRealName);
            return tempLogFile;
        }

        #endregion
    }
}
