﻿using Microsoft.WindowsAPICodePack.Taskbar;
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
        private InputFile inputFile;

        private char[] invalidChars = Path.GetInvalidPathChars();

        // http://dev.beandog.org/x264_preset_reference.html
        // http://www.videorip.info/x264/71-nekotorye-sovety-nastrojki-kodeka-x264-ot-polzovatelej
        // https://forum.videohelp.com/threads/369463-x264-Tweaking-testing-and-comparing-settings
        private const string FileTypeMP4 = "mp4";

        // https://www.webmproject.org/docs/container/
        private const string FileTypeWebM = "webm";

        private const string EncodeModeBitrate = "bitrate";
        private const string EncodeModeCRF = "crf";

        private const int MinBitrate = 100;
        private const int MaxBitrate = 500000;
        private const int DefaultBitrate = 3000;

        private const int DefaultMp4CRF = 20;
        private const int DefaultWebmCRF = 30;

        private const int MinAudioBitrate = 8;
        private const int MaxAudioBitrate = 320;

        private string fileType; // mp4 or webm
        private string encodeMode; // bitrate or crf

        private string fileInfo;

        private string formTitle;

        private TaskbarManager taskbarManager;

        private PictureSize cropPictureSize; // picture size after crop but fixed for sar
        private PictureSize selectedPictureSize; // selected size from comboBoxResizeMethod
        private PictureSize finalPictureSize; // final picture size for video

        // lists

        private List<string> pictureSizeList;

        private Dictionary<string, string> scalingAlgorithmList;

        private Dictionary<string, string> fieldOrderList;

        private Dictionary<string, string> colorFilterList;

        private Dictionary<string, string> frameRateList;

        private List<string> audioBitRateList;
        private List<string> audioFrequencyList;
        private Dictionary<string, string> audioChannelsList;

        private List<string> tempFilesList;

        #region Main Form

        public MainForm()
        {
            InitializeComponent();

            tempFilesList = new List<string>();

            AllowDrop = true;
            DragEnter += HandleDragEnter;
            DragDrop += HandleDragDrop;

            taskbarManager = TaskbarManager.Instance;

            pictureSizeList = new List<string>
            {
                "1920x1080",
                "1280x720",
                "1024x576",
                "854x480",
                "720x540",
                "720x404",
                "640x480",
                "640x360",
                "512x384",
                "320x240",
                "176x144"
            };

            // see https://superuser.com/questions/375718/which-resize-algorithm-to-choose-for-videos
            // see http://www.thnsolutions.com/technology/sunfire/graphic/image.html
            scalingAlgorithmList = new Dictionary<string, string>
            {
                { "neighbor", "Nearest Neighbor" },
                { "bilinear", "Bilinear" },
                { "bicubic", "Bicubic" },
                { "lanczos", "Lanczos" },
                { "sinc", "Sinc" },
                { "gauss", "Gaussian" },
            };

            fieldOrderList = new Dictionary<string, string>
            {
                { "tff", "Top Field First" },
                { "bff", "Bottom Field First" }
            };

            colorFilterList = new Dictionary<string, string>
            {
                { "gray", "Черно-белое" },
                { "sepia", "Сепия" }
            };

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

            audioFrequencyList = new List<string>
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

            audioChannelsList = new Dictionary<string, string>
            {
                { "1", "1 (моно)" },
                { "2", "2 (стерео)" }
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            formTitle = AppendAppVersion(Text);
            Text = formTitle;

            buttonGo.Enabled = false;
            buttonShowInfo.Enabled = false;
            buttonOpenInputFile.Enabled = false;

            checkBoxKeepOutPath.Checked = Properties.Settings.Default.RememberOutPath;

            checkBoxWebOptimized.Checked = true;

            Picture.Init();

            // init crop size
            labelCropSize.Text = "";
            cropPictureSize = new PictureSize
            {
                Width = Picture.MinWidth,
                Height = Picture.MinHeight
            };

            // init new size
            selectedPictureSize = new PictureSize
            {
                Width = Picture.MinWidth,
                Height = Picture.MinHeight
            };

            // init final size
            finalPictureSize = new PictureSize
            {
                Width = Picture.MinWidth,
                Height = Picture.MinHeight
            };

            // Format: 0 - mp4, 1 - webm
            comboBoxFileType.Items.Clear();
            comboBoxFileType.Items.Add(new ComboBoxItem(FileTypeMP4, "MP4"));
            comboBoxFileType.Items.Add(new ComboBoxItem(FileTypeWebM, "WebM"));
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.OutFileType) && Properties.Settings.Default.OutFileType == FileTypeWebM)
            {
                comboBoxFileType.SelectedIndex = 1;
                fileType = FileTypeWebM;
                checkBoxWebOptimized.Visible = false;
            }
            else
            {
                comboBoxFileType.SelectedIndex = 0;
                fileType = FileTypeMP4;
                checkBoxWebOptimized.Visible = true;
                checkBoxWebOptimized.Checked = true;
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

            // Picture Size
            comboBoxPictureSize.Text = string.Empty;
            comboBoxPictureSize.Items.Clear();
            comboBoxPictureSize.Items.Add(new ComboBoxItem(string.Empty, "Не изменять"));
            foreach (string ps in pictureSizeList)
            {
                comboBoxPictureSize.Items.Add(new ComboBoxItem(ps, ps));
            }
            comboBoxPictureSize.SelectedIndex = 0;

            // Resize method
            comboBoxResizeMethod.Items.Clear();
            int selectedResizeMethodIndex = 0, resizeMethodListLength = Picture.ResizeMethodList.GetLength(0);
            for (int i = 0; i < resizeMethodListLength; i++)
            {
                comboBoxResizeMethod.Items.Add(new ComboBoxItem(Picture.ResizeMethodList[i, 0], Picture.ResizeMethodList[i, 1]));
                if (Picture.ResizeMethodList[i, 0] == Picture.ResizeMethod)
                    selectedResizeMethodIndex = i;
            }
            comboBoxResizeMethod.SelectedIndex = selectedResizeMethodIndex;

            // Scaling algorithm
            int selectedScalingAlgorithm = 0, indexScalingAlgorithm = 0;
            comboBoxScalingAlgorithm.Items.Clear();
            foreach (KeyValuePair<string, string> scm in scalingAlgorithmList)
            {
                comboBoxScalingAlgorithm.Items.Add(new ComboBoxItem(scm.Key, scm.Value));
                if (scm.Key == "bicubic")
                    selectedScalingAlgorithm = indexScalingAlgorithm;
                indexScalingAlgorithm++;
            }
            comboBoxScalingAlgorithm.SelectedIndex = selectedScalingAlgorithm;

            // Bitrate
            numericUpDownBitrate.Maximum = MaxBitrate;
            numericUpDownBitrate.Value = DefaultBitrate;
            numericUpDownBitrate.Minimum = MinBitrate;
            numericUpDownBitrate.Increment = 10;

            CalcFileSize(); // just hide labels

            // Field order
            comboBoxFieldOrder.Items.Clear();
            comboBoxFieldOrder.Items.Add(new ComboBoxItem(string.Empty, "Авто"));
            foreach (KeyValuePair<string, string> fieldOrder in fieldOrderList)
            {
                comboBoxFieldOrder.Items.Add(new ComboBoxItem(fieldOrder.Key, fieldOrder.Value));
            }
            comboBoxFieldOrder.SelectedIndex = 0;

            // Deinterlace
            comboBoxFieldOrder.Enabled = checkBoxDeinterlace.Checked;

            // Color filter
            comboBoxColorFilter.Items.Clear();
            comboBoxColorFilter.Items.Add(new ComboBoxItem(string.Empty, "Нет"));
            foreach (KeyValuePair<string, string> cf in colorFilterList)
            {
                comboBoxColorFilter.Items.Add(new ComboBoxItem(cf.Key, cf.Value));
            }
            comboBoxColorFilter.SelectedIndex = 0;

            // Frame rate
            comboBoxFrameRate.Items.Clear();
            comboBoxFrameRate.Items.Add(new ComboBoxItem(string.Empty, "Исходная"));
            foreach (KeyValuePair<string, string> frameRate in frameRateList)
            {
                comboBoxFrameRate.Items.Add(new ComboBoxItem(frameRate.Key, frameRate.Value));
            }
            comboBoxFrameRate.SelectedIndex = 0;

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

            // Audio frequency
            comboBoxAudioFrequency.Items.Clear();
            comboBoxAudioFrequency.Items.Add(new ComboBoxItem(string.Empty, "Исходная"));
            foreach (string frq in audioFrequencyList)
            {
                comboBoxAudioFrequency.Items.Add(new ComboBoxItem(frq, frq));
            }
            comboBoxAudioFrequency.SelectedIndex = 0;

            // Audio channels
            comboBoxAudioChannels.Items.Clear();
            comboBoxAudioChannels.Items.Add(new ComboBoxItem(string.Empty, "Исходное"));
            foreach (KeyValuePair<string, string> kvp in audioChannelsList)
            {
                comboBoxAudioChannels.Items.Add(new ComboBoxItem(kvp.Key, kvp.Value));
            }
            comboBoxAudioChannels.SelectedIndex = 0;

            // Tabs
            ShowHideTabs();

            SetOutputInfo();
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
                try
                {
                    File.Delete(tempFile);
                }
                catch { }
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
            if (!File.Exists(inputFile.FullPath))
            {
                MessageBox.Show("Исходный файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Process.Start(inputFile.FullPath);
            }
        }

        #endregion

        #region Format, Mode, CRF, Bitrate, FPS

        private void comboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileType = ((ComboBoxItem)comboBoxFileType.SelectedItem).Value;
            Properties.Settings.Default.OutFileType = fileType;
            ChangeOutExtension();
            int maxValue = (fileType == FileTypeMP4) ? 51 : 63;
            if (trackBarCRF.Value > maxValue)
                trackBarCRF.Value = maxValue;
            trackBarCRF.Maximum = maxValue;
            trackBarCRF.Value = (fileType == FileTypeMP4) ? DefaultMp4CRF : DefaultWebmCRF;

            checkBoxWebOptimized.Visible = (fileType == FileTypeMP4);

            checkBoxConvertAudio.Checked = false;
            CheckAudioMustConvert();
        }

        private void radioButtonCRF_CheckedChanged(object sender, EventArgs e)
        {
            CheckVideoModeRadioButtons();
            CalcFileSize();
            SetOutputInfo();
        }

        private void radioButtonBitrate_CheckedChanged(object sender, EventArgs e)
        {
            CheckVideoModeRadioButtons();
            CalcFileSize();
            SetOutputInfo();
        }

        private void trackBarCRF_ValueChanged(object sender, EventArgs e)
        {
            labelCRF.Text = $"{trackBarCRF.Value}";
            SetOutputInfo();
        }

        private void numericUpDownBitrate_ValueChanged(object sender, EventArgs e)
        {
            CalcFileSize();
            SetOutputInfo();
        }

        private void comboBoxFrameRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOutputInfo();
        }
        
        #endregion

        #region Deinterlace

        private void checkBoxDeinterlace_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxFieldOrder.Enabled = checkBoxDeinterlace.Checked;
            SetOutputInfo();
        }

        private void comboBoxFieldOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOutputInfo();
        }

        #endregion

        #region Resize

        private void comboBoxPictureSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcFinalPictureSize();
            SetOutputInfo();
        }

        private void comboBoxPictureSize_TextUpdate(object sender, EventArgs e)
        {
            CalcFinalPictureSize();
            SetOutputInfo();
        }

        private void comboBoxPictureSize_Leave(object sender, EventArgs e)
        {
            // correct custom resolution
            if (comboBoxPictureSize.SelectedIndex < 0)
            {
                string input = comboBoxPictureSize.Text;
                string chkPictureSize = $"{selectedPictureSize.Width}x{selectedPictureSize.Height}";
                if (comboBoxPictureSize.SelectedIndex < 0 && !input.Equals(chkPictureSize, StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxPictureSize.Text = chkPictureSize;
                }
                pictureBoxSizeError.Image = null;
            }
        }

        private void comboBoxResizeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcFinalPictureSize();
            SetOutputInfo();
        }

        #endregion

        #region Filters

        private void comboBoxColorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOutputInfo();
        }

        #endregion

        #region Crop

        public void SetCropValues()
        {
            CalcCropPictureSize();
            CalcFinalPictureSize();
            SetOutputInfo();
        }

        #endregion

        #region Audio

        private void comboBoxAudioStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAudioMustConvert();
            CalcFileSize();
            SetOutputInfo();
        }

        private void checkBoxConvertAudio_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAudioBitrate.Enabled = checkBoxConvertAudio.Checked;
            comboBoxAudioFrequency.Enabled = checkBoxConvertAudio.Checked;
            comboBoxAudioChannels.Enabled = checkBoxConvertAudio.Checked;

            CalcFileSize();
            SetOutputInfo();
        }

        private void comboBoxAudioBitrate_Leave(object sender, EventArgs e)
        {
            if (comboBoxAudioBitrate.SelectedIndex < 0)
            {
                string input = comboBoxAudioBitrate.Text;
                int.TryParse(input, out int audioBitrate);
                if (audioBitrate < MinAudioBitrate)
                    audioBitrate = MinAudioBitrate;
                if (audioBitrate > MaxAudioBitrate)
                    audioBitrate = MaxAudioBitrate;
                comboBoxAudioBitrate.Text = audioBitrate.ToString();
                pictureBoxAudioBitrateError.Image = null;
            }
            CalcFileSize();
            SetOutputInfo();
        }

        private void comboBoxAudioBitrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcFileSize();
            SetOutputInfo();
        }

        private void comboBoxAudioBitrate_TextUpdate(object sender, EventArgs e)
        {
            string input = comboBoxAudioBitrate.SelectedIndex < 0 ? comboBoxAudioBitrate.Text : ((ComboBoxItem)comboBoxAudioBitrate.SelectedItem).Value;
            int.TryParse(input, out int audioBitrate);
            if (audioBitrate < MinAudioBitrate || audioBitrate > MaxAudioBitrate)
                pictureBoxAudioBitrateError.Image = Properties.Resources.critical;
            else
                pictureBoxAudioBitrateError.Image = null;
        }

        private void comboBoxAudioFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOutputInfo();
        }

        private void comboBoxAudioChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOutputInfo();
        }

        #endregion

        #region Meta

        private void textBoxTagTitle_TextChanged(object sender, EventArgs e)
        {
            Tags.Title = textBoxTagTitle.Text;
        }

        private void textBoxTagAuthor_TextChanged(object sender, EventArgs e)
        {
            Tags.Author = textBoxTagAuthor.Text;
        }

        private void textBoxTagCopyright_TextChanged(object sender, EventArgs e)
        {
            Tags.Copyright = textBoxTagCopyright.Text;
        }

        private void textBoxTagComment_TextChanged(object sender, EventArgs e)
        {
            Tags.Comment = textBoxTagComment.Text;
        }

        private void textBoxTagCreationTime_TextChanged(object sender, EventArgs e)
        {
            Tags.CreationTime = textBoxTagCreationTime.Text;
        }

        public void SetTagsFromInputFile()
        {
            ClearTags();
            textBoxTagTitle.Text = inputFile.TagTitle;
            textBoxTagAuthor.Text = inputFile.TagAuthor;
            textBoxTagCopyright.Text = inputFile.TagCopyright;
            textBoxTagComment.Text = inputFile.TagComment;
            textBoxTagCreationTime.Text = inputFile.TagCreationTime;
        }

        public void ClearTags()
        {
            textBoxTagTitle.Text = "";
            textBoxTagAuthor.Text = "";
            textBoxTagCopyright.Text = "";
            textBoxTagComment.Text = "";
            textBoxTagCreationTime.Text = "";
            Tags.Title = "";
            Tags.Author = "";
            Tags.Copyright = "";
            Tags.Comment = "";
            Tags.CreationTime = "";
        }

        #endregion

        #region Buttons

        private void buttonCrop_Click(object sender, EventArgs e)
        {
            new CropForm(inputFile).ShowDialog(this);
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            try
            {
                ConvertVideo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Functions

        private string AppendAppVersion(string title)
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

            return $"{title} v{niceVersion} ({whatBits} bit)";
        }

        private void ShowHideTabs()
        {
            if (inputFile == null)
            {
                tabPagePicture.Parent = null;
                tabPageVideo.Parent = null;
                tabPageAudio.Parent = null;
                tabPageTags.Parent = null;
            }
            else
            {
                tabPagePicture.Parent = tabControlMain;
                tabPageVideo.Parent = tabControlMain;
                tabPageAudio.Parent = tabControlMain;
                tabPageTags.Parent = tabControlMain;
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
                inputFile = new InputFile(path);
                inputFile.Probe();
            }
            catch (Exception ex)
            {
                inputFile = null;

                Picture.Init();

                textBoxIn.Text = "Файл не выбран";
                textBoxOut.Text = "";

                buttonGo.Enabled = false;
                buttonShowInfo.Enabled = false;
                buttonOpenInputFile.Enabled = false;

                labelCropSize.Text = "";
                cropPictureSize.Width = Picture.MinWidth;
                cropPictureSize.Height = Picture.MinHeight;

                selectedPictureSize.Width = Picture.MinWidth;
                selectedPictureSize.Height = Picture.MinHeight;

                finalPictureSize.Width = Picture.MinWidth;
                finalPictureSize.Height = Picture.MinHeight;

                CalcFileSize();

                ShowHideTabs();

                SetOutputInfo();

                ClearTags();

                Text = formTitle;

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

#if DEBUG
            Console.WriteLine(inputFile.StreamInfo);
#endif

            textBoxIn.Text = path;
            Properties.Settings.Default.InPath = Path.GetDirectoryName(path);

            ShowHideTabs();

            Text = Path.GetFileName(path) + " - " + formTitle;

            VideoStream vStream = inputFile.VideoStreams[0];

            Picture.Init();

            cropPictureSize.Width = vStream.PictureSize.Width;
            cropPictureSize.Height = vStream.PictureSize.Height;

            CalcCropPictureSize();
            CalcFinalPictureSize();

            // if need deinterlace
            checkBoxDeinterlace.Checked = vStream.FieldOrder != "progressive";
            comboBoxFieldOrder.SelectedIndex = 0;
            comboBoxFrameRate.SelectedIndex = 0;

            // fill audio streams
            FillAudioStreams();

            // show info
            SetInfo();

            CalcFileSize();

            buttonGo.Enabled = true;
            buttonShowInfo.Enabled = true;
            buttonOpenInputFile.Enabled = true;

            SetOutputInfo();

            SetTagsFromInputFile();

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
            if (inputFile == null)
            {
                throw new Exception("Видео-файл не определен!");
            }

            string input = Path.GetFullPath(inputFile.FullPath);
            string output = !string.IsNullOrWhiteSpace(textBoxOut.Text) ? Path.GetFullPath(textBoxOut.Text) : "";

            ValidateOutputFile(output);

            if (input.Equals(output, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Пути не должны совпадать!");
            }

            VideoStream vStream = inputFile.VideoStreams[0];

            string selectedMethod = ((ComboBoxItem)comboBoxResizeMethod.SelectedItem).Value;
            string scalingAlgorithm = ((ComboBoxItem)comboBoxScalingAlgorithm.SelectedItem).Value;
            string colorFilter = ((ComboBoxItem)comboBoxColorFilter.SelectedItem).Value;
            string fieldOrder = ((ComboBoxItem)comboBoxFieldOrder.SelectedItem).Value;
            string frameRate = ((ComboBoxItem)comboBoxFrameRate.SelectedItem).Value;

            string audioBitrateVal = comboBoxAudioBitrate.SelectedIndex < 0 ? comboBoxAudioBitrate.Text : ((ComboBoxItem)comboBoxAudioBitrate.SelectedItem).Value;
            int.TryParse(audioBitrateVal, out int audioBitrate);
            string audioChannels = ((ComboBoxItem)comboBoxAudioChannels.SelectedItem).Value;
            string audioFrequency = ((ComboBoxItem)comboBoxAudioFrequency.SelectedItem).Value;
            
            int videoBitrate = (int)Math.Round(numericUpDownBitrate.Value, 0);
            int crf = trackBarCRF.Value;

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

            List<string> videoArgs = new List<string>();
            List<string> audioArgs = new List<string>();

            // Video and audio args

            if (fileType == FileTypeMP4)
            {
                // https://trac.ffmpeg.org/wiki/Encode/H.264

                string videoCodec = "libx264";
                string audioCodec = "aac";

                // must be configurable
                string videoPreset = "veryslow";
                string videoProfile = "high";
                string videoLevel = "";

                string x264Params = "sar=1/1";
                if (twoPass)
                    x264Params += ":no-dct-decimate=1";

                string videoParams = $"-aq-mode autovariance-biased -fast-pskip 0 -mbtree 0 -pix_fmt yuv420p -x264-params \"{x264Params}\"";

                double finalFrameRate = CalcFinalFrameRate();
                if (finalFrameRate == 0)
                    finalFrameRate = vStream.FrameRate;
                // force level 4.1, max bitrate for high 4.1 - 62500, use max avg bitrate 50000
                if (encodeMode != EncodeModeBitrate || videoBitrate <= 50000)
                {
                    if (finalPictureSize.Width <= 1920 && finalPictureSize.Height <= 1080 && finalFrameRate <= 30.0)
                        videoLevel = " -level 4.1";
                }

                string moreAudioArgs = "-strict -2"; // for "aac" codec

                if (encodeMode == EncodeModeBitrate)
                    videoArgs.Add($"-c:v {videoCodec} -b:v {videoBitrate}k");
                else
                    videoArgs.Add($"-c:v {videoCodec} -crf {crf}");

                videoArgs.Add($"-preset:v {videoPreset} -profile:v {videoProfile}{videoLevel} {videoParams}");

                if (comboBoxAudioStreams.SelectedIndex == 0)
                    audioArgs.Add("-an");
                if (checkBoxConvertAudio.Checked)
                    audioArgs.Add($"-c:a {audioCodec} -b:a {audioBitrate}k {moreAudioArgs}");
                else
                    audioArgs.Add($"-c:a copy");
            }
            else if (fileType == FileTypeWebM)
            {
                // https://trac.ffmpeg.org/wiki/Encode/VP9
                // https://trac.ffmpeg.org/wiki/Encode/VP8

                string videoCodec = "libvpx-vp9"; // "libvpx" or "libvpx-vp9"
                string audioCodec = "libopus"; // "libvorbis" or "libopus"

                int threads = Environment.ProcessorCount / 2;

                if (encodeMode == EncodeModeBitrate)
                    videoArgs.Add($"-c:v {videoCodec} -b:v {videoBitrate}k -threads {threads}");
                else
                    videoArgs.Add($"-c:v {videoCodec} -crf {crf} -b:v 0 -threads {threads}");

                if (comboBoxAudioStreams.SelectedIndex == 0)
                    audioArgs.Add("-an");
                else if (checkBoxConvertAudio.Checked)
                    audioArgs.Add($"-c:a {audioCodec} -b:a {audioBitrate}k");
                else
                    audioArgs.Add($"-c:a copy");
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

            // crop - using dar
            if (Picture.IsCropped())
            {
                int cropW = vStream.OriginalSize.Width - Picture.Crop.Left - Picture.Crop.Right;
                int cropH = vStream.OriginalSize.Height - Picture.Crop.Top - Picture.Crop.Bottom;
                filters.Add($"crop={cropW}:{cropH}:{Picture.Crop.Left}:{Picture.Crop.Top}");
            }

            if (finalPictureSize.Width != cropPictureSize.Width || finalPictureSize.Height != cropPictureSize.Height)
            {
                // https://www.ffmpeg.org/ffmpeg-scaler.html#sws_005fflags
                filters.Add($"scale={finalPictureSize.Width}x{finalPictureSize.Height}:flags={scalingAlgorithm}");
            }
            else if (vStream.UsingDAR)
            {
                // force scale for not square pixels
                filters.Add($"scale={cropPictureSize.Width}x{cropPictureSize.Height}:flags={scalingAlgorithm}");
            }

            // add borders
            // https://ffmpeg.org/ffmpeg-filters.html#toc-pad-1
            if (selectedMethod == Picture.ResizeMethodBorders)
            {
                int padX = (int)Math.Round((selectedPictureSize.Width - finalPictureSize.Width) / 2.0);
                int padY = (int)Math.Round((selectedPictureSize.Height - finalPictureSize.Height) / 2.0);
                if (padX > 0 || padY > 0)
                    filters.Add($"pad={selectedPictureSize.Width}:{selectedPictureSize.Height}:{padX}:{padY}");
            }

            // force sar 1:1
            filters.Add($"setsar=1:1");

            // color filter
            if (colorFilter == "gray")
                filters.Add($"colorchannelmixer=.3:.4:.3:0:.3:.4:.3:0:.3:.4:.3");
            else if (colorFilter == "sepia")
                filters.Add($"colorchannelmixer=.393:.769:.189:0:.349:.686:.168:0:.272:.534:.131");

            // More video args

            videoArgs.Add($"-map 0:{inputFile.VideoStreams[0].Index}");

            if (!string.IsNullOrWhiteSpace(frameRate))
                videoArgs.Add($"-r {frameRate}");

            if (filters.Count > 0)
                videoArgs.Add("-vf \"" + string.Join(",", filters) + "\"");

            // More audio args

            if (comboBoxAudioStreams.SelectedIndex > 0)
            {
                string selectedStream = ((ComboBoxItem)comboBoxAudioStreams.SelectedItem).Value;
                audioArgs.Add($"-map 0:{selectedStream}");

                if (checkBoxConvertAudio.Checked)
                {
                    // resampling
                    if (!string.IsNullOrWhiteSpace(audioFrequency))
                    {
                        audioArgs.Add($"-ar {audioFrequency}");
                    }
                    // channels
                    if (!string.IsNullOrWhiteSpace(audioChannels))
                    {
                        audioArgs.Add($"-ac {audioChannels}");
                    }
                }
            }

            // More args

            List<string> moreArgs = new List<string>();

            // Meta

            moreArgs.Add("-map_metadata -1");
            if (!string.IsNullOrWhiteSpace(Tags.Title))
                moreArgs.Add($"-metadata title=\"{Tags.Title.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(Tags.Author))
                moreArgs.Add($"-metadata artist=\"{Tags.Author.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(Tags.Copyright))
                moreArgs.Add($"-metadata copyright=\"{Tags.Copyright.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(Tags.Comment))
                moreArgs.Add($"-metadata comment=\"{Tags.Comment.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(Tags.CreationTime))
                moreArgs.Add($"-metadata creation_time=\"{Tags.CreationTime.Replace("\"", "\\\"")}\"");
            else
                moreArgs.Add($"-metadata creation_time=\"{DateTime.Now.ToString("o")}\"");

            // mp4

            if (fileType == FileTypeMP4 && checkBoxWebOptimized.Checked)
                moreArgs.Add("-movflags +faststart");

            // Force file type

            moreArgs.Add($"-f {fileType}");

            // Convert

            string[] arguments;

            if (twoPass)
            {
                string passLogFile = GetTempLogFile();
                string twoPassTpl = "-pass {3} -passlogfile \"{4}\" {0} {1} {2}";

                arguments = new string[2];
                arguments[0] = string.Format(twoPassTpl, string.Join(" ", videoArgs), "-an", string.Join(" ", moreArgs), "1", passLogFile);
                arguments[1] = string.Format(twoPassTpl, string.Join(" ", videoArgs), string.Join(" ", audioArgs), string.Join(" ", moreArgs), "2", passLogFile);
            }
            else
            {
                arguments = new string[1];
                arguments[0] = string.Format("{0} {1} {2}", string.Join(" ", videoArgs), string.Join(" ", audioArgs), string.Join(" ", moreArgs));
            }

            new ConverterForm(input, output, arguments, inputFile.Duration.TotalSeconds).ShowDialog(this);
        }

        private void FillAudioStreams()
        {
            checkBoxConvertAudio.Checked = false;

            comboBoxAudioStreams.Items.Clear();
            comboBoxAudioStreams.Items.Add(new ComboBoxItem(string.Empty, "Без звука"));

            if (inputFile.AudioStreams.Count == 0)
            {
                comboBoxAudioStreams.SelectedIndex = 0;
                CheckAudioMustConvert();
                return;
            }

            comboBoxAudioBitrate.Enabled = checkBoxConvertAudio.Checked;
            comboBoxAudioFrequency.Enabled = checkBoxConvertAudio.Checked;
            comboBoxAudioChannels.Enabled = checkBoxConvertAudio.Checked;

            int idx = 1;
            foreach (AudioStream stream in inputFile.AudioStreams)
            {
                StringBuilder audio = new StringBuilder();

                audio.Append($"#{idx} {stream.CodecName.ToUpper()}");
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

                comboBoxAudioStreams.Items.Add(new ComboBoxItem($"{stream.Index}", audio.ToString()));

                idx++;
            }

            comboBoxAudioStreams.SelectedIndex = 1; // first stream

            CheckAudioMustConvert();
        }

        private void CheckAudioMustConvert()
        {
            comboBoxAudioBitrate.Select(0, 0);

            if (comboBoxAudioStreams.SelectedIndex == 0)
            {
                checkBoxConvertAudio.Checked = false;
                checkBoxConvertAudio.Enabled = false;
            }
            else
            {
                bool found = false;
                if (comboBoxAudioStreams.SelectedIndex > 0)
                {
                    string val = ((ComboBoxItem)comboBoxAudioStreams.SelectedItem).Value;
                    int.TryParse(val, out int index);
                    foreach (AudioStream aStream in inputFile.AudioStreams)
                    {
                        if (aStream.Index == index)
                        {
                            if (fileType == FileTypeWebM && aStream.CodecName.Equals("opus", StringComparison.OrdinalIgnoreCase))
                            {
                                checkBoxConvertAudio.Enabled = true;
                                found = true;
                            }
                            else if (fileType == FileTypeMP4 && aStream.CodecName.Equals("aac", StringComparison.OrdinalIgnoreCase))
                            {
                                checkBoxConvertAudio.Enabled = true;
                                found = true;
                            }
                            break;
                        }
                    }
                }
                if (!found)
                {
                    checkBoxConvertAudio.Checked = true;
                    checkBoxConvertAudio.Enabled = false;
                }
            }
        }

        private void CalcFinalPictureSize()
        {
            if (inputFile == null)
                return;
            // fit or stretch
            ParseSelectedPictureSize();
            string selectedMethod = ((ComboBoxItem)comboBoxResizeMethod.SelectedItem).Value;
            if (selectedMethod == Picture.ResizeMethodFill)
            {
                finalPictureSize.Width = selectedPictureSize.Width;
                finalPictureSize.Height = selectedPictureSize.Height;
            }
            else
            {
                double aspectRatio = Math.Min((double)selectedPictureSize.Width / cropPictureSize.Width, (double)selectedPictureSize.Height / cropPictureSize.Height);
                int newWidth = (int)Math.Round(cropPictureSize.Width * aspectRatio);
                int newHeight = (int)Math.Round(cropPictureSize.Height * aspectRatio);
                if (newWidth % 2 == 1)
                    newWidth -= 1;
                if (newWidth < Picture.MinWidth)
                    newWidth = Picture.MinWidth;
                if (newWidth > Picture.MaxWidth)
                    newWidth = Picture.MaxWidth;
                if (newHeight % 2 == 1)
                    newHeight -= 1;
                if (newHeight < Picture.MinHeight)
                    newHeight = Picture.MinHeight;
                if (newHeight > Picture.MaxHeight)
                    newHeight = Picture.MaxHeight;
                finalPictureSize.Width = newWidth;
                finalPictureSize.Height = newHeight;
            }
        }

        private void ParseSelectedPictureSize()
        {
            if (inputFile == null)
                return;
            pictureBoxSizeError.Image = null;
            // "do not change size" selected size = crop size
            if (comboBoxPictureSize.SelectedIndex == 0)
            {
                selectedPictureSize.Width = cropPictureSize.Width;
                selectedPictureSize.Height = cropPictureSize.Height;
                return;
            }
            string input = comboBoxPictureSize.SelectedIndex < 0 ? comboBoxPictureSize.Text : ((ComboBoxItem)comboBoxPictureSize.SelectedItem).Value;
            Match match = new Regex("^([0-9]+)x([0-9]+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(input);
            if (match.Success)
            {
                try
                {
                    int newWidth = Convert.ToInt32(match.Groups[1].Value);
                    int newHeight = Convert.ToInt32(match.Groups[2].Value);
                    if (newWidth % 2 == 1)
                        newWidth -= 1;
                    if (newWidth < Picture.MinWidth)
                        newWidth = Picture.MinWidth;
                    if (newHeight % 2 == 1)
                        newHeight -= 1;
                    if (newHeight < Picture.MinHeight)
                        newHeight = Picture.MinHeight;
                    selectedPictureSize.Width = newWidth;
                    selectedPictureSize.Height = newHeight;
                }
                catch {
                    pictureBoxSizeError.Image = Properties.Resources.critical;
                }
            }
            else
            {
                pictureBoxSizeError.Image = Properties.Resources.critical;
            }
        }
        
        private void CalcCropPictureSize()
        {
            if (inputFile == null)
                return;
            VideoStream vStream = inputFile.VideoStreams[0];
            if (Picture.IsCropped())
            {
                // init with oar sizes
                int newW = vStream.OriginalSize.Width - Picture.Crop.Left - Picture.Crop.Right;
                int newH = vStream.OriginalSize.Height - Picture.Crop.Top - Picture.Crop.Bottom;
                // correct dar -> sar
                if (vStream.UsingDAR)
                {
                    double diffW = (double)vStream.PictureSize.Width / vStream.OriginalSize.Width;
                    double diffH = (double)vStream.PictureSize.Height / vStream.OriginalSize.Height;
                    newW = (int)Math.Round(newW * diffW, 0);
                    newH = (int)Math.Round(newH * diffH, 0);
                    if (newW % 2 == 1)
                        newW -= 1;
                    if (newW < Picture.MinWidth)
                        newW = Picture.MinWidth;
                    if (newH % 2 == 1)
                        newH -= 1;
                    if (newH < Picture.MinHeight)
                        newH = Picture.MinHeight;
                }
                cropPictureSize.Width = newW;
                cropPictureSize.Height = newH;
                labelCropSize.Text = $"{vStream.PictureSize.ToString()} → {cropPictureSize.ToString()}";
            }
            else
            {
                cropPictureSize.Width = vStream.PictureSize.Width;
                cropPictureSize.Height = vStream.PictureSize.Height;
                labelCropSize.Text = "";
            }
        }

        private double CalcFinalFrameRate()
        {
            if (comboBoxFrameRate.SelectedIndex > 0)
            {
                string frameRateText = ((ComboBoxItem)comboBoxFrameRate.SelectedItem).Text;
                double.TryParse(frameRateText, out double frameRate);
                if (frameRate > 0)
                    return Math.Round(frameRate, 3);
            }
            return 0;
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
            if (inputFile == null || !radioButtonBitrate.Checked)
            {
                labelCalcSize.Text = "-";
                labelCalcSize.Visible = false;
                labelCalcSizeText.Visible = false;
                return;
            }

            labelCalcSize.Visible = true;
            labelCalcSizeText.Visible = true;

            double duration = inputFile.Duration.TotalMilliseconds / 1000;

            int videoBitrate = (int)Math.Round(numericUpDownBitrate.Value, 0);

            double fileSize = (videoBitrate * duration / 8.0) / 1024.0; // MiB

            if (comboBoxAudioStreams.SelectedIndex > 0)
            {
                string audioBitrateVal = comboBoxAudioBitrate.SelectedIndex < 0 ? comboBoxAudioBitrate.Text : ((ComboBoxItem)comboBoxAudioBitrate.SelectedItem).Value;
                int.TryParse(audioBitrateVal, out int audioBitrate);
                fileSize += (audioBitrate * duration / 8.0) / 1024.0; // MiB
            }

            string sizeString;
            if (fileSize >= 1)
                sizeString = $"~{Math.Round(fileSize, 0)} МБ";
            else
                sizeString = "меньше 1 МБ";

            labelCalcSize.Text = sizeString;
        }

        private void SetOutputInfo()
        {
            if (inputFile == null)
            {
                labelOutputInfoTitle.Visible = false;
                labelOutputInfo.Text = "";
                return;
            }

            StringBuilder info = new StringBuilder();

            // Video

            if (fileType == FileTypeMP4)
                info.Append($"H264");
            else
                info.Append($"VP9");

            string selectedMethod = ((ComboBoxItem)comboBoxResizeMethod.SelectedItem).Value;
            if (selectedMethod == Picture.ResizeMethodContain)
                info.Append($", {finalPictureSize.ToString()}");
            else
                info.Append($", {selectedPictureSize.ToString()}");

            string selectedMethodText = ((ComboBoxItem)comboBoxResizeMethod.SelectedItem).Text;
            if (comboBoxPictureSize.SelectedIndex > 0 || string.IsNullOrWhiteSpace(comboBoxPictureSize.Text))
                info.Append($", {selectedMethodText.ToLower()}");

            if (checkBoxDeinterlace.Checked)
                info.Append(", деинт.");

            if (comboBoxColorFilter.SelectedIndex > 0)
            {
                string colorFilter = ((ComboBoxItem)comboBoxColorFilter.SelectedItem).Value;
                string colorFilterText = ((ComboBoxItem)comboBoxColorFilter.SelectedItem).Text;
                if (colorFilter == "gray")
                    colorFilterText = "ч-б";
                info.Append($", {colorFilterText.ToLower()}");
            }
            if (radioButtonCRF.Checked)
                info.Append($", CRF {trackBarCRF.Value}");
            else
                info.Append($", {numericUpDownBitrate.Value} кбит/с");

            double finalFrameRate = CalcFinalFrameRate();
            if (finalFrameRate > 0)
                info.Append($", {finalFrameRate} fps");

            // Audio

            info.Append($"{Environment.NewLine}");

            if (comboBoxAudioStreams.SelectedIndex == 0)
            {
                info.Append("нет");
            }
            else if (comboBoxAudioStreams.SelectedIndex > 0)
            {
                if (fileType == FileTypeMP4)
                    info.Append($"AAC");
                else
                    info.Append($"OPUS");

                string val = ((ComboBoxItem)comboBoxAudioStreams.SelectedItem).Value;
                int.TryParse(val, out int index);

                int idx = 1;
                foreach (AudioStream aStream in inputFile.AudioStreams)
                {
                    if (aStream.Index == index)
                    {
                        info.Append($", #{idx}");
                        break;
                    }
                    idx++;
                }

                if (!checkBoxConvertAudio.Checked)
                {
                    info.Append($", без изменения");
                }
                else
                {
                    string audioBitrate = comboBoxAudioBitrate.SelectedIndex < 0 ? comboBoxAudioBitrate.Text : ((ComboBoxItem)comboBoxAudioBitrate.SelectedItem).Value;
                    string audioChannels = ((ComboBoxItem)comboBoxAudioChannels.SelectedItem).Value;
                    string audioFrequency = ((ComboBoxItem)comboBoxAudioFrequency.SelectedItem).Value;

                    info.Append($", {audioBitrate} кбит/с");

                    if (!string.IsNullOrWhiteSpace(audioFrequency))
                    {
                        info.Append($", {audioFrequency} Гц");
                    }
                    if (!string.IsNullOrWhiteSpace(audioChannels))
                    {
                        if (audioChannels == "1")
                            info.Append(", моно");
                        else if (audioChannels == "2")
                            info.Append(", стерео");
                        else
                            info.Append($", каналы: audioChannels");
                    }
                }
            }

            // Show

            labelOutputInfoTitle.Visible = true;
            labelOutputInfo.Text = info.ToString();
        }

        private void SetInfo()
        {
            VideoStream stream = inputFile.VideoStreams[0];

            StringBuilder info = new StringBuilder();

            string dur = new TimeSpan((long)inputFile.Duration.TotalMilliseconds * 10000L).ToString("hh\\:mm\\:ss\\.fff");

            info.AppendLine($"Формат: {inputFile.Format}");
            info.AppendLine($"Размер файла: {Utility.FormatFileSize(inputFile.FileSize)}");
            info.AppendLine($"Длительность: {dur}");
            info.AppendLine($"Битрейт: {inputFile.BitRate} kbps");
            info.AppendLine($"Разрешение: {stream.PictureSize.ToString()}{(stream.UsingDAR ? " (исх.: " + stream.OriginalSize.ToString() + ")" : "")}");
            info.AppendLine($"Частота кадров: {stream.FrameRate} fps");
            info.AppendLine($"Развертка: {(stream.FieldOrder == "progressive" ? "прогрессивная" : "чересстрочная")}");
            info.AppendLine($"Видеокодек: {stream.CodecName.ToUpper()}");
            info.AppendLine($"Дорожки аудио: {(inputFile.AudioStreams.Count > 0 ? inputFile.AudioStreams.Count.ToString() : "нет")}");

            fileInfo = info.ToString().TrimEnd();
        }

        public string GetTempFile()
        {
            string tempFileName = Path.GetTempFileName();
            tempFilesList.Add(tempFileName);
            return tempFileName;
        }

        public string GetTempLogFile(int streamIndex = 0)
        {
            string tempLogFile = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            string tempLogFileRealName = $"{tempLogFile}-{streamIndex}.log";
            tempFilesList.Add(tempLogFileRealName);
            // if mbtree is on
            //string tempLogMbtreeFileRealName = $"{tempLogFile}-{streamIndex}.log.mbtree";
            //tempFilesList.Add(tempLogMbtreeFileRealName);
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
    }
}
