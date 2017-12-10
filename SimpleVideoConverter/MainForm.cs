using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SysTimer = System.Timers.Timer;

namespace Alexantr.SimpleVideoConverter
{
    public partial class MainForm : Form
    {
        private VideoFile videoFile;

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

        private Dictionary<string, string> frameRateList;

        private Dictionary<string, string> fieldOrderList;

        private List<string> aspectRatioList;

        private List<string> audioBitRateList;
        private Dictionary<string, string> frequencyList;
        private Dictionary<string, string> channelsList;

        private List<string> tempFilesList;

        private bool doNotCheckKeepARAgain;

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

            frameRateList = new Dictionary<string, string>
            {
                { "10", "10" },
                { "12", "12" },
                { "15", "15" },
                { "18", "18" },
                { "20", "20" },
                { "24000/1001", "23.976" },
                { "24", "24" },
                { "25", "25" },
                { "30000/1001", "29.97" },
                { "30", "30" },
                { "48", "48" },
                { "50", "50" },
                { "60000/1001", "59.94" },
                { "60", "60" }
            };

            fieldOrderList = new Dictionary<string, string>
            {
                { "tff", "Top Field First" },
                { "bff", "Bottom Field First" }
            };

            aspectRatioList = new List<string>
            {
                "16:9",
                "4:3",
                "1:1",
                "1.85",
                "2.35",
                "2.39"
            };

            audioBitRateList = new List<string>
            {
                "32",
                "48",
                "64",
                "96",
                "112",
                "128",
                "160",
                "192",
                "224",
                "256",
                "320"
            };

            frequencyList = new Dictionary<string, string>
            {
                { "8000", "8 кГц" },
                { "12000", "12 кГц" },
                { "16000", "16 кГц" },
                { "22050", "22.05 кГц" },
                { "24000", "24 кГц" },
                { "32000", "32 кГц" },
                { "44100", "44.1 кГц" },
                { "48000", "48 кГц" },
                { "96000", "96 кГц"}
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

            // Frame rate
            FillComboBoxFrameRate();

            // Field order
            comboBoxFieldOrder.Items.Clear();
            comboBoxFieldOrder.Items.Add(new ComboBoxItem(string.Empty, "авто"));
            foreach (KeyValuePair<string, string> fieldOrder in fieldOrderList)
            {
                comboBoxFieldOrder.Items.Add(new ComboBoxItem(fieldOrder.Key, fieldOrder.Value));
            }
            comboBoxFieldOrder.SelectedIndex = 0;

            ManageCheckGroupBox(checkBoxDeinterlace, groupBoxDeinterlace);

            // Aspect ratio
            FillComboBoxAspectRatio("");

            ManageCheckGroupBox(checkBoxResizePicture, groupBoxResolution);

            comboBoxAspectRatio.Enabled = checkBoxKeepAspectRatio.Checked;

            // Audio bitrate
            int selectedIndexBitrate = 0, indexBitrate = 0;
            comboBoxAudioBitrate.Items.Clear();
            foreach (string ab in audioBitRateList)
            {
                comboBoxAudioBitrate.Items.Add(new ComboBoxItem(ab, ab));
                if (ab == "128")
                    selectedIndexBitrate = indexBitrate;
                indexBitrate++;
            }
            comboBoxAudioBitrate.SelectedIndex = selectedIndexBitrate;

            // Frequency
            comboBoxFrequency.Items.Clear();
            comboBoxFrequency.Items.Add(new ComboBoxItem(string.Empty, "авто"));
            foreach (KeyValuePair<string, string> frq in frequencyList)
            {
                comboBoxFrequency.Items.Add(new ComboBoxItem(frq.Key, frq.Value));
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

            // Progress bar
            toolStripProgressBar.Visible = false;

            // append version
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string niceVersion = version.Major.ToString() + "." + version.Minor.ToString();
            if (version.Build != 0 || version.Revision != 0)
            {
                niceVersion += "." + version.Build.ToString();
            }
            if (version.Revision != 0)
            {
                niceVersion += "." + version.Revision.ToString();
            }
            Text = Text + " v" + niceVersion;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                textBoxIn.Text = commandLineArgs[1];
                SetFile(commandLineArgs[1]);
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
        private void SetToolTip(string message)
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
        private void ShowToolTip(string message, int timer = 0)
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
        private void ClearToolTip(object sender = null, EventArgs e = null)
        {
            if (toolTipTimer != null)
            {
                toolTipTimer.Close();
            }

            SetToolTip("");
        }

        [DebuggerStepThrough]
        private void RestoreToolTip()
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
            if (converting)
            {
                return;
            }
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
                    SetFile(dialog.FileName);
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
            if (converting)
            {
                return;
            }
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            textBoxIn.Text = files[0];
            SetFile(files[0]);
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

        #region Deinterlace

        private void checkBoxDeinterlace_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckGroupBox(checkBoxDeinterlace, groupBoxDeinterlace);
        }

        #endregion

        #region Resize Picture

        private void checkBoxResizePicture_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckGroupBox(checkBoxResizePicture, groupBoxResolution);
            UpdateHeigth();
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeigth();
        }

