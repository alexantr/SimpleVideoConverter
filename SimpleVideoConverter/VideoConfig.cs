using System.Collections.Generic;

namespace Alexantr.SimpleVideoConverter
{
    public static class VideoConfig
    {
        private static int crf = 20;

        private static int bitrate = 3000;
        private static string codec = "h264";

        public static string Codec
        {
            get { return codec; }
            set
            {
                codec = value;

                BitrateMinValue = 100;
                BitrateMaxValue = 100000;
                bitrate = 3000;

                AdditionalArguments = "";

                NoAudioInFirstPass = true;

                switch (codec)
                {
                    case "h264":
                        Encoder = "libx264";
                        CRFMinValue = 1;
                        CRFMaxValue = 51;
                        crf = 20;
                        AdditionalArguments = "-aq-mode autovariance-biased -fast-pskip 0 -mbtree 0 -pix_fmt yuv420p"; // todo: do
                        break;
                    case "h265":
                        Encoder = "libx265";
                        CRFMinValue = 1;
                        CRFMaxValue = 51;
                        crf = 23;
                        NoAudioInFirstPass = false;
                        break;
                    default:
                        Encoder = "none";
                        CRFSupported = false;
                        UseCRF = false;
                        break;
                }
            }
        }

        public static Dictionary<string, string> CodecList { get; } = new Dictionary<string, string>
        {
            { "h264", "H.264" },
            { "h265", "H.265" }
        };

        public static string Encoder { get; private set; }

        public static bool CRFSupported { get; private set; } = true;

        public static bool UseCRF { get; set; } = true;

        public static int CRFMinValue { get; private set; }

        public static int CRFMaxValue { get; private set; }

        public static int CRF
        {
            get { return crf; }
            set
            {
                if (value < CRFMinValue)
                    crf = CRFMinValue;
                else if (value > CRFMaxValue)
                    crf = CRFMaxValue;
                else
                    crf = value;
            }
        }

        public static int BitrateMinValue { get; private set; }

        public static int BitrateMaxValue { get; private set; }

        public static int Bitrate
        {
            get { return bitrate; }
            set
            {
                if (value < BitrateMinValue)
                    bitrate = BitrateMinValue;
                else if (value > BitrateMaxValue)
                    bitrate = BitrateMaxValue;
                else
                    bitrate = value;
            }
        }

        public static string FrameRate { get; set; }

        public static Dictionary<string, string> FrameRateList { get; } = new Dictionary<string, string>
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

        public static string AdditionalArguments { get; private set; }

        public static bool NoAudioInFirstPass { get; private set; } = true;
    }
}
