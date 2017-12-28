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
        // http://dev.beandog.org/x264_preset_reference.html
        // http://www.videorip.info/x264/71-nekotorye-sovety-nastrojki-kodeka-x264-ot-polzovatelej
        // https://forum.videohelp.com/threads/369463-x264-Tweaking-testing-and-comparing-settings
        private const string FormatMP4 = "mp4";

        // https://www.webmproject.org/docs/container/
        private const string FormatWebM = "webm";

        private InputFile inputFile;

        private string fileInfo;

        private string formTitle;

        private TaskbarManager taskbarManager;

        public MainForm()
        {
            InitializeComponent();

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

            // init crop size
            labelCropSize.Text = "";

            // Format
            string savedFormat = Properties.Settings.Default.OutFormat;
            FillFormat(savedFormat);

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

            FillVideoCodec();

            FillFrameRate();

            // Bitrate
            //numericUpDownBitrate.Maximum = MaxBitrate;
            //numericUpDownBitrate.Value = DefaultBitrate;
            //numericUpDownBitrate.Minimum = MinBitrate;
            //numericUpDownBitrate.Increment = 10;

            FillAudioCodec();
            FillAudioBitrate();
            FillAudioSampleRate();
            FillAudioChannels();

            FillPictureSize();
            FillResizeMethod();
            FillInterpolation();

            FillFieldOrder();
            comboBoxFieldOrder.Enabled = checkBoxDeinterlace.Checked;

            FillColorFilter();

            CalcFileSize(); // just hide labels

            ToggleTabs();

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

            DeleteTempFiles();
        }

        #region In, Out, Format, Go

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

        /// <summary>
        /// Call after crop window closed
        /// </summary>
        public void UpdateCrop(Crop newCrop)
        {
            PictureConfig.Crop = newCrop;
            UpdateCroppedPictureSizeInfo();
            SetOutputInfo();
        }

        private void buttonCrop_Click(object sender, EventArgs e)
        {
            new CropForm(inputFile, PictureConfig.Crop).ShowDialog(this);
        }

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

        private void comboBoxColorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureConfig.ColorFilter = ((ComboBoxItem)comboBoxColorFilter.SelectedItem).Value;

            SetOutputInfo();
        }

        #endregion

        #region Video

        private void comboBoxVideoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoConfig.Codec = ((ComboBoxItem)comboBoxVideoCodec.SelectedItem).Value;

            // change audio codec to default for selected video codec
            if (VideoConfig.DefaultAudioCodecs != null && VideoConfig.DefaultAudioCodecs.ContainsKey(VideoConfig.Codec))
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
            VideoConfig.CRF = trackBarCRF.Value;

            labelCRF.Text = $"{trackBarCRF.Value}";
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

        #endregion
        
        #region Functions

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

                ToggleTabs();

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

            ToggleTabs();

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

            int audioStreamIndex = ((ComboBoxIntItem)comboBoxAudioStreams.SelectedItem).Value;

            bool twoPass = !VideoConfig.UseCRF;

            List<string> videoArgs = new List<string>();
            List<string> audioArgs = new List<string>();

            string specialCrfArgs = "";
            string specialArgsPass1 = "";
            string specialArgsPass2 = "";

            // Video args

            videoArgs.Add($"-map 0:{inputFile.VideoStreams[0].Index}");

            if (VideoConfig.UseCRF)
                videoArgs.Add($"-c:v {VideoConfig.Encoder} -crf {VideoConfig.CRF} {VideoConfig.AdditionalArguments}");
            else
                videoArgs.Add($"-c:v {VideoConfig.Encoder} -b:v {VideoConfig.Bitrate}k {AudioConfig.AdditionalArguments}");

            // https://trac.ffmpeg.org/wiki/Encode/H.264
            if (VideoConfig.Encoder == "libx264")
            {
                // must be configurable
                string videoPreset = "veryslow";
                string videoProfile = "high";
                string videoLevel = "";

                string x264Params = "sar=1/1";
                if (twoPass)
                    x264Params += ":no-dct-decimate=1";

                string videoParams = $"-x264-params \"{x264Params}\"";

                double finalFrameRate = CalcFinalFrameRate();
                if (finalFrameRate == 0)
                    finalFrameRate = vStream.FrameRate;
                // force level 4.1, max bitrate for high 4.1 - 62500, use max avg bitrate 50000
                if (VideoConfig.UseCRF || VideoConfig.Bitrate <= 50000)
                {
                    if (PictureConfig.OutputSize.Width <= 1920 && PictureConfig.OutputSize.Height <= 1080 && finalFrameRate <= 30.0)
                        videoLevel = " -level 4.1";
                }

                videoArgs.Add($"-preset:v {videoPreset} -profile:v {videoProfile}{videoLevel} {videoParams}");
            }

            // https://trac.ffmpeg.org/wiki/Encode/H.265
            if (VideoConfig.Encoder == "libx265")
            {
                // must be configurable
                //string videoPreset = "veryslow";

                //videoArgs.Add($"-preset:v {videoPreset}");
            }

            // https://trac.ffmpeg.org/wiki/Encode/VP9
            if (VideoConfig.Encoder == "libvpx-vp9")
            {
                if (VideoConfig.UseCRF)
                    videoArgs.Add("-b:v 0");

                int threads = Environment.ProcessorCount;
                videoArgs.Add($"-threads {threads}");

                specialArgsPass1 = "-cpu-used 4";
                specialArgsPass2 = "-cpu-used 1";

                specialCrfArgs = "-cpu-used 1";
            }

            // https://trac.ffmpeg.org/wiki/Encode/VP8
            if (VideoConfig.Encoder == "libvpx")
            {
                int threads = Environment.ProcessorCount;
                videoArgs.Add($"-threads {threads}");
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

            // Frame rate
            if (!string.IsNullOrWhiteSpace(VideoConfig.FrameRate))
                videoArgs.Add($"-r {VideoConfig.FrameRate}");

            // Add filters to video args
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
                if (VideoConfig.Encoder == "libx265")
                    twoPassTpl = "-x265-params pass={3} -passlogfile \"{4}\" {0} {1} {2} {4}";

                arguments = new string[2];
                arguments[0] = string.Format(twoPassTpl, string.Join(" ", videoArgs), (VideoConfig.NoAudioInFirstPass ? "-an" : string.Join(" ", audioArgs)), string.Join(" ", moreArgs), 1, passLogFile, specialArgsPass1);
                arguments[1] = string.Format(twoPassTpl, string.Join(" ", videoArgs), string.Join(" ", audioArgs), string.Join(" ", moreArgs), 2, passLogFile, specialArgsPass2);
            }
            else
            {
                arguments = new string[1];
                arguments[0] = string.Format("{0} {1} {2} {3}", string.Join(" ", videoArgs), string.Join(" ", audioArgs), string.Join(" ", moreArgs), specialCrfArgs);
            }

            new ConverterForm(input, output, arguments, inputFile.Duration.TotalSeconds).ShowDialog(this);
        }

        #endregion
    }
}
