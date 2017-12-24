﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexantr.SimpleVideoConverter
{
    public static class AudioConfig
    {
        private static int bitrate;
        private static int[] bitrateList;

        private static string channels;

        private static int quality;

        private static int sampleRate;
        private static int[] sampleRateList;

        private static int[] vbrModeList;
        private static bool vbrSupported;
        private static bool vbrOn;

        private static string codec;
        private static string[,] codecList;

        private static string encoder;

        private static string[,] channelsList = new string[,] {
            { "auto", "Авто" },
            { "1", "1 (моно)" },
            { "2", "2 (стерео)" }
        };

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
                        channels = "auto";
                        //maxChannels = 8;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        Encoder = "aac";
                        break;
                    case "mp3":
                        bitrate = 128;
                        channels = "auto";
                        //maxChannels = 2;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 12000, 16000, 22050, 24000, 32000, 44100, 48000
                        };
                        Encoder = "libmp3lame";
                        break;
                    case "opus":
                        bitrate = 128;
                        channels = "auto";
                        //maxChannels = 8;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        Encoder = "libopus";
                        break;
                    case "vorbis":
                        bitrate = 128;
                        channels = "auto";
                        //maxChannels = 8;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        Encoder = "libvorbis";
                        break;
                    default:
                        bitrate = 128;
                        channels = "auto";
                        //maxChannels = 8;
                        sampleRate = 0;
                        sampleRateList = new int[] {
                            8000, 11025, 16000, 22050, 32000, 44100, 48000, 96000, 192000
                        };
                        Encoder = codec;
                        break;
                }
            }
        }

        public static string[,] CodecList
        {
            get { return codecList; }
            set { codecList = value; }
        }

        public static int Bitrate
        {
            get { return bitrate; }
            set {
                if (Helper.IsValid(value, bitrateList))
                    bitrate = value;
                else if (bitrateList.Length > 0)
                    bitrate = bitrateList[bitrateList.Length - 1];
                else
                    bitrate = 64; // max value in everywhere
            }
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

        public static string Channels
        {
            get { return channels; }
            set { channels = value; }
        }

        public static string[,] ChannelsList
        {
            get { return channelsList; }
        }

        /// <summary>
        /// Stores audio encoder value and determines encoder settings and presets.
        /// </summary>
        public static string Encoder
        {
            get { return encoder; }
            private set
            {
                encoder = value;

                switch (encoder)
                {
                    case "libvorbis":
                        vbrSupported = true;
                        quality = 4; // 3-6 is a good range to try
                        // 10 is highest quality
                        vbrModeList = new int[] {
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

        /*public static int MaxChannels
        {
            get { return maxChannels; }
            set { maxChannels = value; }
        }*/

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

        public static int[] SampleRateList
        {
            get { return sampleRateList; }
        }

        public static int[] VBRModeList
        {
            get { return vbrModeList; }
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
