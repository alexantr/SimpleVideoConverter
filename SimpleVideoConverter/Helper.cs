using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Alexantr.SimpleVideoConverter
{
    public static class Helper
    {
        /// <summary>
        /// Get Image from file without lock
        /// https://stackoverflow.com/questions/4803935/free-file-locked-by-new-bitmapfilepath
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Image ImageFromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        /// <summary>
        /// Resize image by width and height
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Resize image by percentage
        /// </summary>
        /// <param name="image"></param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public static Bitmap ResizeImage(Image image, Decimal percentage)
        {
            int width = (int)Math.Round(image.Width * percentage, MidpointRounding.AwayFromZero);
            int height = (int)Math.Round(image.Height * percentage, MidpointRounding.AwayFromZero);
            return ResizeImage(image, width, height);
        }

        /// <summary>
        /// Checks if value matches a value from array.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="items"></param>       
        public static bool IsValid(string value, string[,] items)
        {
            bool valid = false;
            for (int i = 0; i < items.GetLength(0); i++)
            {
                if (value == items[i, 0])
                {
                    valid = true;
                    break;
                }
            }
            return valid;
        }

        public static bool IsValid(int x, int[] items)
        {
            bool valid = false;
            for (int i = 0; i < items.GetLength(0); i++)
            {
                if (x == items[i])
                {
                    valid = true;
                    break;
                }
            }
            return valid;
        }
    }
}
