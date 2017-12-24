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
        private readonly InputFile inputFile;
        private readonly PictureSize originalSize;

        private string tempFile;

        private FFmpegProcess ffmpegProcess;

        private Timer timer;
        private bool processEnded;
        private bool processPanic;

        private Dictionary<string, Image> images;

        private double totalTime, currentTime, stepTime;

        private Crop crop;

        private int[] size;

        private TaskbarManager taskbarManager;

        private bool resizing = false;

        public CropForm(InputFile inpFile, Crop picCrop)
        {
            InitializeComponent();

            inputFile = inpFile;
            crop = picCrop;

            VideoStream stream = inputFile.VideoStreams[0];

            originalSize = new PictureSize()
            {
                Width = stream.OriginalSize.Width,
                Height = stream.OriginalSize.Height
            };

            images = new Dictionary<string, Image>();

            taskbarManager = TaskbarManager.Instance;
        }

        private void CropForm_Load(object sender, EventArgs e)
        {
            tempFile = ((MainForm)Owner).GetTempFile();

            totalTime = inputFile.Duration.TotalMilliseconds;
            stepTime = totalTime / 10;

            currentTime = totalTime / 2;

            size = GetWidthHeight();

            // set max values
            numericCropTop.Maximum = originalSize.Height;
            numericCropBottom.Maximum = originalSize.Height;
            numericCropLeft.Maximum = originalSize.Width;
            numericCropRight.Maximum = originalSize.Width;
            // set values
            numericCropTop.Value = crop.Top;
            numericCropBottom.Value = crop.Bottom;
            numericCropLeft.Value = crop.Left;
            numericCropRight.Value = crop.Right;

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
            ((MainForm)Owner).UpdateCrop(crop);

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
            int value = (int)numericCropLeft.Value;
            if (value % 2 == 1)
                value = Math.Max(0, value - 1);
            if (originalSize.Width - crop.Right - value < PictureConfig.MinWidth)
            {
                value = originalSize.Width - crop.Right - PictureConfig.MinWidth;
                numericCropLeft.Value = value;
            }
            crop.Left = value;
            LoadPicture();
        }

        private void numericCropRight_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericCropRight.Value;
            if (value % 2 == 1)
                value = Math.Max(0, value - 1);
            if (originalSize.Width - crop.Left - value < PictureConfig.MinWidth)
            {
                value = originalSize.Width - crop.Left - PictureConfig.MinWidth;
                numericCropRight.Value = value;
            }
            crop.Right = value;
            LoadPicture();
        }

        private void numericCropTop_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericCropTop.Value;
            if (value % 2 == 1)
                value = Math.Max(0, value - 1);
            if (originalSize.Height - crop.Bottom - value < PictureConfig.MinHeight)
            {
                value = originalSize.Height - crop.Bottom - PictureConfig.MinHeight;
                numericCropTop.Value = value;
            }
            crop.Top = value;
            LoadPicture();
        }

        private void numericCropBottom_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericCropBottom.Value;
            if (value % 2 == 1)
                value = Math.Max(0, value - 1);
            if (originalSize.Height - crop.Top - value < PictureConfig.MinHeight)
            {
                value = originalSize.Height - crop.Top - PictureConfig.MinHeight;
                numericCropBottom.Value = value;
            }
            crop.Bottom = value;
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

            string filters = "";
            if (inputFile.VideoStreams[0].FieldOrder != "progressive")
            {
                filters = " -vf \"yadif,setsar=1:1\"";
            }

            string arguments = $"-ss {currTime} -i \"{inputFile.FullPath}\"{filters} -vframes 1 -f mjpeg \"{tempFile}\"";

#if DEBUG
            Console.WriteLine(arguments);
#endif

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
            return new TimeSpan((long)correctedTime * 10000L).ToString("hh\\:mm\\:ss\\.fff");
        }

        private void CropForm_SizeChanged(object sender, EventArgs e)
        {
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
#if DEBUG
                Console.WriteLine("Not yet exited");
#endif

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
                    Image img = Helper.ImageFromFile(tempFile);
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

                int maxBoxWidth = Math.Min(pictureBoxPreview.Width, originalSize.Width);
                int maxBoxHeight = Math.Min(pictureBoxPreview.Height, originalSize.Height);

                double aspectRatio = Math.Min((double)maxBoxWidth / originalSize.Width, (double)maxBoxHeight / originalSize.Height);

                int topH = (int)Math.Round(crop.Top * aspectRatio);
                int bottomH = (int)Math.Round(crop.Bottom * aspectRatio);
                int leftW = (int)Math.Round(crop.Left * aspectRatio);
                int rightW = (int)Math.Round(crop.Right * aspectRatio);

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
            int maxBoxWidth = Math.Min(pictureBoxPreview.Width, originalSize.Width);
            int maxBoxHeight = Math.Min(pictureBoxPreview.Height, originalSize.Height);

            double aspectRatio = Math.Min((double)maxBoxWidth / originalSize.Width, (double)maxBoxHeight / originalSize.Height);

            int newWidth = (int)Math.Round(originalSize.Width * aspectRatio, 0);
            int newHeight = (int)Math.Round(originalSize.Height * aspectRatio, 0);

            if (newHeight % 2 == 1)
                newHeight -= 1;
            if (newHeight < 96)
                newHeight = 96;

            return new int[2] { newWidth, newHeight };
        }
    }
}
