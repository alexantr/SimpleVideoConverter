using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Drawing;
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

        private double totalTime, currentTime, stepTime;

        private Crop crop;

        private int[] size;

        private TaskbarManager taskbarManager;

        private Image image;

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

        private void CropForm_SizeChanged(object sender, EventArgs e)
        {
            size = GetWidthHeight();
            LoadPicture();
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
            image = null;
            currentTime -= stepTime;
            LoadPicture();
        }

        private void buttonFF_Click(object sender, EventArgs e)
        {
            image = null;
            currentTime += stepTime;
            LoadPicture();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            numericCropTop.Value = 0;
            numericCropBottom.Value = 0;
            numericCropLeft.Value = 0;
            numericCropRight.Value = 0;
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

        private void LoadPicture()
        {
            string currTime = GetCorrectedTime();
            labelTime.Text = currTime;

            if (image != null)
            {
                DrawImageWithRects(image);
                CheckButtons();
                return;
            }

            buttonRew.Enabled = false;
            buttonFF.Enabled = false;
            numericCropBottom.Enabled = false;
            numericCropLeft.Enabled = false;
            numericCropRight.Enabled = false;
            numericCropTop.Enabled = false;
            buttonReset.Enabled = false;

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
                    image = Helper.ImageFromFile(tempFile);
                    DrawImageWithRects(image);

                    CheckButtons();

                    labelLoading.Visible = false;
                    taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                }
                catch (Exception ex)
                {
                    image = null;

                    labelLoading.Visible = false;
                    taskbarManager.SetProgressState(TaskbarProgressBarState.NoProgress);
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            processEnded = true;
        }
    }
}
