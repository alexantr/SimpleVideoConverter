using System;
using System.Text.RegularExpressions;

namespace Alexantr.SimpleVideoConverter
{
    public class Picture
    {
        public const int MinWidth = 128;
        public const int MaxWidth = 8192;

        public const int MinHeight = 96;
        public const int MaxHeight = 4320;

        public const string ResizeMethodContain = "contain";
        public const string ResizeMethodStretch = "stretch";
        public const string ResizeMethodBorders = "borders";

        public const string DefaultResizeMethod = "contain";
        public const string DefaultInterpolation = "bicubic";
        public const string DefaultFieldOrder = "auto";
        public const string DefaultColorFilter = "none";

        private PictureSize inputOriginalSize; // OAR
        private PictureSize inputDisplaySize; // DAR
        private PictureSize cropSize; // inpit size with crop (DAR)
        private PictureSize outputSize; // final output size

        private PictureSize selectedSize; // if null - stay original size

        private Crop crop;

        private string resizeMethod;
        
        // see https://superuser.com/questions/375718/which-resize-algorithm-to-choose-for-videos
        // see http://www.thnsolutions.com/technology/sunfire/graphic/image.html
        private string interpolation;

        private bool deinterlace = false;
        private string fieldOrder;

        private string colorFilter;

        private static string[] sizeList = new string[]
        {
            "1920x1080",
            "1280x720",
            "1024x576",
            "854x480",
            "720x540",
            "640x480",
            "512x384",
            "320x240",
            "192x144"
        };

        private static string[,] resizeMethodList = new string[,]
        {
            { ResizeMethodContain, "Вместить" },
            { ResizeMethodStretch, "Растянуть" },
            { ResizeMethodBorders, "C полосами" }
        };

        private static string[,] interpolationList = new string[,]
        {
            { "neighbor", "Nearest Neighbor" },
            { "bilinear", "Bilinear" },
            { "bicubic", "Bicubic" },
            { "lanczos", "Lanczos" },
            { "sinc", "Sinc" },
            { "gauss", "Gaussian" }
        };

        private static string[,] colorFilterList = new string[,]
        {
            { "none", "Нет" },
            { "gray", "Черно-белое" },
            { "sepia", "Сепия" }
        };
        private static string[,] colorChannelMixerList = new string[,]
        {
            { "gray", ".3:.4:.3:0:.3:.4:.3:0:.3:.4:.3" },
            { "sepia", ".393:.769:.189:0:.349:.686:.168:0:.272:.534:.131" }
        };

        private static string[,] fieldOrderList = new string[,] {
            { "auto", "Авто" },
            { "tff", "Top Field First" },
            { "bff", "Bottom Field First" }
        };

        #region Get Set

        public PictureSize InputOriginalSize
        {
            get { return inputOriginalSize; }
            set
            {
                inputOriginalSize = value;

                if (inputDisplaySize == null)
                    inputDisplaySize = inputOriginalSize;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        public PictureSize InputDisplaySize
        {
            get { return inputDisplaySize; }
            set
            {
                inputDisplaySize = value;

                if (inputOriginalSize == null)
                    inputOriginalSize = inputDisplaySize;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        public PictureSize SelectedSize
        {
            get { return selectedSize; }
            set
            {
                selectedSize = value;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        public PictureSize CropSize
        {
            get { return cropSize; }
        }

        public PictureSize OutputSize
        {
            get { return outputSize; }
        }

        public Crop Crop
        {
            get { return crop ?? new Crop(); }
            set
            {
                crop = value;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        public string ResizeMethod
        {
            get { return resizeMethod ?? DefaultResizeMethod; }
            set
            {
                resizeMethod = Helper.IsValid(value, resizeMethodList) ? value : DefaultResizeMethod;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        public string Interpolation
        {
            get { return interpolation ?? DefaultInterpolation; }
            set { interpolation = Helper.IsValid(value, interpolationList) ? value : DefaultInterpolation; }
        }

        public string ColorFilter
        {
            get { return colorFilter ?? DefaultColorFilter; }
            set { colorFilter = Helper.IsValid(value, colorFilterList) ? value : DefaultColorFilter; }
        }

        public bool Deinterlace
        {
            get { return deinterlace; }
            set { deinterlace = value; }
        }

        public string FieldOrder
        {
            get { return fieldOrder ?? DefaultFieldOrder; }
            set { fieldOrder = Helper.IsValid(value, fieldOrderList) ? value : DefaultFieldOrder; }
        }

        #endregion

        public Picture()
        {
            crop = new Crop();
        }

        /// <summary>
        /// Reset values for new file
        /// </summary>
        public void Reset()
        {
            inputOriginalSize = null;
            inputDisplaySize = null;
            cropSize = null;
            outputSize = null;

            crop.Reset();

            deinterlace = false;
            fieldOrder = DefaultFieldOrder;
        }

        /// <summary>
        /// Check if using DAR
        /// </summary>
        /// <returns></returns>
        public bool UsingDAR()
        {
            if (inputOriginalSize == null)
                return false;
            return (inputOriginalSize.Width != inputDisplaySize.Width || inputOriginalSize.Height != inputDisplaySize.Height);
        }

        /// <summary>
        /// Check if crop is applied
        /// </summary>
        /// <returns></returns>
        public bool IsCropped()
        {
            return (crop.Left > 0 || crop.Top > 0 || crop.Right > 0 || crop.Bottom > 0);
        }

        /// <summary>
        /// Parse size from combobox value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool ParseSelectedPictureSize(string input)
        {
            Match match = new Regex("^([0-9]+)x([0-9]+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline).Match(input);
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

                    selectedSize = new PictureSize
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

        #region Lists

        public static string[] SizeList
        {
            get { return sizeList; }
        }

        public static string[,] ResizeMethodList
        {
            get { return resizeMethodList; }
        }

        public static string[,] InterpolationList
        {
            get { return interpolationList; }
        }

        public static string[,] ColorFilterList
        {
            get { return colorFilterList; }
        }

        public static string[,] ColorChannelMixerList
        {
            get { return colorChannelMixerList; }
        }

        public static string[,] FieldOrderList
        {
            get { return fieldOrderList; }
        }

        #endregion

        private void CalcCroppedSize()
        {
            if (inputOriginalSize == null || inputDisplaySize == null)
                return;

            if (IsCropped())
            {
                // init with oar sizes
                int newW = inputOriginalSize.Width - Crop.Left - Crop.Right;
                int newH = inputOriginalSize.Height - Crop.Top - Crop.Bottom;
                // correct oar -> dar
                if (UsingDAR())
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
        }

        private void CalcOutputSize()
        {
            if (cropSize == null)
                return;

            if (selectedSize == null)
            {
                outputSize = new PictureSize
                {
                    Width = cropSize.Width,
                    Height = cropSize.Height
                };
                return;
            }
            if (resizeMethod == ResizeMethodStretch)
            {
                outputSize = new PictureSize
                {
                    Width = selectedSize.Width,
                    Height = selectedSize.Height
                };
            }
            else
            {
                double aspectRatio = Math.Min((double)selectedSize.Width / cropSize.Width, (double)selectedSize.Height / cropSize.Height);
                int newWidth = (int)Math.Round(cropSize.Width * aspectRatio);
                int newHeight = (int)Math.Round(cropSize.Height * aspectRatio);
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

                outputSize = new PictureSize
                {
                    Width = newWidth,
                    Height = newHeight
                };
            }
        }
    }
}
