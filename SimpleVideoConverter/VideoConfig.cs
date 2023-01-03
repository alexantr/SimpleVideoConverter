using System.Collections.Generic;

namespace Alexantr.SimpleVideoConverter
{
    public static class VideoConfig
    {
        public const string CodecH264 = "h264";
        public const string CodecHEVC = "hevc";

        public const float MinCRF = 0f;
        public const float MaxCRF = 51.0f;

        public const int MinBitrate = 100;
        public const int MaxBitrate = 100000;

        public const string DefaultPresetH264 = "veryslow";
        public const string DefaultPreset = "slow";

        private static float crf = 20.0f;
        private static int bitrate = 3000;

        private static string codec;

        private static string preset = "";

        public static string Codec
        {
            get { return codec; }
            set
            {
                codec = value;

                switch (codec)
                {
                    case CodecH264:
                        Encoder = "libx264";
                        //CRF = 20.0f;
                        AdditionalArguments = "";
                        break;
                    case CodecHEVC:
                        Encoder = "libx265";
                        //CRF = 23.0f;
                        AdditionalArguments = "";
                        break;
                    default:
                        Encoder = "copy";
                        CRFSupported = false;
                        UseCRF = false;
                        AdditionalArguments = "";
                        break;
                }
            }
        }

        public static Dictionary<string, string> CodecList { get; } = new Dictionary<string, string>
        {
            { CodecH264, "H.264" },
            { CodecHEVC, "HEVC" }
        };

        public static string Encoder { get; private set; }

        public static bool CRFSupported { get; private set; } = true;

        public static bool UseCRF { get; set; } = true;

        public static float CRF
        {
            get { return crf; }
            set
            {
                if (value < MinCRF)
                    crf = MinCRF;
                else if (value > MaxCRF)
                    crf = MaxCRF;
                else
                    crf = value;
            }
        }

        public static int BitrateMinValue { get; private set; } = MinBitrate;

        public static int BitrateMaxValue { get; private set; } = MaxBitrate;

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

        public static string Preset
        {
            get 
            {
                if (string.IsNullOrEmpty(preset))
                {
                    if (codec == CodecH264)
                        preset = DefaultPresetH264;
                    else
                        preset = DefaultPreset;
                }
                return preset;
            }
            set { preset = value; }
        }

        public static string[] PresetList { get; } = new string[] {
            "ultrafast",
            "superfast",
            "veryfast",
            "faster",
            "fast",
            "medium",
            "slow",
            "slower",
            "veryslow",
            "placebo"
        };
    }
}
