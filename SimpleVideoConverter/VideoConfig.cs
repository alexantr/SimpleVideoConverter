using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexantr.SimpleVideoConverter
{
    public static class VideoConfig
    {
        public const string EncodeModeBitrate = "bitrate";
        public const string EncodeModeCRF = "crf";

        private static bool canCRF = false;
        private static bool canBitrate = false;

        private static string encodeMode;

        private static int minCRF;
        private static int maxCRF;
        private static int defaultCRF;

        private static int minBitrate;
        private static int maxBitrate;
        private static int defaultBitrate;

        private static string codec;
        private static string[,] codecList;

        private static string[,] defaultAudioCodecs;

        public static string Codec
        {
            get { return codec; }
            set
            {
                codec = value;
            }
        }

        public static string[,] CodecList
        {
            get { return codecList; }
            set { codecList = value; }
        }

        public static string[,] DefaultAudioCodecs
        {
            get { return defaultAudioCodecs; }
            set
            {
                defaultAudioCodecs = value;
            }
        }
    }
}