        private void numericUpDownWidth_Leave(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(Math.Round(numericUpDownWidth.Value, 0));
            if (value % 2 == 1)
            {
                value -= 1;
                if (value < 128)
                    value = 128;
                numericUpDownWidth.Value = value;
            }
            UpdateHeigth();
        }

        private void checkBoxKeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            doNotCheckKeepARAgain = !checkBoxKeepAspectRatio.Checked;
            comboBoxAspectRatio.Enabled = checkBoxKeepAspectRatio.Checked;
            numericUpDownHeight.Enabled = !checkBoxKeepAspectRatio.Checked;
            UpdateHeigth();
        }

        private void comboBoxAspectRatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHeigth();
        }

        private void comboBoxAspectRatio_TextUpdate(object sender, EventArgs e)
        {
            UpdateHeigth();
        }

        #endregion

        #region Audio

        private void comboBoxAudioBitrate_Leave(object sender, EventArgs e)
        {
            string input = comboBoxAudioBitrate.SelectedIndex < 0 ? comboBoxAudioBitrate.Text : ((ComboBoxItem)comboBoxAudioBitrate.SelectedItem).Value;
            int.TryParse(input, out int audioBitrate);
            if (audioBitrate < MinAudioBitrate)
                audioBitrate = MinAudioBitrate;
            if (audioBitrate > MaxAudioBitrate)
                audioBitrate = MaxAudioBitrate;
            comboBoxAudioBitrate.Text = audioBitrate.ToString();
        }

        private void checkedListBoxAudioStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> selectedAudioList = new List<int>();
            foreach (int checkedIndex in checkedListBoxAudioStreams.CheckedIndices)
            {
                selectedAudioList.Add(checkedIndex);
            }
            groupBoxAudioParams.Enabled = selectedAudioList.Count > 0;
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

        private void SetFile(string path)
        {
            ClearToolTip();
            ResetProgressBar();
            toolStripProgressBar.Visible = false;
            richTextBoxInfo.Clear();
            ShowToolTip("Загрузка файла", 0);

            try
            {
                ValidateInputFile(path);
                videoFile = new VideoFile(path);
                videoFile.Probe();
            }
            catch (Exception ex)
            {
                videoFile = null;
                textBoxIn.Text = "";
                textBoxOut.Text = "";
                ClearToolTip();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Properties.Settings.Default.InPath = Path.GetDirectoryName(path);

            ClearToolTip();

            // set original aspect ratio
            string original = "";
            if (videoFile.VideoStreams[0].PictureSize.Width > 0 && videoFile.VideoStreams[0].PictureSize.Height > 0)
            {
                original = string.Format("{0}:{1}", videoFile.VideoStreams[0].PictureSize.Width, videoFile.VideoStreams[0].PictureSize.Height);
            }
            FillComboBoxAspectRatio(original);
            checkBoxKeepAspectRatio.Checked = !doNotCheckKeepARAgain && !string.IsNullOrWhiteSpace(original);

            // if need resize
            bool needResize = false;
            int w = videoFile.VideoStreams[0].PictureSize.Width;
            if (w > MaxWidth)
            {
                w = MaxWidth;
                needResize = true;
            }
            if (w < MinWidth)
            {
                w = MinWidth;
                needResize = true;
            }
            numericUpDownWidth.Value = w;
            checkBoxResizePicture.Checked = needResize;
            checkBoxKeepAspectRatio.Checked = true;
            UpdateHeigth();

            // if need deinterlace
            checkBoxDeinterlace.Checked = videoFile.VideoStreams[0].FieldOrder != "progressive";
            comboBoxFieldOrder.SelectedIndex = 0;
            comboBoxFrameRate.SelectedIndex = 0;

            // has audio
            groupBoxAudioParams.Enabled = videoFile.AudioStreams.Count > 0;

            // show info
            ShowInfo();

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
            if (videoFile == null)
            {
                throw new Exception("Видео-файл не определен!");
            }

            string input = videoFile.FullPath;
            string output = Path.GetFullPath(textBoxOut.Text);

            ValidateOutputFile(output);

            ComboBoxItem comboBoxItemFrameRate = (ComboBoxItem)comboBoxFrameRate.SelectedItem;
            ComboBoxItem comboBoxItemChannels = (ComboBoxItem)comboBoxChannels.SelectedItem;
            ComboBoxItem selectedItemAudioBitrate = (ComboBoxItem)comboBoxAudioBitrate.SelectedItem;
            ComboBoxItem comboBoxItemFrequency = (ComboBoxItem)comboBoxFrequency.SelectedItem;
            ComboBoxItem selectedItemFieldOrder = (ComboBoxItem)comboBoxFieldOrder.SelectedItem;

            int width = Convert.ToInt32(Math.Round(numericUpDownWidth.Value, 0));
            int height = Convert.ToInt32(Math.Round(numericUpDownHeight.Value, 0));
            int videoBitrate = Convert.ToInt32(Math.Round(numericUpDownBitrate.Value, 0));
            int audioBitrate = Convert.ToInt32(selectedItemAudioBitrate.Value);

            string frameRate = comboBoxItemFrameRate.Value;
            string fieldOrder = selectedItemFieldOrder.Value;
            string audioChannels = comboBoxItemChannels.Value;
            string audioFrequency = comboBoxItemFrequency.Value;

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
                    throw new Exception("Ошибка создания выходной папки!" + Environment.NewLine + ex.Message);
                }
            }

            if (File.Exists(output))
            {
                string question = Path.GetFileName(output) + " уже существует." + Environment.NewLine + "Хотите заменить его?";
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

                videoArgs = $"-c:v {videoCodec} -b:v {videoBitrate}k {moreVideoArgs}";
                audioArgs = $"-c:a {audioCodec} -b:a {audioBitrate}k {moreAudioArgs}";
            }
            else if (fileType == FileTypeWebM)
            {
                string videoCodec = "libvpx"; // or "libvpx-vp9"
                string audioCodec = "libvorbis"; // or "libopus"

                videoArgs = $"-c:v {videoCodec} -b:v {videoBitrate}k";
                audioArgs = $"-c:a {audioCodec} -b:a {audioBitrate}k";
            }
            else
            {
                throw new Exception("Неверный выходной тип файла!"); // Possible?
            }

            // Video filters

            List<string> filters = new List<string>();

            if (checkBoxDeinterlace.Checked)
            {
                string deinterlaceFilter = "yadif";
                if (!string.IsNullOrWhiteSpace(fieldOrder))
                    deinterlaceFilter += $"=parity={fieldOrder}";
                filters.Add(deinterlaceFilter);
            }

            if (checkBoxResizePicture.Checked)
            {
                // https://www.ffmpeg.org/ffmpeg-scaler.html#sws_005fflags
                filters.Add($"scale={width}x{height}:flags=lanczos,setsar=1:1");
            }

            // More video args

            videoArgs += string.Format(" -map 0:{0}", videoFile.VideoStreams[0].Index);

            if (!string.IsNullOrWhiteSpace(frameRate))
            {
                videoArgs += $" -r {frameRate}";
            }

            if (filters.Count > 0)
            {
                videoArgs += " -vf \"" + string.Join(",", filters) + "\"";
            }

            // More audio args

            List<int> selectedAudioList = new List<int>();
            foreach (int checkedIndex in checkedListBoxAudioStreams.CheckedIndices)
            {
                selectedAudioList.Add(checkedIndex);
            }

            if (selectedAudioList.Count == 0)
            {
                audioArgs = "-an";
            }
            else
            {
                int audioIndex = 0;
                foreach (AudioStream audioStream in videoFile.AudioStreams)
                {
                    if (selectedAudioList.Contains(audioIndex))
                    {
                        audioArgs += $" -map 0:{audioStream.Index}";
                    }
                    audioIndex++;
                }
                // resampling
                if (!string.IsNullOrWhiteSpace(audioFrequency))
                {
                    audioArgs += $" -ar {audioFrequency}";
                }
                // channels
                if (!string.IsNullOrWhiteSpace(audioChannels))
                {
                    audioArgs += $" -ac {audioChannels}";
                }
            }

            // More args

            string moreArgs = $"-map_metadata -1 -f {fileType}";

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

        #endregion

        #region Worker

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

            if (passCount > 1)
            {
                toolTipText = string.Format("Выполняется конвертирование (проход {0} из {1})", (passNumber + 1), passCount);
                if (passNumber < (passCount - 1))
                {
                    currentOutputPath = null;
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
                    FFmpegConverter ffmpeg = new FFmpegConverter();

                    ffmpeg.ConvertProgress += (sendertwo, etwo) =>
                    {
                        if (bw.CancellationPending)
                        {
                            if (!ffmpeg.Stop())
                            {
                                ffmpeg.Abort();
                            }
                            e.Cancel = true;
                            return;
                        }

                        int progress = (int)((etwo.Processed.TotalSeconds / videoFile.Duration.TotalSeconds) * 100.0);
                        bw.ReportProgress(progress);
                    };

                    //ffmpeg.LogReceived += (sender3, e3) =>
                    //{
                    //    Console.WriteLine(e3.Data);
                    //};

                    ffmpeg.Convert(inputPath, currentOutputPath, currentPassArguments);
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

                    InOutControlsEnabled(true);

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

                    InOutControlsEnabled(true);

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

            InOutControlsEnabled(false);
            ShowToolTip(toolTipText);
            bw.RunWorkerAsync();
        }

        #endregion

        #region Form helpers

        private void FillComboBoxFrameRate()
        {
            comboBoxFrameRate.Items.Clear();
            comboBoxFrameRate.Items.Add(new ComboBoxItem(string.Empty, "авто"));
            foreach (KeyValuePair<string, string> frameRate in frameRateList)
            {
                comboBoxFrameRate.Items.Add(new ComboBoxItem(frameRate.Key, frameRate.Value));
            }
            comboBoxFrameRate.SelectedIndex = 0;
        }

        private void FillComboBoxAspectRatio(string original = "")
        {
            comboBoxAspectRatio.Text = string.Empty;
            comboBoxAspectRatio.Items.Clear();
            if (!string.IsNullOrWhiteSpace(original))
            {
                comboBoxAspectRatio.Items.Add(new ComboBoxItem(original, "оригинал"));
            }
            foreach (string aspectRatio in aspectRatioList)
            {
                comboBoxAspectRatio.Items.Add(new ComboBoxItem(aspectRatio, aspectRatio));
            }
            if (string.IsNullOrWhiteSpace(original))
            {
                return;
            }
            comboBoxAspectRatio.SelectedIndex = 0;
        }

        private void UpdateHeigth()
        {
            pictureBoxRatioError.BackgroundImage = null;
            int width = Convert.ToInt32(Math.Round(numericUpDownWidth.Value, 0));
            int height = Convert.ToInt32(Math.Round(numericUpDownHeight.Value, 0));
            double aspectRatio = ParseAspectRatio();
            if (aspectRatio > 0.0)
            {
                int newHeight = Convert.ToInt32(Math.Round(width / aspectRatio, 0));
                if (newHeight % 2 == 1)
                    newHeight -= 1;
                bool overHeight = false;
                if (newHeight < 96)
                {
                    newHeight = 96;
                    overHeight = true;
                }
                else if (newHeight > 1080)
                {
                    newHeight = 1080;
                    overHeight = true;
                }
                numericUpDownHeight.Value = newHeight;
                if (!overHeight)
                    return;
                int newWidth = Convert.ToInt32(Math.Round(newHeight * aspectRatio, 0));
                if (newWidth > 1920)
                    newWidth = 1920;
                else if (newWidth < 128)
                    newWidth = 128;
                if (newWidth % 2 == 1)
                    newWidth -= 1;
                numericUpDownWidth.Value = newWidth;
            }
            else if (checkBoxResizePicture.Checked)
            {
                pictureBoxRatioError.BackgroundImage = Properties.Resources.critical;
            }
        }

        private double ParseAspectRatio()
        {
            string input = comboBoxAspectRatio.SelectedIndex < 0 ? comboBoxAspectRatio.Text : ((ComboBoxItem)comboBoxAspectRatio.SelectedItem).Value;
            //Console.WriteLine("SelectedIndex: " + comboBoxAspectRatio.SelectedIndex);
            //Console.WriteLine("Text: " + input);
            Match match = new Regex("^([0-9]+(?:\\.[0-9]+)?)(?::([0-9]+(?:\\.[0-9]+)?))?$", RegexOptions.Singleline).Match(input);
            double ar = 0.0;
            if (match.Success)
            {
                try
                {
                    double arX = Convert.ToDouble(match.Groups[1].Value);
                    double arY = 0.0;
                    if (!string.IsNullOrWhiteSpace(match.Groups[2].Value))
                        arY = Convert.ToDouble(match.Groups[2].Value);
                    if (arY == 0.0)
                        arY = 1.0;
                    double arNew = 0.0;
                    if (arY > 0.0)
                        arNew = arX / arY;
                    ar = arNew;
                }
                catch { }
            }
            return ar;
        }

        private void ShowInfo()
        {
            // {0} - codec name
            // {1} - bit rate (can be empty)
            // {2} - channels
            // {3} - sample rate (can be empty)
            // {4} - language (can be empty)
            string audioChkListTpl = "{0} {1}{2}{3}{4}";

            richTextBoxInfo.Clear();

            List<VideoStream> videoStreams = videoFile.VideoStreams;
            List<AudioStream> audioStreams = videoFile.AudioStreams;

            VideoStream videoStream = videoStreams[0];

            string pictureSize = videoStream.PictureSize.ToString() + (videoStream.UsingDAR ? " (" + videoStream.OriginalSize.ToString("x") + ")" : "");

            List<string> infoList = new List<string>
            {
                "Формат: " + videoFile.Format,
                "Размер файла: " + videoFile.FileSize.ToFileSize(),
                "Длительность: " + (new TimeSpan((long)videoFile.Duration.TotalMilliseconds * 10000L).ToString("hh\\:mm\\:ss")),
                $"Битрейт: {videoFile.BitRate} kbps",
                "Разрешение: " + pictureSize,
                $"Частота кадров: {videoStream.FrameRate} fps",
                "Развертка: " + (videoStream.FieldOrder == "progressive" ? "прогрессивная" : "чересстрочная"),
                "Видеокодек: " + videoStream.CodecName.ToUpper()
            };

            richTextBoxInfo.AppendText(string.Join(Environment.NewLine, infoList));

            // fill audio streams list

            checkedListBoxAudioStreams.Items.Clear();

            string audioBitrate, audioChannels, audioLanguage, audioSampleRate;

            bool isChecked = true;

            foreach (AudioStream audioStream in audioStreams)
            {
                audioBitrate = audioStream.BitRate > 0 ? $"{audioStream.BitRate}kbps " : "";
                audioChannels = $"{audioStream.Channels}ch";
                audioLanguage = string.IsNullOrWhiteSpace(audioStream.Language) || audioStream.Language == "und" ? "" : $" ({audioStream.Language})";
                double.TryParse(audioStream.SampleRate, out double sr);
                audioSampleRate = sr > 0 ? " " + Math.Round(sr / 1000, 1).ToString() + "kHz" : "";

                checkedListBoxAudioStreams.Items.Add(string.Format(
                    audioChkListTpl,
                    //audioStream.Index,
                    audioStream.CodecName.ToUpper(),
                    audioBitrate,
                    audioChannels,
                    audioSampleRate,
                    audioLanguage
                ), isChecked);

                if (isChecked)
                    isChecked = false;
            }
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

        private void InOutControlsEnabled(bool enabled = true)
        {
            textBoxIn.Enabled = enabled;
            textBoxOut.Enabled = enabled;
            buttonBrowseIn.Enabled = enabled;
            buttonBrowseOut.Enabled = enabled;
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

        #endregion
    }
}
