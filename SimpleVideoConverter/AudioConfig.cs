using System.Collections.Generic;

namespace Alexantr.SimpleVideoConverter
{
    public static class AudioConfig
    {
        //public static int StreamIndex = -1;
        //public static bool MustEncode = false;

        private static int bitrate;
        private static int[] bitrateList;

        private static int channels = 0;
        private static Dictionary<int, string> channelsList = new Dictionary<int, string>
        {
            { 0, "Авто" },
            { 1, "1 (моно)" },
            { 2, "2 (стерео)" }
        };

        private static int sampleRate;
        private static int[] sampleRateList;

        private static bool vbrSupported;
        private static bool vbrOn;
        private static int vbrMinValue;
        private static int vbrMaxValue;

        private static int quality;

        private static string codec;
        private static Dictionary<string, string> codecList;

        private static string encoder;

        private static string additionalArguments;

        /// <summary>
        /// Stores audio codec value and determines available encoders for
        /// FFmpeg to use. Also new settings such as bitrate and samplerate
        /// will be set if codec value is changed.
        /// </summary>
        public static string Codec
        {
            get { return codec; }
            set
            {
                codec = value;

                vbrSupported = false;
                vbrOn = false;
                additionalArguments = "";

                switch (codec)
                {
                    case "aac":
                        bitrate = 128;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        encoder = "aac";
                        vbrSupported = false;
                        vbrOn = false;
                        additionalArguments = "-strict -2";
                        break;
                    case "mp3":
                        bitrate = 128;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 12000, 16000, 22050, 24000, 32000, 44100, 48000
                        };
                        encoder = "libmp3lame";
                        break;
                    case "opus":
                        bitrate = 128;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        encoder = "libopus";
                        break;
                    case "vorbis":
                        bitrate = 128;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        encoder = "libvorbis";
                        vbrSupported = true;
                        quality = 4; // 3-6 is a good range to try
                        // 10 is highest quality
                        vbrMinValue = 0;
                        vbrMaxValue = 10;
                        break;
                }
            }
        }

        public static Dictionary<string, string> CodecList
        {
            get { return codecList; }
            set { codecList = value; }
        }

        public static string Encoder
        {
            get { return encoder; }
        }

        public static int Bitrate
        {
            get { return bitrate; }
            set { bitrate = value; }
        }

        /// <summary>
        /// Determines and returns supported bitrates that is based on
        /// the audio codec and sample rates.
        /// </summary>
        public static int[] BitrateList
        {
            get
            {
                switch (codec)
                {
                    case "mp3":
                        if (sampleRate == 8000 || sampleRate == 11025 || sampleRate == 12000)
                        {
                            // MPEG-2.5 Layer III bitrates
                            bitrateList = new int[] {
                                8, 16, 24, 32, 40, 48, 56, 64
                            };
                        }
                        else if (sampleRate == 16000 || sampleRate == 22050 || sampleRate == 24000)
                        {
                            // MPEG-2 Layer III bitrates
                            bitrateList = new int[] {
                                8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160
                            };
                        }
                        else
                        {
                            // MPEG-1 Layer III bitrates
                            bitrateList = new int[] {
                                32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, 192, 224, 256, 320
                            };
                        }
                        break;
                    default:
                        bitrateList = new int[] {
                            8, 16, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320
                        };
                        break;
                }

                return bitrateList;
            }
        }

        public static bool VBRSupported
        {
            get { return vbrSupported; }
        }

        public static bool UseVBR
        {
            get { return vbrOn; }
            set { vbrOn = value; }
        }

        private static int VBRMinValue
        {
            get { return vbrMinValue; }
        }

        private static int VBRMaxValue
        {
            get { return vbrMaxValue; }
        }

        public static int Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        public static int Channels
        {
            get { return channels; }
            set { channels = value; }
        }

        public static Dictionary<int, string> ChannelsList
        {
            get { return channelsList; }
        }

        public static int SampleRate
        {
            get { return sampleRate; }
            set { sampleRate = value; }
        }

        public static int[] SampleRateList
        {
            get { return sampleRateList; }
        }

        public static string AdditionalArguments
        {
            get { return additionalArguments; }
        }
    }
}
