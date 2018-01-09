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
    public partial class MainForm
    {
        // http://dev.beandog.org/x264_preset_reference.html
        // http://www.videorip.info/x264/71-nekotorye-sovety-nastrojki-kodeka-x264-ot-polzovatelej
        // https://forum.videohelp.com/threads/369463-x264-Tweaking-testing-and-comparing-settings
        private const string FormatMP4 = "mp4";

        // https://www.webmproject.org/docs/container/
        private const string FormatWebM = "webm";

        private char[] invalidChars = Path.GetInvalidPathChars();

        private List<string> tempFilesList = new List<string>();

        #region Form

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

        private void ToggleTabs()
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

        #endregion

        #region Format

        private void FillFormat(string savedFormat)
        {
            int selectedIndex = 0, index = 0;
            comboBoxFileType.Items.Clear();
            foreach (KeyValuePair<string, string> f in FormatConfig.FormatList)
            {
                comboBoxFileType.Items.Add(new ComboBoxItem(f.Key, f.Value));
                if (f.Key == savedFormat)
                    selectedIndex = index;
                index++;
            }
            comboBoxFileType.SelectedIndex = selectedIndex;
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

        #endregion

        #region Video

        private void FillVideoCodec()
        {
            int selectedIndex = 0, index = 0;
            comboBoxVideoCodec.Items.Clear();
            foreach (KeyValuePair<string, string> c in VideoConfig.CodecList)
            {
                comboBoxVideoCodec.Items.Add(new ComboBoxItem(c.Key, c.Value));
                if (c.Key == VideoConfig.Codec)
                    selectedIndex = index;
                index++;
            }
            comboBoxVideoCodec.SelectedIndex = selectedIndex;
        }

        private void FillVideoCRFAndBitrate()
        {
            if (VideoConfig.CRFSupported)
            {
                int crf = VideoConfig.CRF;
                if (trackBarCRF.Value > VideoConfig.CRFMaxValue)
                    trackBarCRF.Value = VideoConfig.CRFMaxValue;
                if (trackBarCRF.Value < VideoConfig.CRFMinValue)
                    trackBarCRF.Value = VideoConfig.CRFMinValue;

                trackBarCRF.Minimum = VideoConfig.CRFMinValue;
                trackBarCRF.Maximum = VideoConfig.CRFMaxValue;
                trackBarCRF.Value = crf;

                radioButtonCRF.Enabled = true;
            }
            else
            {
                radioButtonCRF.Checked = false;
                radioButtonCRF.Enabled = false;
                radioButtonBitrate.Checked = true;
            }

            int bitrate = VideoConfig.Bitrate;
            if (numericUpDownBitrate.Value > VideoConfig.BitrateMaxValue)
                numericUpDownBitrate.Value = VideoConfig.BitrateMaxValue;
            if (numericUpDownBitrate.Value < VideoConfig.BitrateMinValue)
                numericUpDownBitrate.Value = VideoConfig.BitrateMinValue;

            numericUpDownBitrate.Minimum = VideoConfig.BitrateMinValue;
            numericUpDownBitrate.Maximum = VideoConfig.BitrateMaxValue;
            numericUpDownBitrate.Value = bitrate;

            // check if nothing checked
            if (!radioButtonCRF.Checked && !radioButtonBitrate.Checked)
            {
                if (radioButtonCRF.Enabled)
                    radioButtonCRF.Checked = true;
                else
                    radioButtonBitrate.Checked = true;
            }

            CheckVideoModeRadioButtons();
        }

        private void FillFrameRate()
        {
            comboBoxFrameRate.Items.Clear();
            comboBoxFrameRate.Items.Add(new ComboBoxItem(string.Empty, "Исходная"));
            foreach (KeyValuePair<string, string> fr in VideoConfig.FrameRateList)
            {
                comboBoxFrameRate.Items.Add(new ComboBoxItem(fr.Key, fr.Value));
            }
            comboBoxFrameRate.SelectedIndex = 0;
        }

        private void CheckVideoModeRadioButtons()
        {
            VideoConfig.UseCRF = radioButtonCRF.Checked;

            trackBarCRF.Enabled = radioButtonCRF.Checked;
            labelMinQ.Enabled = radioButtonCRF.Checked;
            labelMaxQ.Enabled = radioButtonCRF.Checked;

            numericUpDownBitrate.Enabled = radioButtonBitrate.Checked;
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

        #endregion

        #region Audio

        private void FillAudioCodec()
        {
            int selectedIndex = 0, index = 0;
            comboBoxAudioCodec.Items.Clear();
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
            int selectedIndex = 0, index = 0;
            comboBoxAudioBitrate.Items.Clear();
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
            int selectedIndex = 0, index = 0;
            comboBoxAudioSampleRate.Items.Clear();
            comboBoxAudioSampleRate.Items.Add(new ComboBoxIntItem(0, "Исходная"));
            foreach (int sr in AudioConfig.SampleRateList)
            {
                comboBoxAudioSampleRate.Items.Add(new ComboBoxIntItem(sr, sr.ToString()));
                if (sr == AudioConfig.SampleRate)
                    selectedIndex = index;
                index++;
            }
            comboBoxAudioSampleRate.SelectedIndex = selectedIndex;
        }

        private void FillAudioChannels()
        {
            comboBoxAudioChannels.Items.Clear();
            foreach (KeyValuePair<int, string> ch in AudioConfig.ChannelsList)
            {
                comboBoxAudioChannels.Items.Add(new ComboBoxIntItem(ch.Key, ch.Value));
            }
            comboBoxAudioChannels.SelectedIndex = 0;
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
            UpdateAudioBitrateByChannels();
        }

        private void CheckAudioMustConvert()
        {
            if (inputFile == null || comboBoxAudioStreams.SelectedIndex < 1)
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
                        else if (FormatConfig.Format == FormatWebM && aStream.CodecName.Equals("vorbis", StringComparison.OrdinalIgnoreCase))
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

        private void UpdateAudioBitrateByChannels()
        {
            if (inputFile == null || comboBoxAudioStreams.SelectedIndex < 1)
                return;

            int streamIndex = ((ComboBoxIntItem)comboBoxAudioStreams.SelectedItem).Value;

            foreach (AudioStream aStream in inputFile.AudioStreams)
            {
                if (aStream.Index == streamIndex)
                {
                    int selectedIndex = -1, index = 0;

                    int defaultBitrate = aStream.Channels > 2 && AudioConfig.Channels == 0 ? AudioConfig.DefaultBitrateForMultiChannels : AudioConfig.DefaultBitrate;
                    foreach (ComboBoxIntItem item in comboBoxAudioBitrate.Items)
                    {
                        if (defaultBitrate == item.Value)
                            selectedIndex = index;
                        index++;
                    }

                    if (selectedIndex >= 0)
                        comboBoxAudioBitrate.SelectedIndex = selectedIndex;
                }
            }
        }

        #endregion

        #region Picture

        private void UpdateHeigth(bool forceUpdateHeight = false, int maxHeight = 0)
        {
            pictureBoxRatioError.BackgroundImage = null;
            if (!checkBoxKeepAspectRatio.Checked && !forceUpdateHeight)
                return;
            if (maxHeight == 0 || maxHeight > PictureConfig.MaxHeight)
                maxHeight = PictureConfig.MaxHeight;
            int width = (int)Math.Round(numericUpDownWidth.Value, 0);
            double aspectRatio = GetParsedAspectRatio();
            if (aspectRatio > 0.0)
            {
                int newHeight = (int)Math.Round(width / aspectRatio, 0);
                if (newHeight % 2 == 1)
                    newHeight -= 1;
                bool overHeight = false;
                if (newHeight < PictureConfig.MinHeight)
                {
                    newHeight = PictureConfig.MinHeight;
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
                    if (newWidth % 2 == 1)
                        newWidth -= 1;
                    if (newWidth > PictureConfig.MaxWidth)
                        newWidth = PictureConfig.MaxWidth;
                    else if (newWidth < PictureConfig.MinWidth)
                        newWidth = PictureConfig.MinWidth;
                    numericUpDownWidth.Value = newWidth;
                }
            }
            else if (checkBoxResizePicture.Checked)
            {
                pictureBoxRatioError.BackgroundImage = Properties.Resources.critical;
            }
        }

        private double GetParsedAspectRatio()
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

        private void UpdateAspectRatio()
        {
            if (inputFile == null)
                return;
            if (!checkBoxResizePicture.Checked)
            {
                numericUpDownWidth.Value = PictureConfig.CropSize.Width;
                numericUpDownHeight.Value = PictureConfig.CropSize.Height;
            }
            FillComboBoxAspectRatio();
        }

        private void ResizeFromPreset(int w, int h)
        {
            numericUpDownWidth.Value = w;
            UpdateHeigth(true, h);
        }

        private void UpdateCropSizeInfo()
        {
            if (inputFile == null)
            {
                labelCropSize.Text = "";
                return;
            }
            if (PictureConfig.IsCropped())
                labelCropSize.Text = $"{PictureConfig.InputDisplaySize.ToString()} → {PictureConfig.CropSize.ToString()}";
            else
                labelCropSize.Text = "";
        }

        private void FillComboBoxAspectRatio(bool resetIndex = false)
        {
            int prevIndex = comboBoxAspectRatio.SelectedIndex;
            string prevText = comboBoxAspectRatio.Text;

            string sourceAR = $"{PictureConfig.CropSize.Width}:{PictureConfig.CropSize.Height}";

            comboBoxAspectRatio.Text = string.Empty;
            comboBoxAspectRatio.Items.Clear();
            comboBoxAspectRatio.Items.Add(new ComboBoxItem(sourceAR, "Исходные"));
            foreach (string aspectRatio in PictureConfig.AspectRatioList)
            {
                comboBoxAspectRatio.Items.Add(new ComboBoxItem(aspectRatio, aspectRatio));
            }

            if (resetIndex)
                comboBoxAspectRatio.SelectedIndex = 0;
            else if (prevIndex < 0 && !string.IsNullOrWhiteSpace(prevText))
                comboBoxAspectRatio.Text = prevText;
            else
                comboBoxAspectRatio.SelectedIndex = prevIndex > 0 ? prevIndex : 0;
        }

        private void FillInterpolation()
        {
            int selectedIndex = 0, index = 0;
            comboBoxInterpolation.Items.Clear();
            foreach (KeyValuePair<string, string> rm in PictureConfig.InterpolationList)
            {
                comboBoxInterpolation.Items.Add(new ComboBoxItem(rm.Key, rm.Value));
                if (rm.Key == PictureConfig.DefaultInterpolation)
                    selectedIndex = index;
                index++;
            }
            comboBoxInterpolation.SelectedIndex = selectedIndex;
        }

        private void FillFieldOrder()
        {
            int selectedIndex = 0, index = 0;
            comboBoxFieldOrder.Items.Clear();
            foreach (KeyValuePair<string, string> rm in PictureConfig.FieldOrderList)
            {
                comboBoxFieldOrder.Items.Add(new ComboBoxItem(rm.Key, rm.Value));
                if (rm.Key == PictureConfig.DefaultFieldOrder)
                    selectedIndex = index;
                index++;
            }
            comboBoxFieldOrder.SelectedIndex = selectedIndex;
        }

        private void FillColorFilter()
        {
            int selectedIndex = 0, index = 0;
            comboBoxColorFilter.Items.Clear();
            foreach (KeyValuePair<string, string> rm in PictureConfig.ColorFilterList)
            {
                comboBoxColorFilter.Items.Add(new ComboBoxItem(rm.Key, rm.Value));
                if (rm.Key == PictureConfig.DefaultColorFilter)
                    selectedIndex = index;
                index++;
            }
            comboBoxColorFilter.SelectedIndex = selectedIndex;
        }

        #endregion

        #region Tags

        private void SetTagsFromInputFile()
        {
            ClearTags();
            textBoxTagTitle.Text = inputFile.Tags.Title;
            textBoxTagAuthor.Text = inputFile.Tags.Author;
            textBoxTagCopyright.Text = inputFile.Tags.Copyright;
            textBoxTagComment.Text = inputFile.Tags.Comment;
            textBoxTagCreationTime.Text = inputFile.Tags.CreationTime;
        }

        private void ClearTags()
        {
            textBoxTagTitle.Text = "";
            textBoxTagAuthor.Text = "";
            textBoxTagCopyright.Text = "";
            textBoxTagComment.Text = "";
            textBoxTagCreationTime.Text = "";
            TagsConfig.Clear();
        }

        #endregion

        #region Info

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

            double fileSize = (VideoConfig.Bitrate * duration / 8.0) / 1024.0; // MiB

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

            /*if (PictureConfig.Padding.X > 0 || PictureConfig.Padding.Y > 0)
            {
                PictureSize fullSize = new PictureSize();
                fullSize.Width = PictureConfig.OutputSize.Width + PictureConfig.Padding.X + PictureConfig.Padding.X;
                fullSize.Height = PictureConfig.OutputSize.Height + PictureConfig.Padding.Y + PictureConfig.Padding.Y;
                info.Append($", {fullSize.ToString()} ({PictureConfig.OutputSize.ToString()})");
            }
            else
            {*/
            info.Append($", {PictureConfig.OutputSize.ToString()}");
            //}

            /*if (PictureConfig.IsResized())
            {
                if (PictureConfig.ResizeMethodList.ContainsKey(PictureConfig.ResizeMethod))
                    info.Append($", {PictureConfig.ResizeMethodList[PictureConfig.ResizeMethod].ToLower()}");
                else
                    info.Append($", {PictureConfig.ResizeMethod}");
            }*/

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

        #endregion

        #region Temp Files

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

        private void DeleteTempFiles()
        {
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

        #region Other

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
