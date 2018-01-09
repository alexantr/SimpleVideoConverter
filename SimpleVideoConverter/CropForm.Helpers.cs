using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Alexantr.SimpleVideoConverter
{
    partial class CropForm
    {
        private bool resizing = false;

        private string GetCorrectedTime()
        {
            double correctedTime = currentTime;
            if (correctedTime > totalTime - 1000.0)
                correctedTime -= 1000.0;
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
            buttonReset.Enabled = true;
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
