using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Alexantr.SimpleVideoConverter
{
    public partial class CropForm : Form
    {
        private readonly VideoFile videoFile;

        private string tempFile;

        private FFmpegProcess ffmpegProcess;

        private Timer timer;
        private bool processEnded;
        private bool processPanic;

        private Dictionary<string, Image> images;

        private double totalTime, currentTime, stepTime;

        private int cropLeft, cropTop, cropRight, cropBottom;

        private int[] size;

        private TaskbarManager taskbarManager;

        private bool resizing = false;

        public CropForm(VideoFile vFile, int cropL, int cropT, int cropR, int cropB)
        {
            InitializeComponent();

            videoFile = vFile;
            cropLeft = cropL;
            cropTop = cropT;
            cropRight = cropR;
            cropBottom = cropB;

            images = new Dictionary<string, Image>();

            taskbarManager = TaskbarManager.Instance;
        }

        private void CropForm_Load(object sender, EventArgs e)
        {
            tempFile = ((MainForm)Owner).GetTempFile();

            totalTime = videoFile.Duration.TotalMilliseconds;
            stepTime = totalTime / 10;

            currentTime = totalTime / 2;

            pictureBoxPreview.SizeMode = PictureBoxSizeMode.CenterImage;

            size = GetWidthHeight();

            // Update values for crop
            VideoStream stream = videoFile.VideoStreams[0];
            int wCrop = stream.OriginalSize.Width;
            int hCrop = stream.OriginalSize.Height;
            decimal maxLeft = (wCrop - MainForm.MinWidth) / 2;
            decimal maxTop = (hCrop - MainForm.MinHeight) / 2;
            // set max values to prevent exceptions
            numericCropTop.Maximum = maxTop;
            numericCropBottom.Maximum = maxTop;
            numericCropLeft.Maximum = maxLeft;
            numericCropRight.Maximum = maxLeft;
            // set values
            numericCropTop.Value = cropTop;
            numericCropBottom.Value = cropBottom;
            numericCropLeft.Value = cropLeft;
            numericCropRight.Value = cropRight;

            CheckButtons();

            LoadPicture();
        }

        private void CropForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            processPanic = true; //Shut down while avoiding exceptions
            buttonSave_Click(sender, e);
            taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
        }

        private void CropForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ffmpegProcess.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ((MainForm)Owner).SetCropValues(cropLeft, cropTop, cropRight, cropBottom);

            if (!processEnded || processPanic)
            {
                if (!ffmpegProcess.HasExited)
                {
                    ffmpegProcess.Kill();
                }
            }
            else
            {
                Close();
            }
        }

        private void buttonRew_Click(object sender, EventArgs e)
        {
            currentTime -= stepTime;
            LoadPicture();
        }

        private void buttonFF_Click(object sender, EventArgs e)
        {
            currentTime += stepTime;
            LoadPicture();
        }

        private void numericCropLeft_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropLeft.Value % 2 == 1)
                numericCropLeft.Value = Math.Max(0, (int)numericCropLeft.Value - 1);
            cropLeft = (int)numericCropLeft.Value;
            LoadPicture();
        }

        private void numericCropTop_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropTop.Value % 2 == 1)
                numericCropTop.Value = Math.Max(0, (int)numericCropTop.Value - 1);
            cropTop = (int)numericCropTop.Value;
            LoadPicture();
        }

        private void numericCropRight_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropRight.Value % 2 == 1)
                numericCropRight.Value = Math.Max(0, (int)numericCropRight.Value - 1);
            cropRight = (int)numericCropRight.Value;
            LoadPicture();
        }

        private void numericCropBottom_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropBottom.Value % 2 == 1)
                numericCropBottom.Value = Math.Max(0, (int)numericCropBottom.Value - 1);
            cropBottom = (int)numericCropBottom.Value;
            LoadPicture();
        }

        private void LoadPicture()
        {
            string currTime = GetCorrectedTime();
            labelTime.Text = currTime;

            if (images.ContainsKey(currTime))
            {
                DrawImageWithRects(images[currTime]);
                CheckButtons();
                return;
            }

            buttonRew.Enabled = false;
            buttonFF.Enabled = false;
            numericCropBottom.Enabled = false;
            numericCropLeft.Enabled = false;
            numericCropRight.Enabled = false;
            numericCropTop.Enabled = false;

            labelLoading.Visible = true;

            Console.WriteLine(currTime);

            string filters = "";
            if (videoFile.VideoStreams[0].FieldOrder != "progressive")
            {
                filters = " -vf \"yadif\"";
            }

            string arguments = $"-ss {currTime} -i \"{videoFile.FullPath}\"{filters} -vframes 1 -f mjpeg \"{tempFile}\"";

            ffmpegProcess = new FFmpegProcess(arguments);
            ffmpegProcess.Exited += (o, args) => pictureBoxPreview.Invoke((Action)(() =>
            {
                if (processPanic) return; //This should stop that one exception when closing the converter

                //buttonCancel.Enabled = false;

                timer = new Timer();
                timer.Interval = 100;
                timer.Tick += Exited;
                timer.Start();
            }));

            taskbarManager.SetProgressState(TaskbarProgressBarState.Indeterminate);

            ffmpegProcess.Start();
        }

        private string GetCorrectedTime()
        {
            double correctedTime = currentTime;
            if (correctedTime > totalTime - 1000.0)
                correctedTime -= 1000.0;
            else if (correctedTime < 1000.0)
                correctedTime += 1000.0;
            return new TimeSpan((long)correctedTime * 10000L).ToString("hh\\:mm\\:ss\\.fff");
        }

        private void CropForm_SizeChanged(object sender, EventArgs e)
        {
            //Console.WriteLine($"Resized {pictureBoxPreview.Width} {pictureBoxPreview.Height}");
            size = GetWidthHeight();
            LoadPicture();
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

        private void CheckButtons()
        {
            buttonRew.Enabled = (currentTime - stepTime >= 0.0);
            buttonFF.Enabled = (currentTime + stepTime <= totalTime);
            numericCropBottom.Enabled = true;
            numericCropLeft.Enabled = true;
            numericCropRight.Enabled = true;
            numericCropTop.Enabled = true;
        }

        private void Exited(object sender, EventArgs eventArgs)
        {
            timer.Stop();

            if (processPanic) return;

            var process = ffmpegProcess;

            if (process != null && !process.HasExited)
            {
                Console.WriteLine("Not yet exited");

                timer = new Timer();
                timer.Interval = 100;
                timer.Tick += Exited;
                timer.Start();
                return;
            }

            if (process.ExitCode != 0)
            {
                labelLoading.Visible = false;
                taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                MessageBox.Show($"ffmpeg.exe exited with exit code {process.ExitCode}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    Image img = ImageHelper.FromFile(tempFile);
                    DrawImageWithRects(img);

                    string dur = new TimeSpan((long)currentTime * 10000L).ToString("hh\\:mm\\:ss\\.fff");
                    if (!images.ContainsKey(dur))
                        images.Add(dur, img);

                    CheckButtons();

                    labelLoading.Visible = false;
                    taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                }
                catch (Exception ex)
                {
                    labelLoading.Visible = false;
                    taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            processEnded = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            numericCropTop.Value = 0;
            numericCropBottom.Value = 0;
            numericCropLeft.Value = 0;
            numericCropRight.Value = 0;
            LoadPicture();
        }

        private void DrawImageWithRects(Image image)
        {
            if (resizing)
                return;
            resizing = true;
            int width = size[0];
            int height = size[1];
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap resized = new Bitmap(width, height);
            resized.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.InterpolationMode = InterpolationMode.Bicubic;
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                using (ImageAttributes imageAttr = new ImageAttributes())
                {
                    imageAttr.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttr);
                }
                Color customColor = Color.FromArgb(255, 0, 255);
                SolidBrush brush = new SolidBrush(customColor);

                VideoStream stream = videoFile.VideoStreams[0];
                int vWidth = stream.OriginalSize.Width;
                int vHeight = stream.OriginalSize.Height;

                int maxBoxWidth = Math.Min(pictureBoxPreview.Width, vWidth);
                int maxBoxHeight = Math.Min(pictureBoxPreview.Height, vHeight);

                double aspectRatio = Math.Min((double)maxBoxWidth / vWidth, (double)maxBoxHeight / vHeight);

                int topH = (int)Math.Round(cropTop * aspectRatio);
                int bottomH = (int)Math.Round(cropBottom * aspectRatio);
                int leftW = (int)Math.Round(cropLeft * aspectRatio);
                int rightW = (int)Math.Round(cropRight * aspectRatio);

                int rectangles = 0;
                if (topH > 0)
                    rectangles++;
                if (bottomH > 0)
                    rectangles++;
                if (leftW > 0)
                    rectangles++;
                if (rightW > 0)
                    rectangles++;

                if (rectangles > 0)
                {
                    RectangleF[] rects = new RectangleF[rectangles];
                    int indexCount = 0;
                    if (topH > 0)
                    {
                        rects[indexCount] = new Rectangle(0, 0, width, topH); // top
                        indexCount++;
                    }
                    if (bottomH > 0)
                    {
                        rects[indexCount] = new Rectangle(0, height - bottomH, width, bottomH); // bottom
                        indexCount++;
                    }
                    if (leftW > 0)
                    {
                        rects[indexCount] = new Rectangle(0, 0, leftW, height); // left
                        indexCount++;
                    }
                    if (rightW > 0)
                    {
                        rects[indexCount] = new Rectangle(width - rightW, 0, rightW, height); // right
                    }
                    g.FillRectangles(brush, rects);
                }

                g.Dispose(); 
            }
            pictureBoxPreview.Image = resized;
            resizing = false;
        }

        private int[] GetWidthHeight()
        {
            VideoStream stream = videoFile.VideoStreams[0];
            int vWidth = stream.OriginalSize.Width;
            int vHeight = stream.OriginalSize.Height;

            int maxBoxWidth = Math.Min(pictureBoxPreview.Width, vWidth);
            int maxBoxHeight = Math.Min(pictureBoxPreview.Height, vHeight);

            double aspectRatio = Math.Min((double)maxBoxWidth / vWidth, (double)maxBoxHeight / vHeight);

            int newWidth = (int)Math.Round(vWidth * aspectRatio, 0);
            int newHeight = (int)Math.Round(vHeight * aspectRatio, 0);

            Console.WriteLine($"{newWidth} x {newHeight}");

            if (newHeight % 2 == 1)
                newHeight -= 1;
            if (newHeight < 96)
                newHeight = 96;

            return new int[2] { newWidth, newHeight };
        }
    }
}
