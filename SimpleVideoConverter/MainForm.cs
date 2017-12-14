using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private const int DefaultBitrate = 2000;

        private const int MinAudioBitrate = 8;
        private const int MaxAudioBitrate = 320;

        private string fileType; // mp4 or webm
        private string encodeMode; // bitrate or crf

        private string fileInfo;

        private Dictionary<string, string> frameRateList;

        private Dictionary<string, string> resizePresetList;

        private List<string> aspectRatioList;
        private Dictionary<string, string> scalingAlgorithmList;

        private Dictionary<string, string> fieldOrderList;

        private Dictionary<string, string> colorFilterList;

        private PictureSize cropSize;

        private List<string> audioBitRateList;
        private List<string> frequencyList;
        private Dictionary<string, string> channelsList;

        private List<string> tempFilesList;

        private bool doNotCheckKeepARAgain;

        private TaskbarManager taskbarManager;

        private string formTitle;

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

            // see https://superuser.com/questions/375718/which-resize-algorithm-to-choose-for-videos
            // see http://www.thnsolutions.com/technology/sunfire/graphic/image.html
            // need to create window with image
            scalingAlgorithmList = new Dictionary<string, string>
            {
                { "neighbor", "Nearest Neighbor" },
                { "bilinear", "Bilinear" },
                { "bicubic", "Bicubic" },
                //{ "spline", "Spline" },
                { "lanczos", "Lanczos" },
                { "sinc", "Sinc" },
                { "gauss", "Gaussian" },
            };

            resizePresetList = new Dictionary<string, string>
            {
                { "1920x1080", "1080p" },
                { "1280x720", "720p" },
                { "1024x576", "576p" },
                { "854x480", "480p" },
                { "640x360", "360p" }
            };

            colorFilterList = new Dictionary<string, string>
            {
                { "gray", "Черно-белое" },
                { "sepia", "Сепия" }
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
            formTitle = Text;

            buttonGo.Enabled = false;
            buttonShowInfo.Enabled = false;
            buttonOpenInputFile.Enabled = false;

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

            // Encode mode
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.EncodeMode) && Properties.Settings.Default.EncodeMode == EncodeModeBitrate)
            {
                radioButtonBitrate.Checked = true;
                radioButtonCRF.Checked = false;
            }
            else
            {
                radioButtonCRF.Checked = true;
                radioButtonBitrate.Checked = false;
            }
            CheckVideoModeRadioButtons();

            // Bitrate
            numericUpDownBitrate.Maximum = MaxBitrate;
            numericUpDownBitrate.Value = DefaultBitrate;
            numericUpDownBitrate.Minimum = MinBitrate;
            numericUpDownBitrate.Increment = 10;

            CalcFileSize(); // just hide labels

            // Frame rate
            comboBoxFrameRate.Items.Clear();
            comboBoxFrameRate.Items.Add(new ComboBoxItem(string.Empty, "Исходная"));
            foreach (KeyValuePair<string, string> frameRate in frameRateList)
            {
                comboBoxFrameRate.Items.Add(new ComboBoxItem(frameRate.Key, frameRate.Value));
            }
            comboBoxFrameRate.SelectedIndex = 0;

            // Field order
            comboBoxFieldOrder.Items.Clear();
            comboBoxFieldOrder.Items.Add(new ComboBoxItem(string.Empty, "Авто"));
            foreach (KeyValuePair<string, string> fieldOrder in fieldOrderList)
            {
                comboBoxFieldOrder.Items.Add(new ComboBoxItem(fieldOrder.Key, fieldOrder.Value));
            }
            comboBoxFieldOrder.SelectedIndex = 0;

            ManageCheckPanel(checkBoxDeinterlace, panelDeinterlace);

            // Resize picture
            ManageCheckPanel(checkBoxResizePicture, panelResolution);

            // Resize presets
            FillComboBoxResizePreset(true);

            // Aspect ratio
            FillComboBoxAspectRatio("");

            // Scaling algorithm
            int selectedScalingAlgorithm = 0, indexScalingAlgorithm = 0;
            comboBoxResizeMethod.Items.Clear();
            foreach (KeyValuePair<string, string> scm in scalingAlgorithmList)
            {
                comboBoxResizeMethod.Items.Add(new ComboBoxItem(scm.Key, scm.Value));
                if (scm.Key == "lanczos")
                    selectedScalingAlgorithm = indexScalingAlgorithm;
                indexScalingAlgorithm++;
            }
            comboBoxResizeMethod.SelectedIndex = selectedScalingAlgorithm;

            // Color filter
            comboBoxColorFilter.Items.Clear();
            comboBoxColorFilter.Items.Add(new ComboBoxItem(string.Empty, "Нет"));
            foreach (KeyValuePair<string, string> cf in colorFilterList)
            {
                comboBoxColorFilter.Items.Add(new ComboBoxItem(cf.Key, cf.Value));
            }
            comboBoxColorFilter.SelectedIndex = 0;

            // Keep aspect ratio
            comboBoxAspectRatio.Enabled = checkBoxKeepAspectRatio.Checked;

            labelCropSize.Text = "";
            cropSize = new PictureSize();

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

            checkBoxKeepOutPath.Checked = Properties.Settings.Default.RememberOutPath;

            ShowHideTabs();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                SetFile(commandLineArgs[1]);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.RememberOutPath = checkBoxKeepOutPath.Checked;

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

        private void buttonShowInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, fileInfo, "Информация о файле", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonOpenInputFile_Click(object sender, EventArgs e)
        {
            if (!File.Exists(videoFile.FullPath))
            {
                MessageBox.Show("Исходный файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Process.Start(videoFile.FullPath);
            }
        }

        #endregion

        #region Format, Mode, CRF, Bitrate

        private void comboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileType = ((ComboBoxItem)comboBoxFileType.SelectedItem).Value;
            Properties.Settings.Default.OutFileType = fileType;
            ChangeOutExtension();
            int maxValue = (fileType == FileTypeMP4) ? 51 : 63;
            if (trackBarCRF.Value > maxValue)
                trackBarCRF.Value = maxValue;
            trackBarCRF.Maximum = maxValue;
            trackBarCRF.Value = (fileType == FileTypeMP4) ? 23 : 35;
        }

        private void radioButtonCRF_CheckedChanged(object sender, EventArgs e)
        {
            CheckVideoModeRadioButtons();
            CalcFileSize();
        }

        private void radioButtonBitrate_CheckedChanged(object sender, EventArgs e)
        {
            CheckVideoModeRadioButtons();
            CalcFileSize();
        }

        private void trackBarCRF_ValueChanged(object sender, EventArgs e)
        {
            var crf = trackBarCRF.Value;
            labelCRF.Text = $"{crf}";
        }

        private void numericUpDownBitrate_ValueChanged(object sender, EventArgs e)
        {
            CalcFileSize();
        }

        #endregion

        #region Deinterlace

        private void checkBoxDeinterlace_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckPanel(checkBoxDeinterlace, panelDeinterlace);
        }

        #endregion

        #region Resize

        private void checkBoxResizePicture_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckPanel(checkBoxResizePicture, panelResolution);
            UpdateHeigth();
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            UpdateHeigth();
        }

        private void numericUpDownWidth_Leave(object sender, EventArgs e)
        {
            if ((int)numericUpDownWidth.Value % 2 == 1)
                numericUpDownWidth.Value = Math.Max(MinWidth, (int)numericUpDownWidth.Value - 1);
            UpdateHeigth();
        }

        private void numericUpDownHeight_Leave(object sender, EventArgs e)
        {
            if ((int)numericUpDownHeight.Value % 2 == 1)
                numericUpDownHeight.Value = Math.Max(MinHeight, (int)numericUpDownHeight.Value - 1);
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

        private void comboBoxResizePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoFile == null)
                return;
            string size = ((ComboBoxItem)comboBoxResizePreset.SelectedItem).Value;
            if (string.IsNullOrWhiteSpace(size))
            {
                int w = cropSize.Width;
                ResizeFromPreset(w, 0);
            }
            else
            {
                string[] wh = size.Split('x');
                if (wh.Length == 2)
                {
                    int.TryParse(wh[0], out int w);
                    int.TryParse(wh[1], out int h);
                    if (w > 0 && h > 0)
                        ResizeFromPreset(w, h);
                }
            }
            // force reset
            FillComboBoxResizePreset();
        }

        #endregion

        #region Crop

        private void numericCropTop_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropTop.Value % 2 == 1)
                numericCropTop.Value = Math.Max(0, (int)numericCropTop.Value - 1);
            RecalcOriginalAspectRatio();
            UpdateHeigth();
        }

        private void numericCropLeft_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropLeft.Value % 2 == 1)
                numericCropLeft.Value = Math.Max(0, (int)numericCropLeft.Value - 1);
            RecalcOriginalAspectRatio();
            UpdateHeigth();
        }

        private void numericCropRight_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropRight.Value % 2 == 1)
                numericCropRight.Value = Math.Max(0, (int)numericCropRight.Value - 1);
            RecalcOriginalAspectRatio();
            UpdateHeigth();
        }

        private void numericCropBottom_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropBottom.Value % 2 == 1)
                numericCropBottom.Value = Math.Max(0, (int)numericCropBottom.Value - 1);
            RecalcOriginalAspectRatio();
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
            CalcFileSize();
        }

        private void checkedListBoxAudioStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> selectedAudioList = new List<int>();
            foreach (int checkedIndex in checkedListBoxAudioStreams.CheckedIndices)
            {
                selectedAudioList.Add(checkedIndex);
            }
            panelAudioParams.Enabled = selectedAudioList.Count > 0;
            CalcFileSize();
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

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            Assembly ass = Assembly.GetExecutingAssembly();

            string appName = ((AssemblyTitleAttribute)ass.GetCustomAttribute(typeof(AssemblyTitleAttribute))).Title;

            Version version = ass.GetName().Version;
            string niceVersion = version.Major.ToString() + "." + version.Minor.ToString();
            if (version.Build != 0 || version.Revision != 0)
            {
                niceVersion += "." + version.Build.ToString();
            }
            if (version.Revision != 0)
            {
                niceVersion += "." + version.Revision.ToString();
            }

            string whatBits = Environment.Is64BitProcess ? "64" : "32";

            string copyright = ((AssemblyCopyrightAttribute)ass.GetCustomAttribute(typeof(AssemblyCopyrightAttribute))).Copyright;

            MessageBox.Show(this, $"{appName} v{niceVersion} ({whatBits} bit){Environment.NewLine}{copyright}", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Functions

        private void ShowHideTabs()
        {
            if (videoFile == null)
            {
                tabPagePicture.Parent = null;
                tabPageFilters.Parent = null;
                tabPageVideo.Parent = null;
                tabPageAudio.Parent = null;
            }
            else
            {
                tabPagePicture.Parent = tabControlMain;
                tabPageFilters.Parent = tabControlMain;
                tabPageVideo.Parent = tabControlMain;
                tabPageAudio.Parent = tabControlMain;
            }
        }

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
            try
            {
                ValidateInputFile(path);
                videoFile = new VideoFile(path);
                videoFile.Probe();
            }
            catch (Exception ex)
            {
                videoFile = null;
                textBoxIn.Text = "Файл не выбран";
                textBoxOut.Text = "";
                buttonGo.Enabled = false;
                buttonShowInfo.Enabled = false;
                buttonOpenInputFile.Enabled = false;
                labelCropSize.Text = "";
                cropSize.Width = 0;
                cropSize.Height = 0;
                CalcFileSize();
                ShowHideTabs();
                Text = formTitle;
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            ShowHideTabs();

            Text = Path.GetFileName(path) + " - " + formTitle;

            textBoxIn.Text = path;

            Properties.Settings.Default.InPath = Path.GetDirectoryName(path);

            VideoStream vStream = videoFile.VideoStreams[0];

            // set original aspect ratio
            string original = "";
            if (vStream.PictureSize.Width > 0 && vStream.PictureSize.Height > 0)
            {
                original = $"{vStream.PictureSize.Width}:{vStream.PictureSize.Height}";
            }
            FillComboBoxAspectRatio(original);
            checkBoxKeepAspectRatio.Checked = !doNotCheckKeepARAgain && !string.IsNullOrWhiteSpace(original);

            cropSize.Width = vStream.PictureSize.Width;
            cropSize.Height = vStream.PictureSize.Height;

            // Update values for crop
            int wCrop = vStream.PictureSize.Width;
            int hCrop = vStream.PictureSize.Height;
            decimal maxLeft = (wCrop - MinWidth) / 2;
            decimal maxTop = (hCrop - MinHeight) / 2;
            // set max values to prevent exceptions
            numericCropTop.Maximum = maxTop;
            numericCropBottom.Maximum = maxTop;
            numericCropLeft.Maximum = maxLeft;
            numericCropRight.Maximum = maxLeft;
            // reset values
            numericCropTop.Value = 0;
            numericCropBottom.Value = 0;
            numericCropLeft.Value = 0;
            numericCropRight.Value = 0;

            // if need resize
            bool needResize = false;
            int w = vStream.PictureSize.Width;
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
            if (needResize)
                checkBoxResizePicture.Checked = true;
            checkBoxResizePicture.Enabled = !needResize;
            checkBoxKeepAspectRatio.Checked = true;
            UpdateHeigth();

            // if need deinterlace
            checkBoxDeinterlace.Checked = vStream.FieldOrder != "progressive";
            comboBoxFieldOrder.SelectedIndex = 0;
            comboBoxFrameRate.SelectedIndex = 0;

            // has audio
            panelAudioParams.Enabled = videoFile.AudioStreams.Count > 0;

            // fill audio streams
            FillAudioStreams();

            // show info
            SetInfo();

            CalcFileSize();

            buttonGo.Enabled = true;
            buttonShowInfo.Enabled = true;
            buttonOpenInputFile.Enabled = true;

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

            string resizeMethod = ((ComboBoxItem)comboBoxResizeMethod.SelectedItem).Value;
            string colorFilter = ((ComboBoxItem)comboBoxColorFilter.SelectedItem).Value;
            string fieldOrder = ((ComboBoxItem)comboBoxFieldOrder.SelectedItem).Value;
            string frameRate = ((ComboBoxItem)comboBoxFrameRate.SelectedItem).Value;

            int.TryParse(((ComboBoxItem)comboBoxAudioBitrate.SelectedItem).Value, out int audioBitrate);
            string audioChannels = ((ComboBoxItem)comboBoxChannels.SelectedItem).Value;
            string audioFrequency = ((ComboBoxItem)comboBoxFrequency.SelectedItem).Value;
            
            int videoBitrate = (int)Math.Round(numericUpDownBitrate.Value, 0);
            int crf = trackBarCRF.Value;

            if (width < MinWidth || width > MaxWidth || height < MinHeight || height > MaxHeight || width % 2 == 1 || height % 2 == 1)
            {
                throw new Exception("Неверно задано разрешение видео!");
            }

            if (encodeMode == EncodeModeBitrate)
            {
                if (videoBitrate < MinBitrate || videoBitrate > MaxBitrate)
                {
                    throw new Exception("Неверно задано значение битрейта для видео!");
                }
            }
            if (encodeMode == EncodeModeCRF)
            {
                int maxCrfValue = (fileType == FileTypeMP4) ? 51 : 63;
                if (crf < 0 || crf > maxCrfValue)
                {
                    throw new Exception("Неверно задано значение CRF!");
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
                    videoArgs = $"-c:v {videoCodec} -crf {crf} {moreVideoArgs}";
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
                    videoArgs = $"-c:v {videoCodec} -crf {crf} -b:v 0";
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

            if (numericCropTop.Value > 0 || numericCropBottom.Value > 0 || numericCropLeft.Value > 0 || numericCropRight.Value > 0)
            {
                int origW = videoFile.VideoStreams[0].PictureSize.Width;
                int origH = videoFile.VideoStreams[0].PictureSize.Height;
                int cropW = origW - (int)Math.Round(numericCropLeft.Value + numericCropRight.Value, 0);
                int cropH = origH - (int)Math.Round(numericCropTop.Value + numericCropBottom.Value, 0);
                int cropX = (int)Math.Round(numericCropLeft.Value, 0);
                int cropY = (int)Math.Round(numericCropTop.Value, 0);
                filters.Add($"crop={cropW}:{cropH}:{cropX}:{cropY}");
            }

            if (checkBoxResizePicture.Checked)
            {
                // https://www.ffmpeg.org/ffmpeg-scaler.html#sws_005fflags
                filters.Add($"scale={width}x{height}:flags={resizeMethod},setsar=1:1");
            }

            if (colorFilter == "gray")
                filters.Add($"colorchannelmixer=.3:.4:.3:0:.3:.4:.3:0:.3:.4:.3");
            else if (colorFilter == "sepia")
                filters.Add($"colorchannelmixer=.393:.769:.189:0:.349:.686:.168:0:.272:.534:.131");

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

        private void FillComboBoxAspectRatio(string original = "")
        {
            int prevIndex = comboBoxAspectRatio.SelectedIndex;
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
            comboBoxAspectRatio.SelectedIndex = prevIndex > 0 ? prevIndex : 0;
        }

        private void FillComboBoxResizePreset(bool initial = false)
        {
            if (comboBoxResizePreset.SelectedIndex == -1 && !initial)
                return;
            comboBoxResizePreset.Items.Clear();
            comboBoxResizePreset.Items.Add(new ComboBoxItem(string.Empty, "Оригинал"));
            foreach (KeyValuePair<string, string> resPres in resizePresetList)
            {
                comboBoxResizePreset.Items.Add(new ComboBoxItem(resPres.Key, resPres.Value));
            }
        }

        private void FillAudioStreams()
        {
            checkedListBoxAudioStreams.Items.Clear();

            if (videoFile.AudioStreams.Count == 0)
            {
                tabPageAudio.Parent = null;
                return;
            }
            else
            {
                tabPageAudio.Parent = tabControlMain;
            }

            bool isChecked = true;

            foreach (AudioStream stream in videoFile.AudioStreams)
            {
                StringBuilder audio = new StringBuilder();

                audio.Append(stream.CodecName.ToUpper());
                if (stream.BitRate > 0)
                    audio.Append($" {stream.BitRate}kbps");
                if (!string.IsNullOrWhiteSpace(stream.ChannelLayout))
                    audio.Append($" {stream.ChannelLayout}");
                else
                    audio.Append($" {stream.Channels}ch");
                if (!string.IsNullOrWhiteSpace(stream.SampleRate))
                    audio.Append($" {stream.SampleRate}Hz");
                if (!string.IsNullOrWhiteSpace(stream.Language) && stream.Language != "und")
                    audio.Append($" ({stream.Language})");

                checkedListBoxAudioStreams.Items.Add(audio.ToString(), isChecked);

                if (isChecked)
                    isChecked = false;
            }
        }

        private void ResizeFromPreset(int w, int h = 0)
        {
            if (w > MaxWidth)
                w = MaxWidth;
            if (w < MinWidth)
                w = MinWidth;
            numericUpDownWidth.Value = w;

            if (h > 0)
                UpdateHeigth(true, h);
            else
                UpdateHeigth(true);
        }

        private void UpdateHeigth(bool forceUpdateHeight = false, int maxHeight = MaxHeight)
        {
            pictureBoxRatioError.BackgroundImage = null;
            int width = (int)Math.Round(numericUpDownWidth.Value, 0);
            int height = (int)Math.Round(numericUpDownHeight.Value, 0);
            double aspectRatio = ParseAspectRatio();
            if (aspectRatio > 0.0 && (checkBoxKeepAspectRatio.Checked || forceUpdateHeight))
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
                else if (newHeight > maxHeight)
                {
                    newHeight = maxHeight;
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

        private void RecalcOriginalAspectRatio()
        {
            if (videoFile == null)
                return;
            VideoStream stream = videoFile.VideoStreams[0];
            int newW = stream.PictureSize.Width;
            int newH = stream.PictureSize.Height;
            if (numericCropTop.Value > 0 || numericCropBottom.Value > 0 || numericCropLeft.Value > 0 || numericCropRight.Value > 0)
            {
                newW = stream.PictureSize.Width - (int)Math.Round(numericCropLeft.Value + numericCropRight.Value, 0);
                newH = stream.PictureSize.Height - (int)Math.Round(numericCropTop.Value + numericCropBottom.Value, 0);
                cropSize.Width = newW;
                cropSize.Height = newH;
                // show size changes
                labelCropSize.Text = $"{stream.PictureSize.ToString()} → {cropSize.ToString()}";
            }
            else
            {
                cropSize.Width = stream.PictureSize.Width;
                cropSize.Height = stream.PictureSize.Height;
                labelCropSize.Text = "";
            }
            // set original aspect ratio
            string original = "";
            if (newW > 0 && newH > 0)
            {
                original = $"{newW}:{newH}";
            }
            FillComboBoxAspectRatio(original);
        }

        private void CheckVideoModeRadioButtons()
        {
            trackBarCRF.Enabled = radioButtonCRF.Checked;
            labelMaxQ.Enabled = radioButtonCRF.Checked;
            labelMinQ.Enabled = radioButtonCRF.Checked;

            numericUpDownBitrate.Enabled = radioButtonBitrate.Checked;
            labelVideoKbps.Enabled = radioButtonBitrate.Checked;

            if (radioButtonCRF.Checked)
            {
                Properties.Settings.Default.EncodeMode = encodeMode = EncodeModeCRF;
            }

            if (radioButtonBitrate.Checked)
            {
                Properties.Settings.Default.EncodeMode = encodeMode = EncodeModeBitrate;
            }
        }

        private void CalcFileSize()
        {
            if (videoFile == null || !radioButtonBitrate.Checked)
            {
                labelCalcSize.Text = "-";
                labelCalcSize.Visible = false;
                labelCalcSizeText.Visible = false;
                return;
            }

            labelCalcSize.Visible = true;
            labelCalcSizeText.Visible = true;

            double duration = videoFile.Duration.TotalMilliseconds / 1000;

            List<int> selectedAudioList = new List<int>();
            foreach (int checkedIndex in checkedListBoxAudioStreams.CheckedIndices)
            {
                selectedAudioList.Add(checkedIndex);
            }

            int.TryParse(((ComboBoxItem)comboBoxAudioBitrate.SelectedItem).Value, out int audioBitrate);
            int videoBitrate = (int)Math.Round(numericUpDownBitrate.Value, 0);

            double fileSize = (videoBitrate * duration / 8.0 + audioBitrate * duration * selectedAudioList.Count / 8.0) / 1024.0; // MiB

            string sizeString;
            if (fileSize >= 1)
                sizeString = $"~{Math.Round(fileSize, 0)} МБ";
            else
                sizeString = "меньше 1 МБ";

            labelCalcSize.Text = sizeString;
        }

        private void SetInfo()
        {
            VideoStream stream = videoFile.VideoStreams[0];

            StringBuilder info = new StringBuilder();

            string dur = new TimeSpan((long)videoFile.Duration.TotalMilliseconds * 10000L).ToString("hh\\:mm\\:ss\\.fff");

            info.AppendLine($"Формат: {videoFile.Format}");
            info.AppendLine($"Размер файла: {Utility.FormatFileSize(videoFile.FileSize)}");
            info.AppendLine($"Длительность: {dur}");
            info.AppendLine($"Битрейт: {videoFile.BitRate} kbps");
            info.AppendLine($"Разрешение: {stream.PictureSize.ToString()}{(stream.UsingDAR ? " (исх.: " + stream.OriginalSize.ToString() + ")" : "")}");
            info.AppendLine($"Частота кадров: {stream.FrameRate} fps");
            info.AppendLine($"Развертка: {(stream.FieldOrder == "progressive" ? "прогрессивная" : "чересстрочная")}");
            info.AppendLine($"Видеокодек: {stream.CodecName.ToUpper()}");
            info.AppendLine($"Дорожки аудио: {(videoFile.AudioStreams.Count > 0 ? videoFile.AudioStreams.Count.ToString() : "нет")}");

            fileInfo = info.ToString().TrimEnd();
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

        private void ManageCheckPanel(CheckBox chk, Panel panel)
        {
            if (chk.Parent == panel)
            {
                panel.Parent.Controls.Add(chk);
                chk.Location = new Point(chk.Left + panel.Left, chk.Top + panel.Top);
                chk.BringToFront();
            }
            panel.Enabled = chk.Checked;
        }

        #endregion

        private void buttonResizeMethodHelp_Click(object sender, EventArgs e)
        {

        }
    }
}
