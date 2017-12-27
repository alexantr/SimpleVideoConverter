﻿using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Alexantr.SimpleVideoConverter
{
    public partial class MainForm : Form
    {
        // http://dev.beandog.org/x264_preset_reference.html
        // http://www.videorip.info/x264/71-nekotorye-sovety-nastrojki-kodeka-x264-ot-polzovatelej
        // https://forum.videohelp.com/threads/369463-x264-Tweaking-testing-and-comparing-settings
        private const string FormatMP4 = "mp4";

        // https://www.webmproject.org/docs/container/
        private const string FormatWebM = "webm";

        private const string EncodeModeBitrate = "bitrate";
        private const string EncodeModeCRF = "crf";

        private const int MinBitrate = 100;
        private const int MaxBitrate = 500000;
        private const int DefaultBitrate = 3000;

        private const int DefaultMp4CRF = 20;
        private const int DefaultWebmCRF = 30;

        private InputFile inputFile;

        private string fileInfo;

        private string formTitle;

        private TaskbarManager taskbarManager;

        private char[] invalidChars = Path.GetInvalidPathChars();

        // lists

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

            int selectedIndex = 0, index = 0;

            // init crop size
            labelCropSize.Text = "";

            // Format
            string savedFormat = Properties.Settings.Default.OutFormat;
            comboBoxFileType.Items.Clear();
            selectedIndex = 0;
            index = 0;
            foreach (KeyValuePair<string, string> f in FormatConfig.FormatList)
            {
                comboBoxFileType.Items.Add(new ComboBoxItem(f.Key, f.Value));
                if (f.Key == savedFormat)
                    selectedIndex = index;
                index++;
            }
            comboBoxFileType.SelectedIndex = selectedIndex;

            // Set selected format
            FormatConfig.Format = ((ComboBoxItem)comboBoxFileType.SelectedItem).Value;

            // special for mp4
            if (FormatConfig.Format == FormatMP4)
            {
                checkBoxWebOptimized.Visible = true;
                checkBoxWebOptimized.Checked = true;
            }
            else
            {
                checkBoxWebOptimized.Visible = false;
            }

            // Encode mode
            radioButtonCRF.Checked = true;
            radioButtonBitrate.Checked = false;

            CheckVideoModeRadioButtons();

            // Picture Size
            comboBoxPictureSize.Text = string.Empty;
            comboBoxPictureSize.Items.Clear();
            comboBoxPictureSize.Items.Add(new ComboBoxItem(string.Empty, "Не изменять"));
            foreach (string ps in PictureConfig.SizeList)
            {
                comboBoxPictureSize.Items.Add(new ComboBoxItem(ps, ps));
            }
            comboBoxPictureSize.SelectedIndex = 0;

            // Resize method
            comboBoxResizeMethod.Items.Clear();
            selectedIndex = 0;
            index = 0;
            foreach (KeyValuePair<string, string> rm in PictureConfig.ResizeMethodList)
            {
                comboBoxResizeMethod.Items.Add(new ComboBoxItem(rm.Key, rm.Value));
                if (rm.Key == PictureConfig.DefaultResizeMethod)
                    selectedIndex = index;
                index++;
            }
            comboBoxResizeMethod.SelectedIndex = selectedIndex;

            // Interpolation
            comboBoxInterpolation.Items.Clear();
            selectedIndex = 0;
            index = 0;
            foreach (KeyValuePair<string, string> rm in PictureConfig.InterpolationList)
            {
                comboBoxInterpolation.Items.Add(new ComboBoxItem(rm.Key, rm.Value));
                if (rm.Key == PictureConfig.DefaultInterpolation)
                    selectedIndex = index;
                index++;
            }
            comboBoxInterpolation.SelectedIndex = selectedIndex;

            // Video codec
            FillVideoCodec();

            // Bitrate
            numericUpDownBitrate.Maximum = MaxBitrate;
            numericUpDownBitrate.Value = DefaultBitrate;
            numericUpDownBitrate.Minimum = MinBitrate;
            numericUpDownBitrate.Increment = 10;

            CalcFileSize(); // just hide labels

            // Field order
            comboBoxFieldOrder.Items.Clear();
            selectedIndex = 0;
            index = 0;
            foreach (KeyValuePair<string, string> rm in PictureConfig.FieldOrderList)
            {
                comboBoxFieldOrder.Items.Add(new ComboBoxItem(rm.Key, rm.Value));
                if (rm.Key == PictureConfig.DefaultFieldOrder)
                    selectedIndex = index;
                index++;
            }
            comboBoxFieldOrder.SelectedIndex = selectedIndex;

            // Deinterlace
            comboBoxFieldOrder.Enabled = checkBoxDeinterlace.Checked;

            // Color filter
            comboBoxColorFilter.Items.Clear();
            selectedIndex = 0;
            index = 0;
            foreach (KeyValuePair<string, string> rm in PictureConfig.ColorFilterList)
            {
                comboBoxColorFilter.Items.Add(new ComboBoxItem(rm.Key, rm.Value));
                if (rm.Key == PictureConfig.DefaultColorFilter)
                    selectedIndex = index;
                index++;
            }
            comboBoxColorFilter.SelectedIndex = selectedIndex;

            // Frame rate
            comboBoxFrameRate.Items.Clear();
            comboBoxFrameRate.Items.Add(new ComboBoxItem(string.Empty, "Исходная"));
            foreach (KeyValuePair<string, string> frameRate in VideoConfig.FrameRateList)
            {
                comboBoxFrameRate.Items.Add(new ComboBoxItem(frameRate.Key, frameRate.Value));
            }
            comboBoxFrameRate.SelectedIndex = 0;

            // Audio codec
            FillAudioCodec();

            // Audio bitrate
            FillAudioBitrate();

            // Audio sample rate
            FillAudioSampleRate();

            // Audio channels
            comboBoxAudioChannels.Items.Clear();
            foreach (KeyValuePair<int, string> ch in AudioConfig.ChannelsList)
            {
                comboBoxAudioChannels.Items.Add(new ComboBoxIntItem(ch.Key, ch.Value));
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

        private void FillCRFAndBitrate()
        {
            if (VideoConfig.CRFSupported)
            {
                if (trackBarCRF.Value > VideoConfig.CRFMaxValue)
                    trackBarCRF.Value = VideoConfig.CRFMaxValue;
                if (trackBarCRF.Value < VideoConfig.CRFMinValue)
                    trackBarCRF.Value = VideoConfig.CRFMinValue;

                trackBarCRF.Minimum = VideoConfig.CRFMinValue;
                trackBarCRF.Maximum = VideoConfig.CRFMaxValue;
                trackBarCRF.Value = VideoConfig.CRF;
                
                radioButtonCRF.Enabled = true;
            }
            else
            {
                radioButtonCRF.Checked = false;
                radioButtonCRF.Enabled = false;
                radioButtonBitrate.Checked = true;
            }

            if (numericUpDownBitrate.Value > VideoConfig.BitrateMaxValue)
                numericUpDownBitrate.Value = VideoConfig.BitrateMaxValue;
            if (numericUpDownBitrate.Value < VideoConfig.BitrateMinValue)
                numericUpDownBitrate.Value = VideoConfig.BitrateMinValue;

            numericUpDownBitrate.Minimum = VideoConfig.BitrateMinValue;
            numericUpDownBitrate.Maximum = VideoConfig.BitrateMaxValue;
            //numericUpDownBitrate.Value = VideoConfig.Bitrate;

            CheckVideoModeRadioButtons();
        }

        private void FillVideoCodec()
        {
            comboBoxVideoCodec.Items.Clear();
            int selectedIndex = 0, index = 0;
            foreach (KeyValuePair<string, string> c in VideoConfig.CodecList)
            {
                comboBoxVideoCodec.Items.Add(new ComboBoxItem(c.Key, c.Value));
                if (c.Key == VideoConfig.Codec)
                    selectedIndex = index;
                index++;
            }
            comboBoxVideoCodec.SelectedIndex = selectedIndex;
        }

        private void FillAudioCodec()
        {
            comboBoxAudioCodec.Items.Clear();
            int selectedIndex = 0, index = 0;
            foreach (KeyValuePair<string, string> c in AudioConfig.CodecList)
            {
                comboBoxAudioCodec.Items.Add(new ComboBoxItem(c.Key, c.Value));
                if (c.Key == AudioConfig.Codec)
                    selectedIndex = index;
                index++;
            }
            comboBoxAudioCodec.SelectedIndex = selectedIndex;
        }

        private void FillAudioBitrate()
        {
            comboBoxAudioBitrate.Items.Clear();
            int selectedIndex = 0, index = 0;
            foreach (int b in AudioConfig.BitrateList)
            {
                comboBoxAudioBitrate.Items.Add(new ComboBoxIntItem(b, b.ToString()));
                if (b == AudioConfig.Bitrate)
                    selectedIndex = index;
                index++;
            }
            comboBoxAudioBitrate.SelectedIndex = selectedIndex;
        }

        private void FillAudioSampleRate()
        {
            comboBoxAudioSampleRate.Items.Clear();
            comboBoxAudioSampleRate.Items.Add(new ComboBoxIntItem(0, "Исходная"));
            int selectedIndex = 0, index = 0;
            foreach (int sr in AudioConfig.SampleRateList)
            {
                comboBoxAudioSampleRate.Items.Add(new ComboBoxIntItem(sr, sr.ToString()));
                if (sr == AudioConfig.SampleRate)
                    selectedIndex = index;
                index++;
            }
            comboBoxAudioSampleRate.SelectedIndex = selectedIndex;
        }

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
                dialog.Filter = $"{FormatConfig.FormatList[FormatConfig.Format]} файлы|*.{FormatConfig.Format}";

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
            FormatConfig.Format = ((ComboBoxItem)comboBoxFileType.SelectedItem).Value;
            Properties.Settings.Default.OutFormat = FormatConfig.Format;
            ChangeOutExtension();

            checkBoxWebOptimized.Visible = (FormatConfig.Format == FormatMP4);

            FillVideoCodec();
            FillCRFAndBitrate();

            FillAudioCodec();
            FillAudioBitrate();
            FillAudioSampleRate();

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
            PictureConfig.Deinterlace = comboBoxFieldOrder.Enabled = checkBoxDeinterlace.Checked;
            SetOutputInfo();
        }

        private void comboBoxFieldOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.ResizeMethod = ((ComboBoxItem)comboBoxFieldOrder.SelectedItem).Value;
            SetOutputInfo();
        }

        #endregion

        #region Resize

        private void comboBoxPictureSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseSelectedPictureSize();
            UpdateCroppedPictureSizeInfo();
            SetOutputInfo();
        }

        private void comboBoxPictureSize_TextUpdate(object sender, EventArgs e)
        {
            ParseSelectedPictureSize();
            UpdateCroppedPictureSizeInfo();
            SetOutputInfo();
        }

        private void comboBoxPictureSize_Leave(object sender, EventArgs e)
        {
            // correct custom resolution
            if (comboBoxPictureSize.SelectedIndex == -1 && PictureConfig.SelectedSize != null)
            {
                string input = comboBoxPictureSize.Text;
                string chkPictureSize = PictureConfig.SelectedSize.ToString();
                if (!input.Equals(chkPictureSize, StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxPictureSize.Text = chkPictureSize;
                }
                pictureBoxSizeError.Image = null;
            }
        }

        private void comboBoxResizeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.ResizeMethod = ((ComboBoxItem)comboBoxResizeMethod.SelectedItem).Value;

            UpdateCroppedPictureSizeInfo();
            SetOutputInfo();
        }

        private void comboBoxInterpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.Interpolation = ((ComboBoxItem)comboBoxInterpolation.SelectedItem).Value;
        }

        #endregion

        #region Filters

        private void comboBoxColorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.ColorFilter = ((ComboBoxItem)comboBoxColorFilter.SelectedItem).Value;

            SetOutputInfo();
        }

        #endregion

        #region Crop

        /// <summary>
        /// Call after crop window closed
        /// </summary>
        public void UpdateCrop(Crop newCrop)
        {
            PictureConfig.Crop = newCrop;
            UpdateCroppedPictureSizeInfo();
            SetOutputInfo();
        }

        #endregion

        #region Video

        private void comboBoxVideoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoConfig.Codec = ((ComboBoxItem)comboBoxVideoCodec.SelectedItem).Value;

            // change audio codec to default for selected video codec
            if (VideoConfig.DefaultAudioCodecs.ContainsKey(VideoConfig.Codec))
            {
                int index = 0;
                foreach (ComboBoxItem item in comboBoxAudioCodec.Items)
                {
                    if (item.Value == VideoConfig.DefaultAudioCodecs[VideoConfig.Codec])
                    {
                        comboBoxAudioCodec.SelectedIndex = index;
                        break;
                    }
                    index++;
                }
            }

            FillCRFAndBitrate();
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
            comboBoxAudioCodec.Enabled = checkBoxConvertAudio.Checked;
            comboBoxAudioBitrate.Enabled = checkBoxConvertAudio.Checked;
            comboBoxAudioSampleRate.Enabled = checkBoxConvertAudio.Checked;
            comboBoxAudioChannels.Enabled = checkBoxConvertAudio.Checked;

            CalcFileSize();
            SetOutputInfo();
        }

        private void comboBoxAudioCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioConfig.Codec = ((ComboBoxItem)comboBoxAudioCodec.SelectedItem).Value;

            FillAudioBitrate();
            FillAudioSampleRate();
        }

        private void comboBoxAudioBitrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioConfig.Bitrate = ((ComboBoxIntItem)comboBoxAudioBitrate.SelectedItem).Value;

            CalcFileSize();
            SetOutputInfo();
        }
        
        private void comboBoxAudioSampleRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioConfig.SampleRate = ((ComboBoxIntItem)comboBoxAudioSampleRate.SelectedItem).Value;

            FillAudioBitrate();

            SetOutputInfo();
        }

        private void comboBoxAudioChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            AudioConfig.Channels = ((ComboBoxIntItem)comboBoxAudioChannels.SelectedItem).Value;

            SetOutputInfo();
        }

        #endregion

        #region Meta

        private void textBoxTagTitle_TextChanged(object sender, EventArgs e)
        {
            TagsConfig.Title = textBoxTagTitle.Text;
        }

        private void textBoxTagAuthor_TextChanged(object sender, EventArgs e)
        {
            TagsConfig.Author = textBoxTagAuthor.Text;
        }

        private void textBoxTagCopyright_TextChanged(object sender, EventArgs e)
        {
            TagsConfig.Copyright = textBoxTagCopyright.Text;
        }

        private void textBoxTagComment_TextChanged(object sender, EventArgs e)
        {
            TagsConfig.Comment = textBoxTagComment.Text;
        }

        private void textBoxTagCreationTime_TextChanged(object sender, EventArgs e)
        {
            TagsConfig.CreationTime = textBoxTagCreationTime.Text;
        }

        public void SetTagsFromInputFile()
        {
            ClearTags();
            textBoxTagTitle.Text = inputFile.Tags.Title;
            textBoxTagAuthor.Text = inputFile.Tags.Author;
            textBoxTagCopyright.Text = inputFile.Tags.Copyright;
            textBoxTagComment.Text = inputFile.Tags.Comment;
            textBoxTagCreationTime.Text = inputFile.Tags.CreationTime;
        }

        public void ClearTags()
        {
            textBoxTagTitle.Text = "";
            textBoxTagAuthor.Text = "";
            textBoxTagCopyright.Text = "";
            textBoxTagComment.Text = "";
            textBoxTagCreationTime.Text = "";
            TagsConfig.Clear();
        }

        #endregion

        #region Buttons

        private void buttonCrop_Click(object sender, EventArgs e)
        {
            new CropForm(inputFile, PictureConfig.Crop).ShowDialog(this);
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
                    textBoxOut.Text = Path.Combine(Path.GetDirectoryName(textBoxOut.Text), Path.GetFileNameWithoutExtension(textBoxOut.Text) + "." + FormatConfig.Format);
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

                PictureConfig.Reset();

                textBoxIn.Text = "Файл не выбран";
                textBoxOut.Text = "";

                buttonGo.Enabled = false;
                buttonShowInfo.Enabled = false;
                buttonOpenInputFile.Enabled = false;

                labelCropSize.Text = "";

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

            PictureConfig.Reset();
            PictureConfig.InputOriginalSize = vStream.OriginalSize;
            PictureConfig.InputDisplaySize = vStream.PictureSize;

            // if need deinterlace
            PictureConfig.Deinterlace = checkBoxDeinterlace.Checked = vStream.FieldOrder != "progressive";
            comboBoxFieldOrder.SelectedIndex = 0; // TODO: get from Picture

            comboBoxFrameRate.SelectedIndex = 0;

            // fill audio streams
            FillAudioStreams();

            // show info
            SetInputInfo();

            CalcFileSize();

            buttonGo.Enabled = true;
            buttonShowInfo.Enabled = true;
            buttonOpenInputFile.Enabled = true;

            UpdateCroppedPictureSizeInfo();
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

                string outPath = Path.Combine(outDir, withoutExtension + "." + FormatConfig.Format);
                int num = 2;
                while (File.Exists(outPath))
                {
                    outPath = Path.Combine(outDir, withoutExtension + " (" + num.ToString() + ")." + FormatConfig.Format);
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

            string frameRate = ((ComboBoxItem)comboBoxFrameRate.SelectedItem).Value;

            int videoBitrate = (int)Math.Round(numericUpDownBitrate.Value, 0);
            int crf = trackBarCRF.Value;

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

            int audioStreamIndex = ((ComboBoxIntItem)comboBoxAudioStreams.SelectedItem).Value;

            bool twoPass = !VideoConfig.UseCRF;

            List<string> videoArgs = new List<string>();
            List<string> audioArgs = new List<string>();

            string specialCrfArgs = "";
            string specialArgsPass1 = "";
            string specialArgsPass2 = "";
            bool noAudioPass1 = true;

            // Video and audio args

            if (FormatConfig.Format == FormatMP4)
            {
                // https://trac.ffmpeg.org/wiki/Encode/H.264

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
                if (VideoConfig.UseCRF || videoBitrate <= 50000)
                {
                    if (PictureConfig.OutputSize.Width <= 1920 && PictureConfig.OutputSize.Height <= 1080 && finalFrameRate <= 30.0)
                        videoLevel = " -level 4.1";
                }

                if (VideoConfig.UseCRF)
                    videoArgs.Add($"-c:v {VideoConfig.Encoder} -crf {crf}");
                else
                    videoArgs.Add($"-c:v {VideoConfig.Encoder} -b:v {videoBitrate}k");

                videoArgs.Add($"-preset:v {videoPreset} -profile:v {videoProfile}{videoLevel} {videoParams}");
            }
            else if (FormatConfig.Format == FormatWebM)
            {
                // https://trac.ffmpeg.org/wiki/Encode/VP9
                // https://trac.ffmpeg.org/wiki/Encode/VP8

                int threads = Environment.ProcessorCount;

                if (VideoConfig.UseCRF)
                    videoArgs.Add($"-c:v {VideoConfig.Encoder} -crf {crf} -b:v 0 -threads {threads}");
                else
                    videoArgs.Add($"-c:v {VideoConfig.Encoder} -b:v {videoBitrate}k -threads {threads}");

                specialArgsPass1 = "-speed 4";
                specialArgsPass2 = "-speed 1";
                noAudioPass1 = false;

                specialCrfArgs = "-speed 1";
            }
            else
            {
                throw new Exception("Неверный выходной тип файла!"); // Possible?
            }

            // Video filters

            List<string> filters = new List<string>();

            if (PictureConfig.Deinterlace)
            {
                string deinterlaceFilter = "yadif";
                if (PictureConfig.FieldOrder != "auto")
                    deinterlaceFilter += $"=parity={PictureConfig.FieldOrder}";
                filters.Add(deinterlaceFilter);
            }

            // crop - using oar
            if (PictureConfig.IsCropped())
            {
                int cropW = vStream.OriginalSize.Width - PictureConfig.Crop.Left - PictureConfig.Crop.Right;
                int cropH = vStream.OriginalSize.Height - PictureConfig.Crop.Top - PictureConfig.Crop.Bottom;
                filters.Add($"crop={cropW}:{cropH}:{PictureConfig.Crop.Left}:{PictureConfig.Crop.Top}");
            }

            if (PictureConfig.OutputSize.Width != PictureConfig.CropSize.Width || PictureConfig.OutputSize.Height != PictureConfig.CropSize.Height)
            {
                // https://www.ffmpeg.org/ffmpeg-scaler.html#sws_005fflags
                filters.Add($"scale={PictureConfig.OutputSize.Width}x{PictureConfig.OutputSize.Height}:flags={PictureConfig.Interpolation}");
            }
            else if (PictureConfig.IsUsingDAR())
            {
                // force scale for not square pixels
                filters.Add($"scale={PictureConfig.CropSize.Width}x{PictureConfig.CropSize.Height}:flags={PictureConfig.Interpolation}");
            }

            // add borders
            // https://ffmpeg.org/ffmpeg-filters.html#toc-pad-1
            if (PictureConfig.Padding.X > 0 || PictureConfig.Padding.Y > 0)
            {
                filters.Add($"pad={PictureConfig.SelectedSize.Width}:{PictureConfig.SelectedSize.Height}:{PictureConfig.Padding.X}:{PictureConfig.Padding.Y}");
            }

            // force sar 1:1
            filters.Add($"setsar=1:1");

            // color filter
            if (PictureConfig.ColorChannelMixerList.ContainsKey(PictureConfig.ColorFilter))
                filters.Add($"colorchannelmixer={PictureConfig.ColorChannelMixerList[PictureConfig.ColorFilter]}");

            // More video args

            videoArgs.Add($"-map 0:{inputFile.VideoStreams[0].Index}");

            if (!string.IsNullOrWhiteSpace(frameRate))
                videoArgs.Add($"-r {frameRate}");

            if (filters.Count > 0)
                videoArgs.Add("-vf \"" + string.Join(",", filters) + "\"");

            // Audio args

            if (audioStreamIndex == -1)
            {
                audioArgs.Add("-an");
            }
            else
            {
                audioArgs.Add($"-map 0:{audioStreamIndex}");

                if (checkBoxConvertAudio.Checked)
                {
                    audioArgs.Add($"-c:a {AudioConfig.Encoder} -b:a {AudioConfig.Bitrate}k {AudioConfig.AdditionalArguments}");

                    // resampling
                    if (AudioConfig.SampleRate > 0)
                    {
                        audioArgs.Add($"-ar {AudioConfig.SampleRate}");
                    }
                    // channels
                    if (AudioConfig.Channels > 0)
                    {
                        audioArgs.Add($"-ac {AudioConfig.Channels}");
                    }
                }
                else
                {
                    audioArgs.Add($"-c:a copy");
                }
            }

            // More args

            List<string> moreArgs = new List<string>();

            // Meta

            moreArgs.Add("-map_metadata -1");
            if (!string.IsNullOrWhiteSpace(TagsConfig.Title))
                moreArgs.Add($"-metadata title=\"{TagsConfig.Title.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(TagsConfig.Author))
                moreArgs.Add($"-metadata artist=\"{TagsConfig.Author.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(TagsConfig.Copyright))
                moreArgs.Add($"-metadata copyright=\"{TagsConfig.Copyright.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(TagsConfig.Comment))
                moreArgs.Add($"-metadata comment=\"{TagsConfig.Comment.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(TagsConfig.CreationTime))
                moreArgs.Add($"-metadata creation_time=\"{TagsConfig.CreationTime.Replace("\"", "\\\"")}\"");
            else
                moreArgs.Add($"-metadata creation_time=\"{DateTime.Now.ToString("o")}\"");

            // mp4

            if (FormatConfig.Format == FormatMP4 && checkBoxWebOptimized.Checked)
                moreArgs.Add("-movflags +faststart");

            // Force file type

            moreArgs.Add($"-f {FormatConfig.Format}");

            // Convert

            string[] arguments;

            if (twoPass)
            {
                string passLogFile = GetTempLogFile();
                string twoPassTpl = "-pass {3} -passlogfile \"{4}\" {0} {1} {2} {4}";

                arguments = new string[2];
                arguments[0] = string.Format(twoPassTpl, string.Join(" ", videoArgs), (noAudioPass1 ? "-an" : string.Join(" ", audioArgs)), string.Join(" ", moreArgs), 1, passLogFile, specialArgsPass1);
                arguments[1] = string.Format(twoPassTpl, string.Join(" ", videoArgs), string.Join(" ", audioArgs), string.Join(" ", moreArgs), 2, passLogFile, specialArgsPass2);
            }
            else
            {
                arguments = new string[1];
                arguments[0] = string.Format("{0} {1} {2} {3}", string.Join(" ", videoArgs), string.Join(" ", audioArgs), string.Join(" ", moreArgs), specialCrfArgs);
            }

            new ConverterForm(input, output, arguments, inputFile.Duration.TotalSeconds).ShowDialog(this);
        }

        private void FillAudioStreams()
        {
            checkBoxConvertAudio.Checked = false;

            comboBoxAudioStreams.Items.Clear();
            comboBoxAudioStreams.Items.Add(new ComboBoxIntItem(-1, "Без звука"));

            if (inputFile.AudioStreams.Count == 0)
            {
                comboBoxAudioStreams.SelectedIndex = 0;
                CheckAudioMustConvert();
                return;
            }

            comboBoxAudioBitrate.Enabled = checkBoxConvertAudio.Checked;
            comboBoxAudioSampleRate.Enabled = checkBoxConvertAudio.Checked;
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

                comboBoxAudioStreams.Items.Add(new ComboBoxIntItem(stream.Index, audio.ToString()));

                idx++;
            }

            comboBoxAudioStreams.SelectedIndex = 1; // first stream

            CheckAudioMustConvert();
        }

        private void CheckAudioMustConvert()
        {
            if (comboBoxAudioStreams.SelectedIndex < 1)
            {
                checkBoxConvertAudio.Checked = false;
                checkBoxConvertAudio.Enabled = false;
            }
            else
            {
                int index = ((ComboBoxIntItem)comboBoxAudioStreams.SelectedItem).Value;
                bool found = false;
                foreach (AudioStream aStream in inputFile.AudioStreams)
                {
                    if (aStream.Index == index)
                    {
                        if (FormatConfig.Format == FormatWebM && aStream.CodecName.Equals("opus", StringComparison.OrdinalIgnoreCase))
                        {
                            checkBoxConvertAudio.Enabled = true;
                            found = true;
                        }
                        else if (FormatConfig.Format == FormatMP4 && aStream.CodecName.Equals("aac", StringComparison.OrdinalIgnoreCase))
                        {
                            checkBoxConvertAudio.Enabled = true;
                            found = true;
                        }
                        break;
                    }
                }
                if (!found)
                {
                    checkBoxConvertAudio.Checked = true;
                    checkBoxConvertAudio.Enabled = false;
                }
            }
        }

        private void ParseSelectedPictureSize()
        {
            if (inputFile == null || comboBoxPictureSize.SelectedIndex == 0)
            {
                PictureConfig.SelectedSize = null;
                pictureBoxSizeError.Image = null;
                return;
            }

            string input = comboBoxPictureSize.SelectedIndex > 0 ? ((ComboBoxItem)comboBoxPictureSize.SelectedItem).Value : comboBoxPictureSize.Text;
            if (!PictureConfig.ParseSelectedSize(input))
                pictureBoxSizeError.Image = Properties.Resources.critical;
            else
                pictureBoxSizeError.Image = null;
        }
        
        private void UpdateCroppedPictureSizeInfo()
        {
            if (inputFile == null)
                return;
            if (PictureConfig.IsCropped())
                labelCropSize.Text = $"{PictureConfig.InputDisplaySize.ToString()} → {PictureConfig.CropSize.ToString()}";
            else
                labelCropSize.Text = "";
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

            VideoConfig.UseCRF = radioButtonCRF.Checked;
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
                fileSize += (AudioConfig.Bitrate * duration / 8.0) / 1024.0; // MiB
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

            if (VideoConfig.CodecList.ContainsKey(VideoConfig.Codec))
                info.Append($"{VideoConfig.CodecList[VideoConfig.Codec]}");
            else
                info.Append($"{VideoConfig.Codec}");

            if (PictureConfig.Padding.X > 0 || PictureConfig.Padding.Y > 0)
            {
                PictureSize fullSize = new PictureSize();
                fullSize.Width = PictureConfig.OutputSize.Width + PictureConfig.Padding.X + PictureConfig.Padding.X;
                fullSize.Height = PictureConfig.OutputSize.Height + PictureConfig.Padding.Y + PictureConfig.Padding.Y;
                info.Append($", {fullSize.ToString()} ({PictureConfig.OutputSize.ToString()})");
            }
            else
            {
                info.Append($", {PictureConfig.OutputSize.ToString()}");
            }

            if (PictureConfig.IsResized())
            {
                if (PictureConfig.ResizeMethodList.ContainsKey(PictureConfig.ResizeMethod))
                    info.Append($", {PictureConfig.ResizeMethodList[PictureConfig.ResizeMethod].ToLower()}");
                else
                    info.Append($", {PictureConfig.ResizeMethod}");
            }

            if (PictureConfig.Deinterlace)
                info.Append(", деинт.");

            if (PictureConfig.ColorFilter != "none")
                info.Append($", {PictureConfig.ColorFilterList[PictureConfig.ColorFilter].ToLower()}");

            if (radioButtonCRF.Checked)
                info.Append($", CRF {trackBarCRF.Value}");
            else
                info.Append($", {numericUpDownBitrate.Value} кбит/с");

            double finalFrameRate = CalcFinalFrameRate();
            if (finalFrameRate > 0)
                info.Append($", {finalFrameRate} fps");

            // Audio

            info.Append($"{Environment.NewLine}");

            if (comboBoxAudioStreams.SelectedIndex < 1)
            {
                info.Append("нет");
            }
            else
            {
                int index = ((ComboBoxIntItem)comboBoxAudioStreams.SelectedItem).Value;

                if (AudioConfig.CodecList.ContainsKey(AudioConfig.Codec))
                    info.Append($"{AudioConfig.CodecList[AudioConfig.Codec]}");
                else
                    info.Append($"{AudioConfig.Codec}");

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
                    info.Append($", {AudioConfig.Bitrate} кбит/с");

                    if (AudioConfig.SampleRate > 0)
                    {
                        info.Append($", {AudioConfig.SampleRate} Гц");
                    }
                    if (AudioConfig.Channels > 0)
                    {
                        if (AudioConfig.ChannelsList.ContainsKey(AudioConfig.Channels))
                            info.Append($", каналы: {AudioConfig.ChannelsList[AudioConfig.Channels]}");
                    }
                }
            }

            // Show

            labelOutputInfoTitle.Visible = true;
            labelOutputInfo.Text = info.ToString();
        }

        private void SetInputInfo()
        {
            VideoStream stream = inputFile.VideoStreams[0];

            StringBuilder info = new StringBuilder();

            string dur = new TimeSpan((long)inputFile.Duration.TotalMilliseconds * 10000L).ToString("hh\\:mm\\:ss\\.fff");

            info.AppendLine($"Формат: {inputFile.Format}");
            info.AppendLine($"Размер файла: {inputFile.FileSize.FormatFileSize()}");
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
