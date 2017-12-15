using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Alexantr.SimpleVideoConverter
{
    public static class ImageHelper
    {
        /// <summary>
        /// Get Image from file without lock
        /// https://stackoverflow.com/questions/4803935/free-file-locked-by-new-bitmapfilepath
        /// </summary>
        /// <param name="path">Path to image file</param>
        /// <returns>Image class</returns>
        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            if (image.Width == width && image.Height == height)
                return new Bitmap(image);
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap bitmap = new Bitmap(width, height);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.Bicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (ImageAttributes imageAttr = new ImageAttributes())
                {
                    imageAttr.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttr);
                }
            }
            return bitmap;
        }

        public static Bitmap ResizeImage(Image image, Decimal percentage)
        {
            int width = (int)Math.Round(image.Width * percentage, MidpointRounding.AwayFromZero);
            int height = (int)Math.Round(image.Height * percentage, MidpointRounding.AwayFromZero);
            return ResizeImage(image, width, height);
        }
    }
}
