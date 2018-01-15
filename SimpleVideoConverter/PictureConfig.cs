using System;
using System.Collections.Generic;

namespace Alexantr.SimpleVideoConverter
{
    public static class PictureConfig
    {
        public const int MinWidth = 128;
        public const int MaxWidth = 8192;

        public const int MinHeight = 96;
        public const int MaxHeight = 4320;

        public const string DefaultInterpolation = "bicubic";
        public const string DefaultFieldOrder = "auto";
        public const string DefaultColorFilter = "none";

        public static bool Deinterlace = false;
        public static bool Flip = false;

        private static PictureSize inputOriginalSize; // OAR
        private static PictureSize inputDisplaySize; // DAR

        private static PictureSize cropSize; // input size with crop (DAR)
        private static PictureSize outputSize; // final output size

        private static Crop crop;
        //private static Padding padding;

        // see https://superuser.com/questions/375718/which-resize-algorithm-to-choose-for-videos
        // see http://www.thnsolutions.com/technology/sunfire/graphic/image.html
        private static string interpolation;

        private static string fieldOrder;

        private static int rotate = 0;

        private static string colorFilter;

        private static Dictionary<string, string> fieldOrderList = new Dictionary<string, string>
        {
            { "auto", "Авто" },
            { "tff", "Top Field First" },
            { "bff", "Bottom Field First" }
        };

        private static string[] aspectRatioList = new string[]
        {
            "16:9", "4:3", "1:1", "1.85", "2.35", "2.39"
        };

        private static Dictionary<string, string> interpolationList = new Dictionary<string, string>
        {
            { "neighbor", "Nearest Neighbor" },
            { "bilinear", "Bilinear" },
            { "bicubic", "Bicubic" },
            { "lanczos", "Lanczos" },
            { "sinc", "Sinc" },
            { "gauss", "Gaussian" }
        };

        private static Dictionary<int, string> rotateList = new Dictionary<int, string>
        {
            { 0, "Не вращать" },
            { 180, "180°" },
            { 90, "90° по ч.с." },
            { 270, "90° против ч.с." }
        };

        private static Dictionary<string, string> colorFilterList = new Dictionary<string, string>
        {
            { "none", "Нет" },
            { "gray", "Черно-белое" },
            { "sepia", "Сепия" }
        };

        private static Dictionary<string, string> colorChannelMixerList = new Dictionary<string, string>
        {
            { "gray", ".3:.4:.3:0:.3:.4:.3:0:.3:.4:.3" },
            { "sepia", ".393:.769:.189:0:.349:.686:.168:0:.272:.534:.131" }
        };

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

        public static PictureSize CropSize => cropSize;

        public static PictureSize OutputSize
        {
            get { return outputSize; }
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

        public static string[] AspectRatioList => aspectRatioList;

        public static string Interpolation
        {
            get { return interpolation ?? DefaultInterpolation; }
            set { interpolation = interpolationList.ContainsKey(value) ? value : DefaultInterpolation; }
        }

        public static Dictionary<string, string> InterpolationList => interpolationList;

        public static string ColorFilter
        {
            get { return colorFilter ?? DefaultColorFilter; }
            set { colorFilter = colorFilterList.ContainsKey(value) ? value : DefaultColorFilter; }
        }

        public static Dictionary<string, string> ColorFilterList => colorFilterList;

        public static Dictionary<string, string> ColorChannelMixerList => colorChannelMixerList;

        public static string FieldOrder
        {
            get { return fieldOrder ?? DefaultFieldOrder; }
            set { fieldOrder = fieldOrderList.ContainsKey(value) ? value : DefaultFieldOrder; }
        }

        public static Dictionary<string, string> FieldOrderList => fieldOrderList;

        public static int Rotate
        {
            get { return rotate; }
            set { rotate = rotateList.ContainsKey(value) ? value : 0; }
        }

        public static Dictionary<int, string> RotateList => rotateList;

        /// <summary>
        /// Reset values for new file
        /// </summary>
        public static void Reset()
        {
            inputOriginalSize = null;
            inputDisplaySize = null;

            cropSize = null;
            outputSize = null;

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
            return (cropSize.Width != outputSize.Width || cropSize.Height != outputSize.Height);
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
                    if (newW % 2 == 1)
                        newW -= 1;
                    if (newW < MinWidth)
                        newW = MinWidth;
                    if (newH % 2 == 1)
                        newH -= 1;
                    if (newH < MinHeight)
                        newH = MinHeight;
                }

                cropSize = new PictureSize
                {
                    Width = newW,
                    Height = newH
                };
            }
            else
            {
                cropSize = new PictureSize
                {
                    Width = inputDisplaySize.Width,
                    Height = inputDisplaySize.Height
                };
            }

            if (outputSize == null)
            {
                outputSize = new PictureSize
                {
                    Width = cropSize.Width,
                    Height = cropSize.Height
                };
            }
        }
    }
}
