using System.Collections.Generic;

namespace Alexantr.SimpleVideoConverter
{
    public static class AudioConfig
    {
        public const string CodecAAC = "aac";

        public const int DefaultBitrate = 128;
        public const int DefaultBitrateForMultiChannels = 384;

        private static string codec;

        public static string Codec
        {
            get { return codec; }
            set
            {
                codec = value;

                //VBRSupported = false;
                //UseVBR = false;
                AdditionalArguments = "";

                Bitrate = DefaultBitrate;

                switch (codec)
                {
                    case CodecAAC:
                        Encoder = "aac";
                        break;
                    default:
                        Encoder = "copy";
                        break;
                }
            }
        }

        public static Dictionary<string, string> CodecList { get; } = new Dictionary<string, string>
        {
            { CodecAAC, "AAC" }
        };

        public static string Encoder { get; private set; }

        public static int Bitrate { get; set; }

        public static int[] BitrateList { get; } = new int[] { 8, 16, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, 384, 448, 640 };

        //public static bool VBRSupported { get; private set; }

        //public static bool UseVBR { get; set; }

        //private static int VBRMinValue { get; set; }

        //private static int VBRMaxValue { get; set; }

        //public static int Quality { get; set; }

        public static int Channels { get; set; } = 0; // 0 is auto

        public static Dictionary<int, string> ChannelsList { get; } = new Dictionary<int, string>
        {
            { 0, "Авто" },
            { 1, "1 (моно)" },
            { 2, "2 (стерео)" }
        };

        public static int SampleRate { get; set; } = 0; // 0 is auto

        public static int[] SampleRateList { get; } = new int[] { 8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000 };

        public static string AdditionalArguments { get; private set; }
    }
}
