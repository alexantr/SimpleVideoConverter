using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public const string ResizeMethodFill = "fill";
        // the image will fill the height and width of its box, once again maintaining its aspect ratio but often cropping the image in the process
        // Элемент увеличивается или уменьшается, чтобы целиком заполнить заданную область с сохранением пропорций
        public const string ResizeMethodCover = "cover";
        // contain with black borders
        public const string ResizeMethodBorders = "borders";


        public static bool Deinterlace = false;


        private static Crop crop;

        private static PictureSize inputOriginalPictureSize; // DAR
        private static PictureSize inputPictureSize; // SAR
        private static PictureSize croppedPictureSize; // inpit size with crop (SAR)
        private static PictureSize outputPictureSize; // final output size

        private static PictureSize selectedPictureSize;
        private static string[] pictureSizeList = new string[]
        {
            "1920x1080",
            "1280x720",
            "1024x576",
            "854x480",
            "720x540",
            "640x480",
            "512x384",
            "320x240",
            "176x144"
        };

        private static string resizeMethod = ResizeMethodContain;
        private static string[,] resizeMethodList = new string[,]
        {
            { ResizeMethodContain, "Вписать" },
            { ResizeMethodFill, "Растянуть" },
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
            { "none", "Нет" },
            { "gray", "Черно-белое" },
            { "sepia", "Сепия" }
        };

        private static string fieldOrder = DefaultAuto;
        private static string[,] fieldOrderList = new string[,] {
            { "auto", "Авто" },
            { "tff", "Top Field First" },
            { "bff", "Bottom Field First" }
        };

        /// <summary>
        /// Init values for new file
        /// </summary>
        public static void Init()
        {
            crop = new Crop();
            Deinterlace = false;
            fieldOrder = DefaultAuto;
        }

        public static Crop Crop
        {
            get {
                if (crop == null)
                    crop = new Crop();
                return crop;
            }
            set { crop = value; }
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
        public static string[] PictureSizeList
        {
            get { return pictureSizeList; }
        }

        /// <summary>
        /// Resize method
        /// </summary>
        public static string ResizeMethod
        {
            get { return resizeMethod; }
            set
            {
                if (Utility.IsValid(value, resizeMethodList))
                    resizeMethod = value;
                else
                    resizeMethod = ResizeMethodContain;
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
                if (Utility.IsValid(value, scalingAlgorithmList))
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
                if (Utility.IsValid(value, colorFilterList))
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
        /// Field order for deinterlace
        /// </summary>
        public static string FieldOrder
        {
            get { return fieldOrder; }
            set
            {
                if (Utility.IsValid(value, fieldOrderList))
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
    }
}
