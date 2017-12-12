using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Alexantr.SimpleVideoConverter
{
    public partial class MainForm : Form
    {
        private VideoFile videoFile;

        private char[] invalidChars = Path.GetInvalidPathChars();

        private const string FileTypeMP4 = "mp4";
        private const string FileTypeWebM = "webm";

        private const string EncodeModeBitrate = "bitrate";
        private const string EncodeModeCRF = "crf";

        private const int MinWidth = 128;
        private const int MaxWidth = 1920;

        private const int MinHeight = 96;
        private const int MaxHeight = 1080;

        private const int MinBitrate = 100;
        private const int MaxBitrate = 50000;

        private const int MinAudioBitrate = 8;
        private const int MaxAudioBitrate = 320;

        private string fileType; // mp4 or webm
        private string encodeMode; // bitrate or crf

        private Dictionary<string, string> frameRateList;

        private Dictionary<string, string> fieldOrderList;

        private List<string> aspectRatioList;

        private List<string> audioBitRateList;
        private List<string> frequencyList;
        private Dictionary<string, string> channelsList;

        private List<string> tempFilesList;

        private bool doNotCheckKeepARAgain;

        private TaskbarManager taskbarManager;

        #region Main Form

        public MainForm()
        {
            InitializeComponent();

            tempFilesList = new List<string>();

            AllowDrop = true;
            DragEnter += HandleDragEnter;
            DragDrop += HandleDragDrop;

            taskbarManager = TaskbarManager.Instance;

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
                { "1", "1 (моно)" },
                { "2", "2 (стерео)" }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonGo.Enabled = false;

            if (Properties.Settings.Default.RememberOutPath)
            {
                checkBoxKeepOutPath.Checked = true;
            }

            // Format: 0 - mp4, 1 - webm
            comboBoxFileType.Items.Clear();
            comboBoxFileType.Items.Add(new ComboBoxItem(FileTypeMP4, "MP4"));
            comboBoxFileType.Items.Add(new ComboBoxItem(FileTypeWebM, "WebM"));
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

            // Encode mode: 0 - crf, 1 - bitrate
            comboBoxEncodeMode.Items.Clear();
            comboBoxEncodeMode.Items.Add(new ComboBoxItem(EncodeModeCRF, "CRF"));
            comboBoxEncodeMode.Items.Add(new ComboBoxItem(EncodeModeBitrate, "Битрейт"));
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.EncodeMode) && Properties.Settings.Default.EncodeMode == EncodeModeBitrate)
            {
                comboBoxEncodeMode.SelectedIndex = 1;
                encodeMode = EncodeModeBitrate;
            }
            else
            {
                comboBoxEncodeMode.SelectedIndex = 0;
                encodeMode = EncodeModeCRF;
            }

            // Frame rate
            FillComboBoxFrameRate();

            // Field order
            comboBoxFieldOrder.Items.Clear();
            comboBoxFieldOrder.Items.Add(new ComboBoxItem(string.Empty, "Авто"));
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
            comboBoxFrequency.Items.Add(new ComboBoxItem(string.Empty, "Исходная"));
            foreach (string frq in frequencyList)
            {
                comboBoxFrequency.Items.Add(new ComboBoxItem(frq, frq));
            }
            comboBoxFrequency.SelectedIndex = 0;

            // Channels
            comboBoxChannels.Items.Clear();
            comboBoxChannels.Items.Add(new ComboBoxItem(string.Empty, "Исходное"));
            foreach (KeyValuePair<string, string> kvp in channelsList)
            {
                comboBoxChannels.Items.Add(new ComboBoxItem(kvp.Key, kvp.Value));
            }
            comboBoxChannels.SelectedIndex = 0;

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
            Properties.Settings.Default.Save();

            foreach (string tempFile in tempFilesList)
            {
                File.Delete(tempFile);
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

        #region Format, Mode

        private void comboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileType = ((ComboBoxItem)comboBoxFileType.SelectedItem).Value;
            Properties.Settings.Default.OutFileType = fileType;
            ChangeOutExtension();
            if (encodeMode == EncodeModeCRF)
            {
                int maxValue = (fileType == FileTypeMP4) ? 51 : 63;
                if (numericUpDownBitrate.Value > maxValue)
                    numericUpDownBitrate.Value = maxValue;
                numericUpDownBitrate.Maximum = maxValue;
                numericUpDownBitrate.Value = (fileType == FileTypeMP4) ? 20 : 30;
            }
        }

        private void comboBoxEncodeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            encodeMode = ((ComboBoxItem)comboBoxEncodeMode.SelectedItem).Value;
            Properties.Settings.Default.EncodeMode = encodeMode;
            if (encodeMode == EncodeModeBitrate)
            {
                labelBitrate.Text = "Битрейт (кбит/с)";
                // set min to 0 - prevent exception
                numericUpDownBitrate.Minimum = 0;
                numericUpDownBitrate.Value = 0;
                numericUpDownBitrate.DecimalPlaces = 0;
                // set values
                numericUpDownBitrate.Maximum = 50000;
                numericUpDownBitrate.Value = 1000;
                numericUpDownBitrate.Minimum = 100;
                numericUpDownBitrate.Increment = 10;
            }
            else
            {
                labelBitrate.Text = "CRF";
                // set min to 0 - prevent exception
                numericUpDownBitrate.Minimum = 0;
                numericUpDownBitrate.Value = 0;
                numericUpDownBitrate.DecimalPlaces = 1;
                // set values
                numericUpDownBitrate.Maximum = (fileType == FileTypeMP4) ? 51 : 63;
                numericUpDownBitrate.Value = (fileType == FileTypeMP4) ? 20 : 30;
                numericUpDownBitrate.Increment = 1;
            }
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
            int value = (int)Math.Round(numericUpDownWidth.Value, 0);
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
            richTextBoxInfo.Clear();

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
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            Properties.Settings.Default.InPath = Path.GetDirectoryName(path);

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

            // fill audio streams
            FillAudioStreams();

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

            string input = Path.GetFullPath(videoFile.FullPath);
            string output = !string.IsNullOrWhiteSpace(textBoxOut.Text) ? Path.GetFullPath(textBoxOut.Text) : "";

            ValidateOutputFile(output);

            if (input.Equals(output, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Пути не должны совпадать!");
            }

            int width = (int)Math.Round(numericUpDownWidth.Value, 0);
            int height = (int)Math.Round(numericUpDownHeight.Value, 0);

            decimal videoBitrateOrCrf = Math.Round(numericUpDownBitrate.Value, 1);
            string frameRate = ((ComboBoxItem)comboBoxFrameRate.SelectedItem).Value;
            string fieldOrder = ((ComboBoxItem)comboBoxFieldOrder.SelectedItem).Value;

            int.TryParse(((ComboBoxItem)comboBoxAudioBitrate.SelectedItem).Value, out int audioBitrate);
            string audioChannels = ((ComboBoxItem)comboBoxChannels.SelectedItem).Value;
            string audioFrequency = ((ComboBoxItem)comboBoxFrequency.SelectedItem).Value;

            int videoBitrate = 1000;

            if (width < MinWidth || width > MaxWidth || height < MinHeight || height > MaxHeight || width % 2 == 1 || height % 2 == 1)
            {
                throw new Exception("Неверно задано разрешение видео!");
            }

            if (encodeMode == EncodeModeBitrate)
            {
                videoBitrate = (int)Math.Round(videoBitrateOrCrf, 0);
                if (videoBitrate < MinBitrate || videoBitrate > MaxBitrate)
                {
                    throw new Exception("Неверно задано значение битрейта для видео!");
                }
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

            bool twoPass = (encodeMode == EncodeModeBitrate);

            string videoArgs;
            string audioArgs;

            // Video and audio args

            if (fileType == FileTypeMP4)
            {
                // https://trac.ffmpeg.org/wiki/Encode/H.264

                string videoCodec = "libx264";
                string audioCodec = "aac";

                // must be configurable
                string videoPreset = "slow";
                string videoProfile = "high"; // or "main" and more
                string videoLevel = "4.1"; // or "3.1" and more
                string videoParams = "-fast-pskip 0 -mbtree 0 -pix_fmt yuv420p -movflags +faststart";

                string moreVideoArgs = string.Format("-preset:v {0} -profile:v {1} -level {2} {3}", videoPreset, videoProfile, videoLevel, videoParams);
                string moreAudioArgs = "-strict -2"; // for "aac" codec

                if (encodeMode == EncodeModeBitrate)
                {
                    videoArgs = $"-c:v {videoCodec} -b:v {videoBitrate}k {moreVideoArgs}";
                }
                else
                {
                    videoArgs = $"-c:v {videoCodec} -crf {videoBitrateOrCrf} {moreVideoArgs}";
                }
                audioArgs = $"-c:a {audioCodec} -b:a {audioBitrate}k {moreAudioArgs}";
            }
            else if (fileType == FileTypeWebM)
            {
                // https://trac.ffmpeg.org/wiki/Encode/VP9
                // https://trac.ffmpeg.org/wiki/Encode/VP8

                string videoCodec = "libvpx-vp9"; // "libvpx" or "libvpx-vp9"
                string audioCodec = "libopus"; // "libvorbis" or "libopus"

                if (encodeMode == EncodeModeBitrate)
                {
                    videoArgs = $"-c:v {videoCodec} -b:v {videoBitrate}k";
                }
                else
                {
                    videoArgs = $"-c:v {videoCodec} -crf {videoBitrateOrCrf} -b:v 0";
                }
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

            string[] arguments;

            if (twoPass)
            {
                // {0} is video args
                // {1} is audio args
                // {2} is more args
                // {4} is pass args
                string template = "{3} {0} {1} {2}";

                string passlogfile = GetTempLogFile();

                // {0} is pass number (1 or 2)
                // {1} is the prefix for the pass .log file
                string passArgsTemplate = "-pass {0} -passlogfile \"{1}\"";

                arguments = new string[2];
                arguments[0] = string.Format(template, videoArgs, "-an", moreArgs, string.Format(passArgsTemplate, 1, passlogfile));
                arguments[1] = string.Format(template, videoArgs, audioArgs, moreArgs, string.Format(passArgsTemplate, 2, passlogfile));
            }
            else
            {
                // {0} is video args
                // {1} is audio args
                // {2} is more args
                string argsTemplate = "{0} {1} {2}";

                arguments = new string[1];
                arguments[0] = string.Format(argsTemplate, videoArgs, audioArgs, moreArgs);
            }

            new ConverterForm(input, output, arguments, videoFile.Duration.TotalSeconds).ShowDialog(this);
        }

        private void FillComboBoxFrameRate()
        {
            comboBoxFrameRate.Items.Clear();
            comboBoxFrameRate.Items.Add(new ComboBoxItem(string.Empty, "Исходная"));
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
                comboBoxAspectRatio.Items.Add(new ComboBoxItem(original, "Исходные"));
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
            int width = (int)Math.Round(numericUpDownWidth.Value, 0);
            int height = (int)Math.Round(numericUpDownHeight.Value, 0);
            double aspectRatio = ParseAspectRatio();
            if (aspectRatio > 0.0)
            {
                int newHeight = (int)Math.Round(width / aspectRatio, 0);
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
                if (overHeight)
                {
                    int newWidth = (int)Math.Round(newHeight * aspectRatio, 0);
                    if (newWidth > 1920)
                        newWidth = 1920;
                    else if (newWidth < 128)
                        newWidth = 128;
                    if (newWidth % 2 == 1)
                        newWidth -= 1;
                    numericUpDownWidth.Value = newWidth;
                }
            }
            else if (checkBoxResizePicture.Checked && checkBoxKeepAspectRatio.Checked)
            {
                pictureBoxRatioError.BackgroundImage = Properties.Resources.critical;
            }
        }

        private double ParseAspectRatio()
        {
            string input = comboBoxAspectRatio.SelectedIndex < 0 ? comboBoxAspectRatio.Text : ((ComboBoxItem)comboBoxAspectRatio.SelectedItem).Value;
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
            VideoStream stream = videoFile.VideoStreams[0];

            StringBuilder info = new StringBuilder();

            info.AppendLine("Формат: " + videoFile.Format);
            info.AppendLine("Размер файла: " + Utility.FormatFileSize(videoFile.FileSize));
            info.AppendLine("Длительность: " + (new TimeSpan((long)videoFile.Duration.TotalMilliseconds * 10000L).ToString("hh\\:mm\\:ss")));
            info.AppendLine("Битрейт: " + videoFile.BitRate + " kbps");
            info.AppendLine("Разрешение: " + (stream.PictureSize.ToString() + (stream.UsingDAR ? " (" + stream.OriginalSize.ToString() + ")" : "")));
            info.AppendLine("Частота кадров: " + stream.FrameRate + " fps");
            info.AppendLine("Развертка: " + (stream.FieldOrder == "progressive" ? "прогрессивная" : "чересстрочная"));
            info.AppendLine("Видеокодек: " + stream.CodecName.ToUpper());

            richTextBoxInfo.Clear();
            richTextBoxInfo.AppendText(info.ToString().TrimEnd());
        }

        private void FillAudioStreams()
        {
            checkedListBoxAudioStreams.Items.Clear();

            bool isChecked = true;

            foreach (AudioStream stream in videoFile.AudioStreams)
            {
                double.TryParse(stream.SampleRate, out double sr);

                StringBuilder audio = new StringBuilder();

                audio.Append(stream.CodecName.ToUpper());
                if (stream.BitRate > 0)
                    audio.Append($" {stream.BitRate}kbps");
                audio.Append($" {stream.Channels}ch");
                if (sr > 0)
                    audio.Append(" " + Math.Round(sr / 1000, 1).ToString() + "kHz");
                if (!string.IsNullOrWhiteSpace(stream.Language) && stream.Language != "und")
                    audio.Append($" ({stream.Language})");

                checkedListBoxAudioStreams.Items.Add(audio.ToString(), isChecked);

                if (isChecked)
                    isChecked = false;
            }
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
            string tempLogFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            string tempLogFileRealName = $"{tempLogFile}-{streamIndex}.log";
            string tempLogMbtreeFileRealName = $"{tempLogFile}-{streamIndex}.log.mbtree";
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
