using System.Collections.Generic;

namespace Alexantr.SimpleVideoConverter
{
    public static class VideoConfig
    {
        private static bool crfSupported = true;
        private static bool crfOn = true;
        private static int crfMinValue;
        private static int crfMaxValue;

        private static int crf;

        private static int bitrate;
        private static int bitrateMinValue;
        private static int bitrateMaxValue;

        private static string codec;
        private static Dictionary<string, string> codecList;

        private static Dictionary<string, string> defaultAudioCodecs;

        private static string encoder;

        private static string additionalArguments;

        private static bool noAudioInFirstPass = true;

        private static string frameRate;
        private static Dictionary<string, string> frameRateList = new Dictionary<string, string>
        {
            { "10", "10" },
            { "12", "12" },
            { "15", "15" },
            { "18", "18" },
            { "20", "20" },
            { "24000/1001", "23.976" },
            { "24", "24" },
            { "25", "25" },
            { "30000/1001", "29.97" },
            { "30", "30" },
            { "48", "48" },
            { "50", "50" },
            { "60000/1001", "59.94" },
            { "60", "60" }
        };

        public static string Codec
        {
            get { return codec; }
            set
            {
                codec = value;

                bitrateMinValue = 100;
                bitrateMaxValue = 100000;
                bitrate = 3000;

                additionalArguments = "";

                noAudioInFirstPass = true;

                switch (codec)
                {
                    case "h264":
                        encoder = "libx264";
                        crfMinValue = 1;
                        crfMaxValue = 51;
                        crf = 20;
                        additionalArguments = "-aq-mode autovariance-biased -fast-pskip 0 -mbtree 0 -pix_fmt yuv420p"; // todo: do
                        break;
                    case "h265":
                        encoder = "libx265";
                        crfMinValue = 1;
                        crfMaxValue = 51;
                        crf = 25;
                        noAudioInFirstPass = false;
                        break;
                    case "vp9":
                        encoder = "libvpx-vp9";
                        crfMinValue = 1;
                        crfMaxValue = 63;
                        crf = 30;
                        noAudioInFirstPass = false;
                        break;
                    case "vp8":
                        encoder = "libvpx";
                        crfSupported = false;
                        crfOn = false;
                        break;
                    default:
                        encoder = "none";
                        crfSupported = false;
                        crfOn = false;
                        break;
                }
            }
        }

        public static Dictionary<string, string> CodecList
        {
            get { return codecList; }
            set { codecList = value; }
        }

        public static Dictionary<string, string> DefaultAudioCodecs
        {
            get { return defaultAudioCodecs; }
            set { defaultAudioCodecs = value; }
        }

        public static string Encoder => encoder;

        public static bool CRFSupported => crfSupported;

        public static bool UseCRF
        {
            get { return crfOn; }
            set { crfOn = value; }
        }

        public static int CRFMinValue => crfMinValue;

        public static int CRFMaxValue => crfMaxValue;

        public static int CRF
        {
            get { return crf; }
            set
            {
                if (value < crfMinValue)
                    crf = crfMinValue;
                else if (value > crfMaxValue)
                    crf = crfMaxValue;
                else
                    crf = value;
            }
        }

        public static int BitrateMinValue => bitrateMinValue;

        public static int BitrateMaxValue => bitrateMaxValue;

        public static int Bitrate
        {
            get { return bitrate; }
            set
            {
                if (value < bitrateMinValue)
                    bitrate = bitrateMinValue;
                else if (value > bitrateMaxValue)
                    bitrate = bitrateMaxValue;
                else
                    bitrate = value;
            }
        }

        public static string FrameRate
        {
            get { return frameRate; }
            set { frameRate = value; }
        }

        public static Dictionary<string, string> FrameRateList => frameRateList;

        public static string AdditionalArguments => additionalArguments;

        public static bool NoAudioInFirstPass => noAudioInFirstPass;
    }
}
