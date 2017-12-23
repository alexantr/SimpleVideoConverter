using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexantr.SimpleVideoConverter
{
    public static class AudioConfig
    {
        //public const int MinBitrate = 8;
        //public const int MaxBitrate = 320;

        /*private static string[] bitrateList = new string[] {
            "32", "48", "64", "96",
            "112", "128", "160", "192",
            "224", "256", "320"
        };*/

        /*private static string[] frequencyList = new string[] {
            "8000", "12000", "16000", "22050",
            "24000", "32000", "44100", "48000"
        };*/

        /*private static string[,] channelsList = new string[,] {
            { "1", "1 (моно)" },
            { "2", "2 (стерео)" }
        };*/

        private static int bitrate;
        private static int[] bitrates;

        private static int channels;

        private static int maxChannels;

        private static int quality;

        private static int sampleRate;
        private static int[] sampleRates;

        private static int[] vbrModes;
        private static bool vbrSupported;
        private static bool vbrOn;

        private static string codec;
        private static string encoder;

        //private static string[,] channelsList;

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

                // Init codec values
                switch (codec)
                {
                    case "aac":
                        bitrate = 128;
                        channels = 0;
                        maxChannels = 8;
                        sampleRate = 0;
                        sampleRates = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        Encoder = "aac";
                        break;
                    case "mp3":
                        bitrate = 128;
                        channels = 0;
                        maxChannels = 2;
                        sampleRate = 0;
                        sampleRates = new int[] {
                            8000, 11025, 12000, 16000, 22050, 24000, 32000, 44100, 48000
                        };
                        Encoder = "libmp3lame";
                        break;
                    case "opus":
                        bitrate = 96;
                        channels = 0;
                        maxChannels = 8;
                        sampleRate = 0;
                        sampleRates = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        Encoder = "libopus";
                        break;
                    case "vorbis":
                        bitrate = 128;
                        channels = 0;
                        maxChannels = 8;
                        sampleRate = 0;
                        sampleRates = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        Encoder = "libvorbis";
                        break;
                    default:
                        bitrate = 128;
                        channels = 0;
                        maxChannels = 8;
                        sampleRate = 0;
                        sampleRates = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        Encoder = codec;
                        break;
                }
            }
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
        public static int[] Bitrates
        {
            get
            {
                switch (codec)
                {
                    case "mp3":
                        if (sampleRate == 8000 || sampleRate == 11025 || sampleRate == 12000)
                        {
                            // MPEG-2.5 Layer III bitrates
                            bitrates = new int[] {
                                8, 16, 24, 32, 40, 48, 56, 64
                            };
                        }
                        else if (sampleRate == 16000 || sampleRate == 22050 || sampleRate == 24000)
                        {
                            // MPEG-2 Layer III bitrates
                            bitrates = new int[] {
                                8, 16, 24, 32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160
                            };
                        }
                        else
                        {
                            // MPEG-1 Layer III bitrates
                            bitrates = new int[] {
                                32, 40, 48, 56, 64, 80, 96, 112, 128, 144, 160, 192, 224, 256, 320
                            };
                        }
                        break;
                    default:
                        bitrates = new int[] {
                            8, 16, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320
                        };
                        break;
                }

                return bitrates;
            }
        }

        public static int Channels
        {
            get { return channels; }
            set { channels = value; }
        }

        /// <summary>
        /// Stores audio encoder value and determines encoder settings and presets.
        /// </summary>
        public static string Encoder
        {
            get { return encoder; }
            set
            {
                encoder = value;

                switch (encoder)
                {
                    case "libvorbis":
                        vbrSupported = true;
                        quality = 4; // 3-6 is a good range to try
                        // 10 is highest quality
                        vbrModes = new int[] {
                            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                        };
                        break;
                    default:
                        vbrSupported = false;
                        vbrOn = false;
                        break;
                }
            }
        }

        public static int MaxChannels
        {
            get { return maxChannels; }
            set { maxChannels = value; }
        }

        public static int Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        public static int SampleRate
        {
            get { return sampleRate; }
            set { sampleRate = value; }
        }

        public static int[] SampleRates
        {
            get { return sampleRates; }
        }

        public static int[] VBRModes
        {
            get { return vbrModes; }
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
    }
}
