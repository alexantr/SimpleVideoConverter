using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Alexantr.SimpleVideoConverter
{
    public partial class MainForm : Form
    {
        private InputFile inputFile;

        private string fileInfo;

        private string formTitle;

        private string fileType;

        private TaskbarManager taskbarManager;

        //private bool doNotCheckKeepARAgain = false;
        private bool sizeChanged = false;

        public MainForm()
        {
            InitializeComponent();

            taskbarManager = TaskbarManager.Instance;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            formTitle = AppendAppVersion(Text);
            Text = formTitle;

            buttonGo.Enabled = false;
            buttonPreview.Enabled = false;
            buttonShowInfo.Enabled = false;
            buttonOpenInputFile.Enabled = false;

            checkBoxKeepOutPath.Checked = Properties.Settings.Default.RememberOutPath;

            checkBoxWebOptimized.Checked = Properties.Settings.Default.WebOptimized;

            // Init once on form load
            
            //ManageCheckPanel(checkBoxResizePicture, panelResolution);

            UpdateCropSizeInfo();

            numericUpDownWidth.Maximum = PictureConfig.MaxWidth;
            numericUpDownWidth.Value = PictureConfig.MinWidth;
            numericUpDownWidth.Minimum = PictureConfig.MinWidth;
            numericUpDownWidth.Increment = 2;

            numericUpDownHeight.Maximum = PictureConfig.MaxHeight;
            numericUpDownHeight.Value = PictureConfig.MinHeight;
            numericUpDownHeight.Minimum = PictureConfig.MinHeight;
            numericUpDownHeight.Increment = 2;

            checkBoxKeepAspectRatio.Checked = true; // height input will be disabled

            fileType = FormatMP4; // default is mp4

            // init configs
            VideoConfig.Codec = VideoConfig.CodecH264;
            AudioConfig.Codec = AudioConfig.CodecAAC;

            FillInterpolation();

            FillFieldOrder();
            ManageCheckPanel(checkBoxDeinterlace, panelDeinterlace);

            FillRotate();

            FillColorFilter();

            FillFrameRate();

            FillVideoCodec();
            FillVideoCRFAndBitrate();
            FillPreset();

            FillAudioCodec();
            FillAudioBitrate();
            FillAudioSampleRate();
            FillAudioChannels();

            //CheckAudioMustConvert();
            //UpdateAudioBitrateByChannels();

            CalcFileSize(); // just hide labels

            ToggleTabs();

            SetOutputInfo();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                SetInputFile(commandLineArgs[1]);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.RememberOutPath = checkBoxKeepOutPath.Checked;
            Properties.Settings.Default.WebOptimized = checkBoxWebOptimized.Checked;
            Properties.Settings.Default.Save();

            DeleteTempFiles();
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            // show copy cursor for files
            bool dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
            e.Effect = dataPresent ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            SetInputFile(files[0]);
        }

        #region In, Out, Format, Go

        private void buttonBrowseIn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                string inPath = Properties.Settings.Default.InPath;
                if (!string.IsNullOrWhiteSpace(inPath) && Directory.Exists(inPath))
                {
                    dialog.InitialDirectory = inPath;
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
                    SetInputFile(dialog.FileName);
                }
            }
        }

        private void buttonBrowseOut_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.OverwritePrompt = false; // ask later
                dialog.ValidateNames = true;
                dialog.Filter = "MP4 файлы|*.mp4|MKV файлы|*.mkv|MPEG-TS файлы|*.ts|MOV файлы|*.mov";
                if (fileType == FormatMKV)
                    dialog.FilterIndex = 2;
                else if (fileType == FormatTS)
                    dialog.FilterIndex = 3;
                else if (fileType == FormatMOV)
                    dialog.FilterIndex = 4;

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
                    string ext = Path.GetExtension(dialog.FileName).ToLower();
                    if (ext == ".mov")
                        fileType = FormatMOV;
                    else if (ext == ".ts" || ext == ".m2ts")
                        fileType = FormatTS;
                    else if (ext == ".mkv")
                        fileType = FormatMKV;
                    else
                        fileType = FormatMP4;

                    textBoxOut.Text = dialog.FileName;
                    Properties.Settings.Default.OutPath = Path.GetDirectoryName(dialog.FileName);

                    CheckMp4MoveFlags();
                }
            }
        }

        private void buttonShowInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(fileInfo, "Информация о файле", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Picture

        public void UpdateCrop()
        {
            UpdateCropSizeInfo();
            UpdateAspectRatio();
            SetOutputInfo();
        }

        public void ResetCrop()
        {
            numericCropTop.Value = 0;
            numericCropBottom.Value = 0;
            numericCropLeft.Value = 0;
            numericCropRight.Value = 0;
        }

        private void buttonCropReset_Click(object sender, EventArgs e)
        {
            ResetCrop();
            UpdateCrop();
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            if (inputFile == null)
                return;

            UpdateHeigth();

            sizeChanged = true;

            PictureConfig.OutputSize.Width = (int)Math.Round(numericUpDownWidth.Value, 0);
            PictureConfig.OutputSize.Height = (int)Math.Round(numericUpDownHeight.Value, 0);

            SetOutputInfo();
        }

        private void numericUpDownWidth_Leave(object sender, EventArgs e)
        {
            if ((int)numericUpDownWidth.Value % 2 == 1)
                numericUpDownWidth.Value = Math.Max(PictureConfig.MinWidth, (int)numericUpDownWidth.Value - 1);

            if (inputFile == null)
                return;

            UpdateHeigth();

            sizeChanged = true;

            PictureConfig.OutputSize.Width = (int)Math.Round(numericUpDownWidth.Value, 0);
            PictureConfig.OutputSize.Height = (int)Math.Round(numericUpDownHeight.Value, 0);

            SetOutputInfo();
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            if (inputFile == null)
                return;

            if (numericUpDownHeight.Enabled)
            {
                sizeChanged = true;

                PictureConfig.OutputSize.Width = (int)Math.Round(numericUpDownWidth.Value, 0);
                PictureConfig.OutputSize.Height = (int)Math.Round(numericUpDownHeight.Value, 0);

                SetOutputInfo();
            }
        }

        private void numericUpDownHeight_Leave(object sender, EventArgs e)
        {
            if ((int)numericUpDownHeight.Value % 2 == 1)
                numericUpDownHeight.Value = Math.Max(PictureConfig.MinHeight, (int)numericUpDownHeight.Value - 1);

            if (inputFile == null)
                return;

            if (numericUpDownHeight.Enabled)
            {
                sizeChanged = true;

                PictureConfig.OutputSize.Width = (int)Math.Round(numericUpDownWidth.Value, 0);
                PictureConfig.OutputSize.Height = (int)Math.Round(numericUpDownHeight.Value, 0);

                SetOutputInfo();
            }
        }

        private void checkBoxKeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            //doNotCheckKeepARAgain = !checkBoxKeepAspectRatio.Checked;
            comboBoxAspectRatio.Enabled = checkBoxKeepAspectRatio.Checked;
            numericUpDownHeight.Enabled = !checkBoxKeepAspectRatio.Checked;

            UpdateHeigth();

            if (inputFile == null)
                return;

            PictureConfig.OutputSize.Width = (int)Math.Round(numericUpDownWidth.Value, 0);
            PictureConfig.OutputSize.Height = (int)Math.Round(numericUpDownHeight.Value, 0);

            SetOutputInfo();
        }

        private void comboBoxAspectRatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateHeigth();

            if (inputFile == null)
                return;

            PictureConfig.OutputSize.Width = (int)Math.Round(numericUpDownWidth.Value, 0);
            PictureConfig.OutputSize.Height = (int)Math.Round(numericUpDownHeight.Value, 0);

            SetOutputInfo();
        }

        private void comboBoxAspectRatio_TextUpdate(object sender, EventArgs e)
        {
            UpdateHeigth();

            if (inputFile == null)
                return;

            PictureConfig.OutputSize.Width = (int)Math.Round(numericUpDownWidth.Value, 0);
            PictureConfig.OutputSize.Height = (int)Math.Round(numericUpDownHeight.Value, 0);

            SetOutputInfo();
        }

        private void buttonPreset1080p_Click(object sender, EventArgs e)
        {
            ResizeFromPreset(1920, 1080);
        }

        private void buttonPreset720p_Click(object sender, EventArgs e)
        {
            ResizeFromPreset(1280, 720);
        }

        private void buttonPreset480p_Click(object sender, EventArgs e)
        {
            ResizeFromPreset(640, 480);
        }

        private void buttonPresetOriginal_Click(object sender, EventArgs e)
        {
            sizeChanged = false;
            ResizeFromPreset(PictureConfig.CropSize.Width, 0);
        }

        private void comboBoxInterpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.Interpolation = ((ComboBoxItem)comboBoxInterpolation.SelectedItem).Value;
        }

        private void checkBoxDeinterlace_CheckedChanged(object sender, EventArgs e)
        {
            ManageCheckPanel(checkBoxDeinterlace, panelDeinterlace);

            PictureConfig.Deinterlace = checkBoxDeinterlace.Checked;

            SetOutputInfo();
        }

        private void comboBoxFieldOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.FieldOrder = ((ComboBoxItem)comboBoxFieldOrder.SelectedItem).Value;

            SetOutputInfo();
        }

        private void comboBoxRotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.Rotate = ((ComboBoxIntItem)comboBoxRotate.SelectedItem).Value;

            SetOutputInfo();
        }

        private void checkBoxFlip_CheckedChanged(object sender, EventArgs e)
        {
            PictureConfig.Flip = checkBoxFlip.Checked;

            SetOutputInfo();
        }

        private void comboBoxColorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.ColorFilter = ((ComboBoxItem)comboBoxColorFilter.SelectedItem).Value;

            SetOutputInfo();
        }


        private void numericCropLeft_ValueChanged(object sender, EventArgs e)
        {
            if (inputFile == null)
                return;

            int value = (int)numericCropLeft.Value;
            //if (value % 2 == 1)
            //    value = Math.Max(0, value - 1);
            if (PictureConfig.InputOriginalSize.Width - PictureConfig.Crop.Right - value < 16)
            {
                value = Math.Max(0, PictureConfig.InputOriginalSize.Width - PictureConfig.Crop.Right - 16);
                numericCropLeft.Value = value;
            }
            Crop crop = PictureConfig.Crop;
            crop.Left = value;
            PictureConfig.Crop = crop;
            UpdateCrop();
        }

        private void numericCropRight_ValueChanged(object sender, EventArgs e)
        {
            if (inputFile == null)
                return;

            int value = (int)numericCropRight.Value;
            //if (value % 2 == 1)
            //    value = Math.Max(0, value - 1);
            if (PictureConfig.InputOriginalSize.Width - PictureConfig.Crop.Left - value < 16)
            {
                value = Math.Max(0, PictureConfig.InputOriginalSize.Width - PictureConfig.Crop.Left - 16);
                numericCropRight.Value = value;
            }
            Crop crop = PictureConfig.Crop;
            crop.Right = value;
            PictureConfig.Crop = crop;
            UpdateCrop();
        }

        private void numericCropTop_ValueChanged(object sender, EventArgs e)
        {
            if (inputFile == null)
                return;

            int value = (int)numericCropTop.Value;
            //if (value % 2 == 1)
            //    value = Math.Max(0, value - 1);
            if (PictureConfig.InputOriginalSize.Height - PictureConfig.Crop.Bottom - value < 16)
            {
                value = Math.Max(0, PictureConfig.InputOriginalSize.Height - PictureConfig.Crop.Bottom - 16);
                numericCropTop.Value = value;
            }
            Crop crop = PictureConfig.Crop;
            crop.Top = value;
            PictureConfig.Crop = crop;
            UpdateCrop();
        }

        private void numericCropBottom_ValueChanged(object sender, EventArgs e)
        {
            if (inputFile == null)
                return;

            int value = (int)numericCropBottom.Value;
            //if (value % 2 == 1)
            //    value = Math.Max(0, value - 1);
            if (PictureConfig.InputOriginalSize.Height - PictureConfig.Crop.Top - value < 16)
            {
                value = Math.Max(0, PictureConfig.InputOriginalSize.Height - PictureConfig.Crop.Top - 16);
                numericCropBottom.Value = value;
            }
            Crop crop = PictureConfig.Crop;
            crop.Bottom = value;
            PictureConfig.Crop = crop;
            UpdateCrop();
        }

        private void numericCropTop_Enter(object sender, EventArgs e)
        {
            numericCropTop.Select(0, numericCropTop.Text.Length);
        }

        private void numericCropBottom_Enter(object sender, EventArgs e)
        {
            numericCropBottom.Select(0, numericCropBottom.Text.Length);
        }

        private void numericCropLeft_Enter(object sender, EventArgs e)
        {
            numericCropLeft.Select(0, numericCropLeft.Text.Length);
        }

        private void numericCropRight_Enter(object sender, EventArgs e)
        {
            numericCropRight.Select(0, numericCropRight.Text.Length);
        }

        #endregion

        #region Video

        private void checkBoxConvertVideo_CheckedChanged(object sender, EventArgs e)
        {
            panelVideo.Enabled = checkBoxConvertVideo.Checked;
            panelResize.Enabled = checkBoxConvertVideo.Checked;
            panelDeinterlace.Enabled = checkBoxConvertVideo.Checked;
            panelColorFilter.Enabled = checkBoxConvertVideo.Checked;
            panelSubtitles.Enabled = checkBoxConvertVideo.Checked;

            checkBoxDeinterlace.Enabled = checkBoxConvertVideo.Checked;

            SetOutputInfo();
        }

        private void comboBoxVideoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoConfig.Codec = ((ComboBoxItem)comboBoxVideoCodec.SelectedItem).Value;

            checkBoxCustomX265.Visible = VideoConfig.Codec == "hevc";

            FillVideoCRFAndBitrate();
            SetOutputInfo();
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
            VideoConfig.CRF = trackBarCRF.Value / 10.0f;

            labelCRF.Text = string.Format("{0:0.0}", VideoConfig.CRF);
            SetOutputInfo();
        }

        private void numericUpDownBitrate_ValueChanged(object sender, EventArgs e)
        {
            VideoConfig.Bitrate = (int)Math.Round(numericUpDownBitrate.Value, 0);

            CalcFileSize();
            SetOutputInfo();
        }

        private void comboBoxFrameRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoConfig.FrameRate = ((ComboBoxItem)comboBoxFrameRate.SelectedItem).Value;

            SetOutputInfo();
        }

        private void comboBoxPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoConfig.Preset = ((ComboBoxItem)comboBoxPreset.SelectedItem).Value;
        }

        #endregion

        #region Audio

        private void comboBoxAudioStreams_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckAudioMustConvert();
            UpdateAudioBitrateByChannels();
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

            UpdateAudioBitrateByChannels();
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

        #endregion
        
        #region Functions

        private void SetInputFile(string path)
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

                textBoxIn.Text = "Файл не выбран";
                textBoxOut.Text = "";

                buttonGo.Enabled = false;
                buttonPreview.Enabled = false;
                buttonShowInfo.Enabled = false;
                buttonOpenInputFile.Enabled = false;

                ToggleTabs();

                // reset
                PictureConfig.Reset();
                UpdateCropSizeInfo();
                CalcFileSize();
                SetOutputInfo();
                ClearTags();
                ResetCrop();

                sizeChanged = false;

                textBoxSubtitlesPath.Text = "";

                Text = formTitle;

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

