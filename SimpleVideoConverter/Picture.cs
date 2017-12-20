using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexantr.SimpleVideoConverter
{
    class Picture
    {
        public const string DefaultNone = "none";
        public const string DefaultAuto = "auto";

        public const int MinWidth = 128;
        public const int MaxWidth = 8192;

        public const int MinHeight = 96;
        public const int MaxHeight = 4320;

        public const string DefaultScalingAlgorithm = "bicubic";

        public const string ResizeMethodFit = "fit";
        public const string ResizeMethodStretch = "stretch";
        public const string ResizeMethodBorders = "borders";

        public static bool Deinterlace = false;

        private static int cropLeft, cropTop, cropRight, cropBottom; // values for dar
        private PictureSize cropPictureSize; // picture size after crop but fixed for sar
        private PictureSize selectedPictureSize; // selected size from comboBoxResizeMethod
        private PictureSize finalPictureSize; // final picture size for video

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

        private static string resizeMethod = ResizeMethodFit;
        private static string[,] resizeMethodList = new string[,]
        {
            { ResizeMethodFit, "Вписать" },
            { ResizeMethodStretch, "Растянуть" },
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
        private static string[,] fieldOrderList = new string[,]
        {
            { "auto", "Авто" },
            { "tff", "Top Field First" },
            { "bff", "Bottom Field First" }
        };

        // Picture Size
        
        public static string[] PictureSizeList
        {
            get { return pictureSizeList; }
        }

        // Resize Method

        public static string ResizeMethod
        {
            get { return resizeMethod; }
            set
            {
                if (Utility.IsValid(value, resizeMethodList))
                    resizeMethod = value;
                else
                    resizeMethod = ResizeMethodFit;
            }
        }

        public static string[,] ResizeMethodList
        {
            get { return resizeMethodList; }
        }

        // Scaling Algorithm

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

        public static string[,] ScalingAlgorithmList
        {
            get { return scalingAlgorithmList; }
        }

        // Color Filter

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

        public static string[,] ColorFilterList
        {
            get { return colorFilterList; }
        }

        // Field Order

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

        public static string[,] FieldOrderList
        {
            get { return fieldOrderList; }
        }
    }
}
