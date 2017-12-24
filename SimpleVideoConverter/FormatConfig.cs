using System;

namespace Alexantr.SimpleVideoConverter
{
    public static class FormatConfig
    {
        private static string format;

        private static string[,] formatList = new string[,] {
            { "mp4", "MP4" },
            { "webm", "WebM" },
            //{ "mkv", "MKV" },
            //{ "avi", "AVI" },
        };

        public static string Format
        {
            get { return format; }
            set
            {
                if (!Helper.IsValid(value, formatList))
                {
                    throw new Exception("Invalid format");
                }

                format = value;

                switch (format)
                {
                    case "mp4":
                        VideoConfig.CodecList = new string[,] {
                            { "h264", "H264" }
                        };
                        AudioConfig.CodecList = new string[,] {
                            { "aac", "AAC" }
                        };
                        VideoConfig.DefaultAudioCodecs = new string[,] {
                            { "h264", "aac" }
                        };
                        if (!Helper.IsValid(VideoConfig.Codec, VideoConfig.CodecList))
                        {
                            VideoConfig.Codec = "h264";
                        }
                        if (!Helper.IsValid(AudioConfig.Codec, AudioConfig.CodecList))
                        {
                            AudioConfig.Codec = "aac";
                        }
                        break;
                    case "webm":
                        VideoConfig.CodecList = new string[,] {
                            { "vp9", "VP9" },
                            { "vp8", "VP8" }
                        };
                        AudioConfig.CodecList = new string[,] {
                            { "opus", "Opus" },
                            { "vorbis", "Vorbis" }
                        };
                        VideoConfig.DefaultAudioCodecs = new string[,] {
                            { "vp9", "opus" },
                            { "vp8", "vorbis" }
                        };
                        if (!Helper.IsValid(VideoConfig.Codec, VideoConfig.CodecList))
                        {
                            VideoConfig.Codec = "vp9";
                        }
                        if (!Helper.IsValid(AudioConfig.Codec, AudioConfig.CodecList))
                        {
                            AudioConfig.Codec = "opus";
                        }
                        break;
                    /*case "mkv":
                        VideoConfig.Codecs = new string[,] {
                            { "h264", "H264" },
                            { "vp9", "VP9" },
                            { "vp8", "VP8" }
                        };
                        AudioConfig.Codecs = new string[,] {
                            { "aac", "AAC" },
                            //{ "ac3", "AC3" }, // can only pass, not encode
                            { "vorbis", "Vorbis" },
                            { "opus", "Opus" }
                        };
                        VideoConfig.DefaultAudioCodecs = new string[,] {
                            { "h264", "aac" },
                            { "vp9", "opus" },
                            { "vp8", "vorbis" }
                        };
                        break;
                    case "avi":
                        VideoConfig.Codecs = new string[,] {
                            { "mpeg4", "MPEG-4" }
                        };
                        AudioConfig.Codecs = new string[,] {
                            { "mp3", "MP3" },
                            //{ "ac3", "AC3" } // can only pass, not encode
                        };
                        VideoConfig.DefaultAudioCodecs = new string[,] {
                            { "mpeg4", "mp3" }
                        };
                        break;*/
                }
            }
        }

        public static string[,] FormatList
        {
            get { return formatList; }
        }
    }
}