#if DEBUG
            Console.WriteLine(inputFile.StreamInfo);
#endif

            textBoxIn.Text = path;
            Properties.Settings.Default.InPath = Path.GetDirectoryName(path);

            ToggleTabs();

            Text = Path.GetFileName(path) + " - " + formTitle;

            VideoStream vStream = inputFile.VideoStreams[0];

            PictureConfig.Reset();
            PictureConfig.InputOriginalSize = vStream.OriginalSize;
            PictureConfig.InputDisplaySize = vStream.PictureSize;

            numericUpDownHeight.Value = Math.Max(PictureConfig.CropSize.Height, PictureConfig.MinHeight);
            numericUpDownWidth.Value = Math.Max(PictureConfig.CropSize.Width, PictureConfig.MinWidth); // triggered UpdateHeight() if keeping ar

            numericCropTop.Maximum = PictureConfig.InputOriginalSize.Height;
            numericCropBottom.Maximum = PictureConfig.InputOriginalSize.Height;
            numericCropLeft.Maximum = PictureConfig.InputOriginalSize.Width;
            numericCropRight.Maximum = PictureConfig.InputOriginalSize.Width;

            ResetCrop();

            // set original aspect ratio
            FillComboBoxAspectRatio(true);

            sizeChanged = false; // reset after wet WxH in numericUpDown

            // if need deinterlace
            PictureConfig.Deinterlace = checkBoxDeinterlace.Checked = vStream.FieldOrder != "progressive";
            comboBoxFieldOrder.SelectedIndex = 0; // TODO: get from Picture
            ManageCheckPanel(checkBoxDeinterlace, panelDeinterlace);

            ResetRotateAndFlip();

            comboBoxFrameRate.SelectedIndex = 0;

            CheckVideoMustConvert();

            // fill audio streams
            FillAudioStreams();

            // show info
            SetInputInfo();

            CalcFileSize();

            buttonGo.Enabled = true;
            buttonPreview.Enabled = true;
            buttonShowInfo.Enabled = true;
            buttonOpenInputFile.Enabled = true;

            UpdateCropSizeInfo();
            SetOutputInfo();

            SetTagsFromInputFile();

            textBoxSubtitlesPath.Text = "";

            try
            {
                string outDir = "";
                string withoutExtension = Path.GetFileNameWithoutExtension(path);

                if (checkBoxKeepOutPath.Checked)
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
                    // if so many duplicates set name manually
                    if (num > 100)
                        break;
                }
                textBoxOut.Text = outPath;
            }
            catch (Exception) { }
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

            string subtitlesPath = textBoxSubtitlesPath.Text;
            if (!string.IsNullOrWhiteSpace(subtitlesPath) && !File.Exists(subtitlesPath))
            {
                throw new Exception("Файл субтитров не найден!");
            }

            int audioStreamIndex = ((ComboBoxIntItem)comboBoxAudioStreams.SelectedItem).Value;

            bool twoPass = !VideoConfig.UseCRF;

            List<string> videoArgs = new List<string>();
            List<string> audioArgs = new List<string>();

            List<string> specialCrfArgs = new List<string>();
            List<string> specialArgsPass1 = new List<string>();
            List<string> specialArgsPass2 = new List<string>();

            // Video args

            videoArgs.Add($"-map 0:{inputFile.VideoStreams[0].Index}");

            string x264Params = "sar=1/1";
            string x265Params = "sar=1:range=limited";

            if (checkBoxConvertVideo.Checked)
            {
                if (VideoConfig.UseCRF)
                    videoArgs.Add($"-c:v {VideoConfig.Encoder} -crf {VideoConfig.CRF}");
                else
                    videoArgs.Add($"-c:v {VideoConfig.Encoder} -b:v {VideoConfig.Bitrate}k");

                // https://trac.ffmpeg.org/wiki/Encode/H.264
                if (VideoConfig.Encoder == "libx264")
                {
                    // must be configurable
                    string videoProfile = "high";
                    string videoLevel = "";

                    videoArgs.Add("-aq-mode autovariance-biased -fast-pskip 0 -mbtree 0 -pix_fmt yuv420p");

                    if (twoPass)
                        x264Params += ":no-dct-decimate=1";

                    double finalFrameRate = CalcFinalFrameRate();
                    if (finalFrameRate == 0)
                        finalFrameRate = vStream.FrameRate;
                    // force level 4.1, max bitrate for high 4.1 - 62500, use max avg bitrate 50000
                    if (VideoConfig.UseCRF || VideoConfig.Bitrate <= 50000)
                    {
                        if (PictureConfig.OutputSize.Width <= 1920 && PictureConfig.OutputSize.Height <= 1080 && finalFrameRate <= 30.0)
                            videoLevel = " -level 4.1";
                    }

                    videoArgs.Add($"-preset:v {VideoConfig.Preset} -profile:v {videoProfile}{videoLevel}");
                }

                // https://trac.ffmpeg.org/wiki/Encode/H.265
                if (VideoConfig.Encoder == "libx265")
                {
                    videoArgs.Add("-pix_fmt yuv420p");

                    // slow,slower,veryslow,placebo

                    if (checkBoxCustomX265.Checked)
                    {
                        x265Params += ":sao=0:cutree=0";
                    }

                    videoArgs.Add($"-preset:v {VideoConfig.Preset}");
                }

                // Frame rate
                if (!string.IsNullOrWhiteSpace(VideoConfig.FrameRate))
                    videoArgs.Add($"-r {VideoConfig.FrameRate}");

                // Video filters
                string vFilters = GetVideoFilters(subtitlesPath);

                // Add filters to video args
                if (vFilters.Length > 0)
                    videoArgs.Add("-vf \"" + vFilters + "\"");
            }
            else
            {
                twoPass = false; // !!!

                videoArgs.Add($"-c:v copy");
            }

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

            // Meta

            List<string> metadataArgs = new List<string>();

            metadataArgs.Add("-map_chapters -1 -map_metadata -1");
            if (!string.IsNullOrWhiteSpace(TagsConfig.Title))
                metadataArgs.Add($"-metadata title=\"{TagsConfig.Title.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(TagsConfig.Author))
                metadataArgs.Add($"-metadata artist=\"{TagsConfig.Author.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(TagsConfig.Copyright))
                metadataArgs.Add($"-metadata copyright=\"{TagsConfig.Copyright.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(TagsConfig.Comment))
                metadataArgs.Add($"-metadata comment=\"{TagsConfig.Comment.Replace("\"", "\\\"")}\"");
            if (!string.IsNullOrWhiteSpace(TagsConfig.CreationTime))
                metadataArgs.Add($"-metadata creation_time=\"{TagsConfig.CreationTime.Replace("\"", "\\\"")}\"");
            else
                metadataArgs.Add($"-metadata creation_time=\"{DateTime.Now.ToString("o")}\"");

            // mp4

            if (checkBoxWebOptimized.Checked && (fileType == FormatMP4 || fileType == FormatMOV))
            {
                specialArgsPass2.Add("-movflags +faststart");
                specialCrfArgs.Add("-movflags +faststart");
            }

            // Convert

            string[] arguments;

            //string videoParams = $"-x264-params \"{x264Params}\"";
            //string videoParams = $"-x264-params \"{x265Params}\"";

            //slow-firstpass

            string ffmpegFormat;
            if (fileType == FormatMOV)
                ffmpegFormat = "mov";
            else if (fileType == FormatTS)
                ffmpegFormat = "mpegts";
            else if (fileType == FormatMKV)
                ffmpegFormat = "matroska";
            else
                ffmpegFormat = "mp4";

            if (twoPass)
            {
                string passLogFile = GetTempLogFile();
                string twoPassTpl;
                string x26xParams1;
                string x26xParams2;

                if (VideoConfig.Encoder == "libx265")
                {
                    twoPassTpl = "-passlogfile \"{6}\" {0} -x265-params \"pass={5}:{7}\" {1} {2} {3} -f {4}";
                    x26xParams1 = x265Params + ":slow-firstpass=0";
                    x26xParams2 = x265Params;
                }
                else
                {
                    twoPassTpl = "-pass {5} -passlogfile \"{6}\" {0} -x264-params \"{7}\" {1} {2} {3} -f {4}";
                    x26xParams1 = x264Params;
                    x26xParams2 = x264Params;
                }

                arguments = new string[2];
                arguments[0] = string.Format(
                    twoPassTpl,
                    string.Join(" ", videoArgs),
                    "-an",
                    string.Join(" ", specialArgsPass1),
                    "",
                    ffmpegFormat,
                    1,
                    passLogFile,
                    x26xParams1
                );
                arguments[1] = string.Format(
                    twoPassTpl,
                    string.Join(" ", videoArgs),
                    string.Join(" ", audioArgs),
                    string.Join(" ", specialArgsPass2),
                    string.Join(" ", metadataArgs),
                    ffmpegFormat,
                    2,
                    passLogFile,
                    x26xParams2
                );
            }
            else
            {
                string onePassTpl;
                string x26xParams;

                if (VideoConfig.Encoder == "libx265")
                {
                    onePassTpl = "{0} -x265-params \"{5}\" {1} {2} {3} -f {4}";
                    x26xParams = x265Params;
                }
                else
                {
                    onePassTpl = "{0} -x264-params \"{5}\" {1} {2} {3} -f {4}";
                    x26xParams = x264Params;
                }

                arguments = new string[1];
                arguments[0] = string.Format(
                    onePassTpl,
                    string.Join(" ", videoArgs),
                    string.Join(" ", audioArgs),
                    string.Join(" ", specialCrfArgs),
                    string.Join(" ", metadataArgs),
                    ffmpegFormat,
                    x26xParams
                );
            }

            new ConverterForm(input, output, arguments, inputFile.Duration.TotalSeconds).ShowDialog(this);
        }

        #endregion

        private void buttonBrowseSubtitles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = $"Файлы субтитров (SRT, ASS, SSA)|*.srt;*.ass;*.ssa";

                string inPath = Properties.Settings.Default.InPath;
                if (!string.IsNullOrWhiteSpace(inPath) && Directory.Exists(inPath))
                {
                    dialog.InitialDirectory = inPath;
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
                    textBoxSubtitlesPath.Text = dialog.FileName;
                }
            }
        }

        private void buttonDateHelp_Click(object sender, EventArgs e)
        {
            string dateHelp = @"Укажите дату и время в формате ISO 8601
или вида ""yyyy-MM-dd HH:mm:ss""

Примеры:
2005-08-09 18:31:42
2005-08-09T18:31:42
2005-08-09T18:31:42+03:00
2005-08-09T15:31:42.000000Z
2005-08-09T18:31:42.000000+03:00";

            MessageBox.Show(dateHelp, "Поддерживаемые форматы даты", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            string directoryPath = Path.Combine(Environment.CurrentDirectory, "ffmpeg");
            string exePath = Path.Combine(directoryPath, "ffplay.exe");
            if (!File.Exists(exePath))
            {
                MessageBox.Show("Cannot find ffplay.exe", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ffplay -i 00021.MTS -vf "yadif=parity=auto,crop=1440:1080:240:0,scale=640x480:flags=bicubic,hflip,setsar=sar=1/1"

            List<string> videoArgs = new List<string>();
            List<string> audioArgs = new List<string>();

            // Video args

            videoArgs.Add($"-vst {inputFile.VideoStreams[0].Index}");

            if (checkBoxConvertVideo.Checked)
            {
                string subtitlesPath = textBoxSubtitlesPath.Text;

                // Frame rate
                //if (!string.IsNullOrWhiteSpace(VideoConfig.FrameRate))
                //    videoArgs.Add($"-r {VideoConfig.FrameRate}");

                // Video filters
                string vFilters = GetVideoFilters(subtitlesPath);

                // Add filters to video args
                if (vFilters.Length > 0)
                    videoArgs.Add("-vf \"" + vFilters + "\"");
            }

            // Audio args

            int audioStreamIndex = ((ComboBoxIntItem)comboBoxAudioStreams.SelectedItem).Value;

            if (audioStreamIndex == -1)
            {
                audioArgs.Add("-an");
            }
            else
            {
                audioArgs.Add($"-ast {audioStreamIndex}");
            }

            string input = Path.GetFullPath(inputFile.FullPath);

            string arguments = string.Format("{0} {1} -sn", string.Join(" ", videoArgs), string.Join(" ", audioArgs));

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                CreateNoWindow = true,
                UseShellExecute = false,
                Arguments = string.Format("-i \"{0}\" {1} -autoexit -framedrop -window_title Preview", input, arguments)
            };

            startInfo.EnvironmentVariables["FC_CONFIG_DIR"] = directoryPath;
            startInfo.EnvironmentVariables["FONTCONFIG_FILE"] = "fonts.conf";
            startInfo.EnvironmentVariables["FONTCONFIG_PATH"] = directoryPath;

            Process.Start(startInfo);
        }

        /// <summary>
        /// Create content for "vf" argument
        /// </summary>
        /// <param name="subtitlesPath"></param>
        /// <returns></returns>
        private string GetVideoFilters(string subtitlesPath)
        {
            List<string> filters = new List<string>();

            // https://ffmpeg.org/ffmpeg-filters.html#yadif-1
            if (PictureConfig.Deinterlace)
                filters.Add($"yadif=parity={PictureConfig.FieldOrder}");

            // https://ffmpeg.org/ffmpeg-filters.html#crop
            if (PictureConfig.IsCropped())
            {
                // using oar
                int cropW = PictureConfig.InputOriginalSize.Width - PictureConfig.Crop.Left - PictureConfig.Crop.Right;
                int cropH = PictureConfig.InputOriginalSize.Height - PictureConfig.Crop.Top - PictureConfig.Crop.Bottom;
                filters.Add($"crop={cropW}:{cropH}:{PictureConfig.Crop.Left}:{PictureConfig.Crop.Top}");
            }

            // https://ffmpeg.org/ffmpeg-filters.html#scale-1
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

            // https://ffmpeg.org/ffmpeg-filters.html#pad-1
            /*if (PictureConfig.Padding.X > 0 || PictureConfig.Padding.Y > 0)
            {
                filters.Add($"pad={PictureConfig.SelectedSize.Width}:{PictureConfig.SelectedSize.Height}:{PictureConfig.Padding.X}:{PictureConfig.Padding.Y}");
            }*/

            // https://ffmpeg.org/ffmpeg-filters.html#transpose
            if (PictureConfig.Rotate == 180)
                filters.Add("transpose=2,transpose=2");
            else if (PictureConfig.Rotate == 90)
                filters.Add("transpose=1");
            else if (PictureConfig.Rotate == 270)
                filters.Add("transpose=2");

            // https://ffmpeg.org/ffmpeg-filters.html#hflip
            if (PictureConfig.Flip)
                filters.Add("hflip");

            // Set subtitles
            // https://trac.ffmpeg.org/wiki/HowToBurnSubtitlesIntoVideo
            if (!string.IsNullOrWhiteSpace(subtitlesPath) && File.Exists(subtitlesPath))
            {
                // https://ffmpeg.org/ffmpeg-filters.html#Notes-on-filtergraph-escaping
                filters.Add($"subtitles={subtitlesPath.Replace("\\", "\\\\\\\\").Replace("'", "\\\\\\'").Replace(":", "\\\\:").Replace(",", "\\,")}");
            }

            // force sar 1:1
            // https://ffmpeg.org/ffmpeg-filters.html#setdar_002c-setsar
            filters.Add("setsar=sar=1/1");

            // color filter
            // https://ffmpeg.org/ffmpeg-filters.html#colorchannelmixer
            if (PictureConfig.ColorChannelMixerList.ContainsKey(PictureConfig.ColorFilter))
                filters.Add($"colorchannelmixer={PictureConfig.ColorChannelMixerList[PictureConfig.ColorFilter]}");

            return string.Join(",", filters);
        }
    }
}
