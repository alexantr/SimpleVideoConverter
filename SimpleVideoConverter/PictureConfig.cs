using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Alexantr.SimpleVideoConverter
{
    public static class PictureConfig
    {
        public const int MinWidth = 128;
        public const int MaxWidth = 8192;

        public const int MinHeight = 96;
        public const int MaxHeight = 4320;

        public const string DefaultResizeMethod = "contain";
        public const string DefaultInterpolation = "bicubic";
        public const string DefaultFieldOrder = "auto";
        public const string DefaultColorFilter = "none";

        public static bool Deinterlace = false;

        private static PictureSize inputOriginalSize; // OAR
        private static PictureSize inputDisplaySize; // DAR

        public static PictureSize CropSize { get; private set; } // input size with crop (DAR)
        public static PictureSize OutputSize { get; private set; } // final output size

        private static PictureSize selectedSize; // if null - stay original size

        private static Crop crop;
        private static Padding padding;

        private static string resizeMethod;
        
        // see https://superuser.com/questions/375718/which-resize-algorithm-to-choose-for-videos
        // see http://www.thnsolutions.com/technology/sunfire/graphic/image.html
        private static string interpolation;

        private static string fieldOrder;

        private static string colorFilter;

        private static string[] sizeList = new string[] {
            "1920x1080 (16:9)", "1280x720 (16:9)", "1024x576 (16:9)", "854x480 (16:9)",
            "720x576 (5:4)", "640x480 (4:3)", "512x384 (4:3)", "320x240 (4:3)"
        };

        private static Dictionary<string, string> resizeMethodList = new Dictionary<string, string>
        {
            { "contain", "Вместить" },
            { "stretch", "Растянуть" },
            { "borders", "C полосами" }
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

        private static Dictionary<string, string> fieldOrderList = new Dictionary<string, string>
        {
            { "auto", "Авто" },
            { "tff", "Top Field First" },
            { "bff", "Bottom Field First" }
        };

        public static PictureSize InputOriginalSize
        {
            get { return inputOriginalSize; }
            set
            {
                inputOriginalSize = value;

                if (inputDisplaySize == null)
                    inputDisplaySize = inputOriginalSize;

                CalcCroppedSize();
                CalcOutputSize();
                CalcPadding();
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

                CalcCroppedSize();
                CalcOutputSize();
                CalcPadding();
            }
        }

        public static PictureSize SelectedSize
        {
            get { return selectedSize; }
            set
            {
                selectedSize = value;

                CalcCroppedSize();
                CalcOutputSize();
                CalcPadding();
            }
        }

        public static Crop Crop
        {
            get { return crop ?? new Crop(); }
            set
            {
                crop = value;

                CalcCroppedSize();
                CalcOutputSize();
                CalcPadding();
            }
        }

        public static Padding Padding
        {
            get { return padding ?? new Padding(); }
        }

        public static string ResizeMethod
        {
            get { return resizeMethod ?? DefaultResizeMethod; }
            set
            {
                resizeMethod = resizeMethodList.ContainsKey(value) ? value : DefaultResizeMethod;

                CalcCroppedSize();
                CalcOutputSize();
                CalcPadding();
            }
        }

        public static string Interpolation
        {
            get { return interpolation ?? DefaultInterpolation; }
            set { interpolation = interpolationList.ContainsKey(value) ? value : DefaultInterpolation; }
        }

        public static string ColorFilter
        {
            get { return colorFilter ?? DefaultColorFilter; }
            set { colorFilter = colorFilterList.ContainsKey(value) ? value : DefaultColorFilter; }
        }
        
        public static string FieldOrder
        {
            get { return fieldOrder ?? DefaultFieldOrder; }
            set { fieldOrder = fieldOrderList.ContainsKey(value) ? value : DefaultFieldOrder; }
        }

        #region Lists

        public static string[] SizeList
        {
            get { return sizeList; }
        }

        public static Dictionary<string, string> ResizeMethodList
        {
            get { return resizeMethodList; }
        }

        public static Dictionary<string, string> InterpolationList
        {
            get { return interpolationList; }
        }

        public static Dictionary<string, string> ColorFilterList
        {
            get { return colorFilterList; }
        }

        public static Dictionary<string, string> ColorChannelMixerList
        {
            get { return colorChannelMixerList; }
        }

        public static Dictionary<string, string> FieldOrderList
        {
            get { return fieldOrderList; }
        }

        #endregion

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
            padding = new Padding();

            Deinterlace = false;
            fieldOrder = DefaultFieldOrder;
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
        public static bool IsCropped()
        {
            return (crop.Left > 0 || crop.Top > 0 || crop.Right > 0 || crop.Bottom > 0);
        }

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

        /// <summary>
        /// Parse size from combobox value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ParseSelectedSize(string input)
        {
            Match match = new Regex("^([0-9]+)x([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(input);
            if (match.Success)
            {
                try
                {
                    int newWidth = Convert.ToInt32(match.Groups[1].Value);
                    int newHeight = Convert.ToInt32(match.Groups[2].Value);
                    if (newWidth % 2 == 1)
                        newWidth -= 1;
                    if (newWidth < MinWidth)
                        newWidth = MinWidth;
                    if (newHeight % 2 == 1)
                        newHeight -= 1;
                    if (newHeight < MinHeight)
                        newHeight = MinHeight;

                    SelectedSize = new PictureSize
                    {
                        Width = newWidth,
                        Height = newHeight
                    };

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private static void CalcCroppedSize()
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

                CropSize = new PictureSize
                {
                    Width = newW,
                    Height = newH
                };
            }
            else
            {
                CropSize = new PictureSize
                {
                    Width = inputDisplaySize.Width,
                    Height = inputDisplaySize.Height
                };
            }
        }

        private static void CalcOutputSize()
        {
            if (CropSize == null)
                return;

            if (selectedSize == null)
            {
                OutputSize = new PictureSize
                {
                    Width = CropSize.Width,
                    Height = CropSize.Height
                };
                return;
            }
            if (resizeMethod == "stretch")
            {
                OutputSize = new PictureSize
                {
                    Width = selectedSize.Width,
                    Height = selectedSize.Height
                };
            }
            else
            {
                double aspectRatio = Math.Min((double)selectedSize.Width / CropSize.Width, (double)selectedSize.Height / CropSize.Height);
                int newWidth = (int)Math.Round(CropSize.Width * aspectRatio);
                int newHeight = (int)Math.Round(CropSize.Height * aspectRatio);
                if (newWidth % 2 == 1)
                    newWidth -= 1;
                if (newWidth < MinWidth)
                    newWidth = MinWidth;
                if (newWidth > MaxWidth)
                    newWidth = MaxWidth;
                if (newHeight % 2 == 1)
                    newHeight -= 1;
                if (newHeight < MinHeight)
                    newHeight = MinHeight;
                if (newHeight > MaxHeight)
                    newHeight = MaxHeight;

                OutputSize = new PictureSize
                {
                    Width = newWidth,
                    Height = newHeight
                };
            }
        }

        private static void CalcPadding()
        {
            if (inputOriginalSize == null || inputDisplaySize == null)
                return;

            if (resizeMethod == "borders")
            {
                padding.X = (int)Math.Round((SelectedSize.Width - OutputSize.Width) / 2.0);
                padding.Y = (int)Math.Round((SelectedSize.Height - OutputSize.Height) / 2.0);
            }
            else
            {
                padding.X = 0;
                padding.Y = 0;
            }
        }
    }
}
