using System;
using System.Collections.Generic;

namespace Alexantr.SimpleVideoConverter
{
    public static class FormatConfig
    {
        private static string format;

        private static Dictionary<string, string> formatList = new Dictionary<string, string> {
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
                if (!formatList.ContainsKey(value))
                {
                    throw new Exception("Invalid format");
                }

                format = value;

                switch (format)
                {
                    case "mp4":
                        VideoConfig.CodecList = new Dictionary<string, string> {
                            { "h264", "H264" }
                        };
                        AudioConfig.CodecList = new Dictionary<string, string>
                        {
                            { "aac", "AAC" }
                        };
                        VideoConfig.DefaultAudioCodecs = new Dictionary<string, string> {
                            { "h264", "aac" }
                        };
                        if (VideoConfig.Codec == null || !VideoConfig.CodecList.ContainsKey(VideoConfig.Codec))
                            VideoConfig.Codec = "h264";
                        if (AudioConfig.Codec == null || !AudioConfig.CodecList.ContainsKey(AudioConfig.Codec))
                            AudioConfig.Codec = "aac";
                        break;
                    case "webm":
                        VideoConfig.CodecList = new Dictionary<string, string> {
                            { "vp9", "VP9" },
                            { "vp8", "VP8" }
                        };
                        AudioConfig.CodecList = new Dictionary<string, string> {
                            { "opus", "Opus" },
                            { "vorbis", "Vorbis" }
                        };
                        VideoConfig.DefaultAudioCodecs = new Dictionary<string, string> {
                            { "vp9", "opus" },
                            { "vp8", "vorbis" }
                        };
                        if (VideoConfig.Codec == null || !VideoConfig.CodecList.ContainsKey(VideoConfig.Codec))
                            VideoConfig.Codec = "vp9";
                        if (AudioConfig.Codec == null || !AudioConfig.CodecList.ContainsKey(AudioConfig.Codec))
                            AudioConfig.Codec = "opus";
                        break;
                    /*case "mkv":
                        VideoConfig.Codecs = new Dictionary<string, string> {
                            { "h264", "H264" },
                            { "vp9", "VP9" },
                            { "vp8", "VP8" }
                        };
                        AudioConfig.Codecs = new Dictionary<string, string> {
                            { "aac", "AAC" },
                            //{ "ac3", "AC3" }, // can only pass, not encode
                            { "vorbis", "Vorbis" },
                            { "opus", "Opus" }
                        };
                        VideoConfig.DefaultAudioCodecs = new Dictionary<string, string> {
                            { "h264", "aac" },
                            { "vp9", "opus" },
                            { "vp8", "vorbis" }
                        };
                        break;
                    case "avi":
                        VideoConfig.Codecs = new Dictionary<string, string> {
                            { "mpeg4", "MPEG-4" }
                        };
                        AudioConfig.Codecs = new Dictionary<string, string> {
                            { "mp3", "MP3" },
                            //{ "ac3", "AC3" } // can only pass, not encode
                        };
                        VideoConfig.DefaultAudioCodecs = new Dictionary<string, string> {
                            { "mpeg4", "mp3" }
                        };
                        break;*/
                }
            }
        }

        public static Dictionary<string, string> FormatList
        {
            get { return formatList; }
        }
    }
}
