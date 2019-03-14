using System;
using System.Collections.Generic;

namespace Alexantr.SimpleVideoConverter
{
    public static class PictureConfig
    {
        public const int MinWidth = 16;
        public const int MaxWidth = 8192;

        public const int MinHeight = 16;
        public const int MaxHeight = 4320;

        public const string DefaultInterpolation = "bicubic";
        public const string DefaultFieldOrder = "auto";
        public const string DefaultColorFilter = "none";

        public static bool Deinterlace = false;
        public static bool Flip = false;

        private static PictureSize inputOriginalSize; // OAR
        private static PictureSize inputDisplaySize; // DAR

        private static Crop crop;
        //private static Padding padding;

        private static PictureSize outputSize;

        // see https://superuser.com/questions/375718/which-resize-algorithm-to-choose-for-videos
        // see http://www.thnsolutions.com/technology/sunfire/graphic/image.html
        private static string interpolation;

        private static string fieldOrder;

        private static int rotate = 0;

        private static string colorFilter;

        public static PictureSize InputOriginalSize
        {
            get { return inputOriginalSize; }
            set
            {
                inputOriginalSize = value;

                if (inputDisplaySize == null)
                    inputDisplaySize = inputOriginalSize;

                CalcSize();
            }
        }

        public static PictureSize InputDisplaySize
        {
            get { return inputDisplaySize; }
            set
            {
                inputDisplaySize = value;

                if (inputOriginalSize == null)
                    inputOriginalSize = inputDisplaySize;

                CalcSize();
            }
        }

        /// <summary>
        /// input size with crop (DAR)
        /// </summary>
        public static PictureSize CropSize { get; private set; }

        /// <summary>
        /// final output size
        /// </summary>
        public static PictureSize OutputSize {
            get {
                if (outputSize != null)
                {
                    if (outputSize.Width % 2 == 1)
                        outputSize.Width -= 1;
                    if (outputSize.Width < MinWidth)
                        outputSize.Width = MinWidth;
                    if (outputSize.Height % 2 == 1)
                        outputSize.Height -= 1;
                    if (outputSize.Height < MinHeight)
                        outputSize.Height = MinHeight;
                }
                return outputSize;
            }
            set { outputSize = value; }
        }

        public static Crop Crop
        {
            get { return crop ?? new Crop(); }
            set
            {
                crop = value;

                CalcSize();
            }
        }

        /*public static Padding Padding
        {
            get { return padding ?? new Padding(); }
        }*/

        public static string[] AspectRatioList { get; } = new string[]
        {
            "16:9", "4:3", "1:1", "1.85", "2.35", "2.4"
        };

        public static string Interpolation
        {
            get { return interpolation ?? DefaultInterpolation; }
            set { interpolation = InterpolationList.ContainsKey(value) ? value : DefaultInterpolation; }
        }

        public static Dictionary<string, string> InterpolationList { get; } = new Dictionary<string, string>
        {
            { "neighbor", "Nearest Neighbor" },
            { "bilinear", "Bilinear" },
            { "bicubic", "Bicubic" },
            { "lanczos", "Lanczos" },
            { "sinc", "Sinc" },
            { "gauss", "Gaussian" }
        };

        public static string ColorFilter
        {
            get { return colorFilter ?? DefaultColorFilter; }
            set { colorFilter = ColorFilterList.ContainsKey(value) ? value : DefaultColorFilter; }
        }

        public static Dictionary<string, string> ColorFilterList { get; } = new Dictionary<string, string>
        {
            { "none", "Нет" },
            { "gray", "Черно-белое" },
            { "sepia", "Сепия" }
        };

        public static Dictionary<string, string> ColorChannelMixerList { get; } = new Dictionary<string, string>
        {
            { "gray", ".3:.4:.3:0:.3:.4:.3:0:.3:.4:.3" },
            { "sepia", ".393:.769:.189:0:.349:.686:.168:0:.272:.534:.131" }
        };

        public static string FieldOrder
        {
            get { return fieldOrder ?? DefaultFieldOrder; }
            set { fieldOrder = FieldOrderList.ContainsKey(value) ? value : DefaultFieldOrder; }
        }

        public static Dictionary<string, string> FieldOrderList { get; } = new Dictionary<string, string>
        {
            { "auto", "Авто" },
            { "tff", "Top Field First" },
            { "bff", "Bottom Field First" }
        };

        public static int Rotate
        {
            get { return rotate; }
            set { rotate = RotateList.ContainsKey(value) ? value : 0; }
        }

        public static Dictionary<int, string> RotateList { get; } = new Dictionary<int, string>
        {
            { 0, "Не вращать" },
            { 180, "180°" },
            { 90, "90° по ч.с." },
            { 270, "90° против ч.с." }
        };

        /// <summary>
        /// Reset values for new file
        /// </summary>
        public static void Reset()
        {
            inputOriginalSize = null;
            inputDisplaySize = null;

            CropSize = null;
            OutputSize = null;

            crop = new Crop();
            //padding = new Padding();

            Deinterlace = false;
            fieldOrder = DefaultFieldOrder;

            rotate = 0;
            Flip = false;
        }

        /// <summary>
        /// Check if using DAR
        /// </summary>
        /// <returns></returns>
        public static bool IsUsingDAR()
        {
            if (inputOriginalSize == null)
                return false;
            return (inputOriginalSize.Width != inputDisplaySize.Width || inputOriginalSize.Height != inputDisplaySize.Height);
        }

        /// <summary>
        /// Check if crop is applied
        /// </summary>
        /// <returns></returns>
        public static bool IsCropped() => (crop.Left > 0 || crop.Top > 0 || crop.Right > 0 || crop.Bottom > 0);

        /// <summary>
        /// Check if resize is applied (after crop or w/o it)
        /// </summary>
        /// <returns></returns>
        public static bool IsResized()
        {
            if (inputOriginalSize == null)
                return false;
            return (CropSize.Width != OutputSize.Width || CropSize.Height != OutputSize.Height);
        }

        private static void CalcSize()
        {
            if (inputOriginalSize == null || inputDisplaySize == null)
                return;

            if (IsCropped())
            {
                // init with oar sizes
                int newW = inputOriginalSize.Width - Crop.Left - Crop.Right;
                int newH = inputOriginalSize.Height - Crop.Top - Crop.Bottom;
                // correct oar -> dar
                if (IsUsingDAR())
                {
                    double diffW = (double)inputDisplaySize.Width / inputOriginalSize.Width;
                    double diffH = (double)inputDisplaySize.Height / inputOriginalSize.Height;
                    newW = (int)Math.Round(newW * diffW, 0);
                    newH = (int)Math.Round(newH * diffH, 0);
                }

                //if (newW < MinWidth)
                //    newW = MinWidth;
                //if (newH < MinHeight)
                //    newH = MinHeight;

                CropSize = new PictureSize
                {
                    Width = newW,
                    Height = newH
                };
            }
            else
            {
                int newW = inputDisplaySize.Width;
                int newH = inputDisplaySize.Height;

                //if (newW < MinWidth)
                //    newW = MinWidth;
                //if (newH < MinHeight)
                //    newH = MinHeight;

                CropSize = new PictureSize
                {
                    Width = newW,
                    Height = newH
                };
            }

            if (OutputSize == null)
            {
                int newW = CropSize.Width;
                int newH = CropSize.Height;

                if (newW < MinWidth)
                    newW = MinWidth;
                if (newH < MinHeight)
                    newH = MinHeight;

                OutputSize = new PictureSize
                {
                    Width = newW,
                    Height = newH
                };
            }
        }
    }
}
