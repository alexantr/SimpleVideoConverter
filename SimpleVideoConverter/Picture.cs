using System;

namespace Alexantr.SimpleVideoConverter
{
    public static class Picture
    {
        public const string DefaultNone = "none";
        public const string DefaultAuto = "auto";

        public const int MinWidth = 128;
        public const int MaxWidth = 8192;

        public const int MinHeight = 96;
        public const int MaxHeight = 4320;

        public const string DefaultScalingAlgorithm = "bicubic";

        // increases or decreases the size of the image to fill the box whilst preserving its aspect-ratio
        // Элемент масштабируется, чтобы целиком уместиться в заданные размеры с соблюдением пропорций
        public const string ResizeMethodContain = "contain";
        // stretches the image to fit the box, regardless of its aspect-ratio
        // Элемент масштабируется, чтобы соответствовать заданным размерам, при этом пропорции игнорируются
        public const string ResizeMethodStretch = "stretch";
        // the image will fill the height and width of its box, once again maintaining its aspect ratio but often cropping the image in the process
        // Элемент увеличивается или уменьшается, чтобы целиком заполнить заданную область с сохранением пропорций
        public const string ResizeMethodCover = "cover";
        // contain with black borders
        public const string ResizeMethodBorders = "borders";

        public const string ColorFilterGray = "gray";
        public const string ColorFilterSepia = "sepia";


        public static bool Deinterlace = false;


        private static Crop crop;

        private static PictureSize inputOriginalSize; // OAR
        private static PictureSize inputSize; // DAR
        private static PictureSize cropSize; // inpit size with crop (DAR)
        private static PictureSize outputSize; // final output size

        private static PictureSize selectedSize; // if null - stay original size

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

        private static string resizeMethod = ResizeMethodContain;
        private static string[,] resizeMethodList = new string[,]
        {
            { ResizeMethodContain, "Вместить" },
            { ResizeMethodStretch, "Растянуть" },
            //{ ResizeMethodCover, "Заполнить" },
            { ResizeMethodBorders, "C полосами" }
        };

        // see https://superuser.com/questions/375718/which-resize-algorithm-to-choose-for-videos
        // see http://www.thnsolutions.com/technology/sunfire/graphic/image.html
        private static string scalingAlgorithm = DefaultScalingAlgorithm;
        private static string[,] scalingAlgorithmList = new string[,]
        {
            { "neighbor", "Nearest Neighbor" },
            { "bilinear", "Bilinear" },
            { "bicubic", "Bicubic" },
            { "lanczos", "Lanczos" },
            { "sinc", "Sinc" },
            { "gauss", "Gaussian" }
        };

        private static string colorFilter = DefaultNone;
        private static string[,] colorFilterList = new string[,]
        {
            { DefaultNone, "Нет" },
            { ColorFilterGray, "Черно-белое" },
            { ColorFilterSepia, "Сепия" }
        };
        private static string[,] colorChannelMixerList = new string[,]
        {
            { ColorFilterGray, ".3:.4:.3:0:.3:.4:.3:0:.3:.4:.3" },
            { ColorFilterSepia, ".393:.769:.189:0:.349:.686:.168:0:.272:.534:.131" }
        };

        private static string fieldOrder = DefaultAuto;
        private static string[,] fieldOrderList = new string[,] {
            { DefaultAuto, "Авто" },
            { "tff", "Top Field First" },
            { "bff", "Bottom Field First" }
        };

        /// <summary>
        /// Init values for new file
        /// </summary>
        public static void Init()
        {
            inputOriginalSize = null;
            inputSize = null;
            cropSize = null;
            outputSize = null;

            crop = new Crop();

            Deinterlace = false;
            fieldOrder = DefaultAuto;
        }

