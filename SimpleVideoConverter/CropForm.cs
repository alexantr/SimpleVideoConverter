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

        private FFmpegProcess ffmpegProcess;

        private string tempFile;

        private Timer timer;
        private bool processEnded;
        private bool processPanic;

        private Dictionary<string, Image> images; // time: Image

        private double totalTime, currentTime, stepTime;

        private int cropLeft, cropTop, cropRight, cropBottom;

        int[] size;

        private TaskbarManager taskbarManager;

        public CropForm(VideoFile v, int cropL, int cropT, int cropR, int cropB)
        {
            InitializeComponent();

            videoFile = v;
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
            int wCrop = stream.PictureSize.Width;
            int hCrop = stream.PictureSize.Height;
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
            ((MainForm)Owner).SetCropValues((int)numericCropLeft.Value, (int)numericCropTop.Value, (int)numericCropRight.Value, (int)numericCropBottom.Value);

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

        private void numericCropTop_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropTop.Value % 2 == 1)
                numericCropTop.Value = Math.Max(0, (int)numericCropTop.Value - 1);
            LoadPicture();
        }

        private void numericCropBottom_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropBottom.Value % 2 == 1)
                numericCropBottom.Value = Math.Max(0, (int)numericCropBottom.Value - 1);
            LoadPicture();
        }

        private void numericCropLeft_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropLeft.Value % 2 == 1)
                numericCropLeft.Value = Math.Max(0, (int)numericCropLeft.Value - 1);
            LoadPicture();
        }

        private void numericCropRight_ValueChanged(object sender, EventArgs e)
        {
            if ((int)numericCropRight.Value % 2 == 1)
                numericCropRight.Value = Math.Max(0, (int)numericCropRight.Value - 1);
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

            string arguments = $"-ss {currTime} -i \"{videoFile.FullPath}\" -vframes 1 -f mjpeg \"{tempFile}\"";

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

            var process = ffmpegProcess;

            if (!process.HasExited)
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
                    Bitmap resized = DrawImageWithRects(img);

                    string dur = new TimeSpan((long)currentTime * 10000L).ToString("hh\\:mm\\:ss\\.fff");
                    if (!images.ContainsKey(dur))
                        images.Add(dur, resized);

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

        private Bitmap DrawImageWithRects(Image image)
        {
            int width = size[0];
            int height = size[1];
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap resized = new Bitmap(width, height);
            resized.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.Bicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (ImageAttributes imageAttr = new ImageAttributes())
                {
                    imageAttr.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttr);
                }
                Color customColor = Color.FromArgb(255, 0, 255);
                SolidBrush brush = new SolidBrush(customColor);

                VideoStream stream = videoFile.VideoStreams[0];
                int vWidth = stream.PictureSize.Width;
                int vHeight = stream.PictureSize.Height;

                double aspectRatio = Math.Min((double)pictureBoxPreview.Width / vWidth, (double)pictureBoxPreview.Height / vHeight);

                int bottomH = (int)Math.Round((double)numericCropBottom.Value * aspectRatio);
                int rightW = (int)Math.Round((double)numericCropRight.Value * aspectRatio);

                RectangleF[] rects = new RectangleF[4];
                rects[0] = new Rectangle(0, 0, width, (int)Math.Round((double)numericCropTop.Value * aspectRatio)); // top
                rects[1] = new Rectangle(0, height - bottomH, width, bottomH); // bottom
                rects[2] = new Rectangle(0, 0, (int)Math.Round((double)numericCropLeft.Value * aspectRatio), height); // left
                rects[3] = new Rectangle(width - rightW, 0, rightW, height); // right

                g.FillRectangles(brush, rects);
                g.Dispose(); 
            }
            pictureBoxPreview.Image = resized;
            return resized;
        }

        private int[] GetWidthHeight()
        {
            VideoStream stream = videoFile.VideoStreams[0];
            int width = stream.PictureSize.Width;
            int height = stream.PictureSize.Height;

            double aspectRatio = Math.Min((double)pictureBoxPreview.Width / width, (double)pictureBoxPreview.Height / height);

            int newWidth = (int)Math.Round(width * aspectRatio, 0);
            int newHeight = (int)Math.Round(height * aspectRatio, 0);

            Console.WriteLine($"{newWidth} x {newHeight}");

            if (newHeight % 2 == 1)
                newHeight -= 1;
            if (newHeight < 96)
                newHeight = 96;

            return new int[2] { newWidth, newHeight };
        }
    }
}