        /// <summary>
        /// Input picture size (OAR)
        /// </summary>
        public static PictureSize InputOriginalSize
        {
            get { return inputOriginalSize; }
            set
            {
                inputOriginalSize = value;

                if (inputSize == null)
                    inputSize = inputOriginalSize;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        /// <summary>
        /// Input picture size (SAR)
        /// </summary>
        public static PictureSize InputSize
        {
            get { return inputSize; }
            set {
                inputSize = value;

                if (inputOriginalSize == null)
                    inputOriginalSize = inputSize;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        /// <summary>
        /// Selected picture size for resize
        /// </summary>
        public static PictureSize SelectedSize
        {
            get { return selectedSize; }
            set
            {
                selectedSize = value;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        /// <summary>
        /// Cropped picture size (before scaling)
        /// </summary>
        public static PictureSize CropSize
        {
            get { return cropSize; }
        }

        /// <summary>
        /// Output picture size (after scaling, w/o borders if ResizeMethodBorders)
        /// </summary>
        public static PictureSize OutputSize
        {
            get { return outputSize; }
        }

        /// <summary>
        /// Check if using DAR
        /// </summary>
        /// <returns></returns>
        public static bool UsingDAR()
        {
            if (inputOriginalSize == null)
                return false;
            return (inputOriginalSize.Width != inputSize.Width || inputOriginalSize.Height != inputSize.Height);
        }

        /// <summary>
        /// Crop values
        /// </summary>
        public static Crop Crop
        {
            get {
                if (crop == null)
                    crop = new Crop();
                return crop;
            }
            set {
                crop = value;

                CalcCroppedSize();
                CalcOutputSize();
            }
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
        /// List of picture sizes
        /// </summary>
        public static string[] SizeList
        {
            get { return sizeList; }
        }

        /// <summary>
        /// Resize method
        /// </summary>
        public static string ResizeMethod
        {
            get { return resizeMethod; }
            set
            {
                if (Helper.IsValid(value, resizeMethodList))
                    resizeMethod = value;
                else
                    resizeMethod = ResizeMethodContain;

                CalcCroppedSize();
                CalcOutputSize();
            }
        }

        /// <summary>
        /// List of resize methods
        /// </summary>
        public static string[,] ResizeMethodList
        {
            get { return resizeMethodList; }
        }

        /// <summary>
        /// Scaling algorithm
        /// </summary>
        public static string ScalingAlgorithm
        {
            get { return scalingAlgorithm; }
            set {
                if (Helper.IsValid(value, scalingAlgorithmList))
                    scalingAlgorithm = value;
                else
                    scalingAlgorithm = DefaultScalingAlgorithm;
            }
        }

        /// <summary>
        /// List of scaling algorithms
        /// </summary>
        public static string[,] ScalingAlgorithmList
        {
            get { return scalingAlgorithmList; }
        }

        /// <summary>
        /// Color filter
        /// </summary>
        public static string ColorFilter
        {
            get { return colorFilter; }
            set
            {
                if (Helper.IsValid(value, colorFilterList))
                    colorFilter = value;
                else
                    colorFilter = DefaultNone;
            }
        }

        /// <summary>
        /// List of color filter
        /// </summary>
        public static string[,] ColorFilterList
        {
            get { return colorFilterList; }
        }

        /// <summary>
        /// List of filters for 'colorchannelmixer'
        /// </summary>
        public static string[,] ColorChannelMixerList
        {
            get { return colorChannelMixerList; }
        }

        /// <summary>
        /// Field order for deinterlace
        /// </summary>
        public static string FieldOrder
        {
            get { return fieldOrder; }
            set
            {
                if (Helper.IsValid(value, fieldOrderList))
                    fieldOrder = value;
                else
                    fieldOrder = DefaultAuto;
            }
        }

        /// <summary>
        /// List of field order types
        /// </summary>
        public static string[,] FieldOrderList
        {
            get { return fieldOrderList; }
        }

        private static void CalcCroppedSize()
        {
            if (inputOriginalSize == null || inputSize == null)
                return;

            if (IsCropped())
            {
                // init with oar sizes
                int newW = inputOriginalSize.Width - Crop.Left - Crop.Right;
                int newH = inputOriginalSize.Height - Crop.Top - Crop.Bottom;
                // correct oar -> dar
                if (UsingDAR())
                {
                    double diffW = (double)inputSize.Width / inputOriginalSize.Width;
                    double diffH = (double)inputSize.Height / inputOriginalSize.Height;
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
                    Width = inputSize.Width,
                    Height = inputSize.Height
                };
            }
        }

        private static void CalcOutputSize()
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
