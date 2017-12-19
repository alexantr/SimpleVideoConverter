using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.XPath;

namespace Alexantr.SimpleVideoConverter
{
    public class InputFile
    {
        public List<VideoStream> VideoStreams = new List<VideoStream>();
        public List<AudioStream> AudioStreams = new List<AudioStream>();

        public string FullPath { get; private set; }

        public string FileName { get; private set; }

        public double FileSize { get; private set; }

        public string Format { get; private set; }

        public TimeSpan Duration { get; private set; }

        public int BitRate { get; private set; }

        // tags
        public string TagTitle { get; private set; }
        public string TagAuthor { get; private set; }
        public string TagCopyright { get; private set; }
        public string TagComment { get; private set; }
        public string TagCreationTime { get; private set; }

        // full xml
        public string StreamInfo { get; private set; }

        public InputFile(string path)
        {
            FullPath = path;
            FileName = Path.GetFileName(FullPath);
        }

        public void Probe()
        {
            string args = $"\"{FullPath}\" -of xml -show_streams -show_format";
            using (FFprobeProcess prober = new FFprobeProcess(args))
            {
                StreamInfo = prober.Probe();
                using (StringReader stringReader = new StringReader(StreamInfo))
                {
                    XPathDocument doc = new XPathDocument(stringReader);

                    XPathNavigator format = doc.CreateNavigator().SelectSingleNode("//ffprobe/format");
                    if (format != null)
                    {
                        // format
                        Format = format.GetAttribute("format_long_name", "");

                        // file size
                        double.TryParse(format.GetAttribute("size", ""), out double fileSize);
                        FileSize = fileSize;

                        // duration
                        double.TryParse(format.GetAttribute("duration", ""), out double duration);
                        Duration = TimeSpan.FromSeconds(duration);

                        // bit rate
                        double.TryParse(format.GetAttribute("bit_rate", ""), out double bitRate);
                        BitRate = Convert.ToInt32(Math.Round(bitRate / 1000.0, 0));

                        if (!format.IsEmptyElement)
                        {
                            XPathNodeIterator formatTags = format.Select(".//tag");
                            foreach (XPathNavigator formatTag in formatTags)
                            {
                                string tagKey = formatTag.GetAttribute("key", "");
                                string tagValue = formatTag.GetAttribute("value", "");

                                byte[] valueBytes = Encoding.Default.GetBytes(tagValue);

                                if (tagKey == "title")
                                    TagTitle = Encoding.UTF8.GetString(valueBytes);

                                if (tagKey == "artist")
                                    TagAuthor = Encoding.UTF8.GetString(valueBytes);

                                if (tagKey == "copyright")
                                    TagCopyright = Encoding.UTF8.GetString(valueBytes);

                                if (tagKey == "comment")
                                    TagComment = Encoding.UTF8.GetString(valueBytes);

                                if (tagKey == "creation_time")
                                    TagCreationTime = Encoding.UTF8.GetString(valueBytes);
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidDataException("Can't determine video format");
                    }

                    XPathNodeIterator streams = doc.CreateNavigator().Select("//ffprobe/streams/stream");
                    foreach (XPathNavigator stream in streams)
                    {
                        int.TryParse(stream.GetAttribute("index", ""), out int streamIndex);

                        string codecType = stream.GetAttribute("codec_type", "");
                        if (codecType == "audio")
                        {
                            AudioStream audioStream = new AudioStream
                            {
                                Index = streamIndex,
                                CodecName = stream.GetAttribute("codec_name", ""),
                                CodecLongName = stream.GetAttribute("codec_long_name", ""),
                                SampleRate = stream.GetAttribute("sample_rate", "")
                            };

                            // bit rate
                            double.TryParse(stream.GetAttribute("bit_rate", ""), out double streamBitRate);
                            audioStream.BitRate = Convert.ToInt32(Math.Round(streamBitRate / 1000.0, 0));

                            // channels
                            int.TryParse(stream.GetAttribute("channels", ""), out int channels);
                            audioStream.Channels = channels;
                            audioStream.ChannelLayout = stream.GetAttribute("channel_layout", "");

                            if (!stream.IsEmptyElement)
                            {
                                // language
                                stream.MoveTo(stream.SelectSingleNode(".//tag[@key='language']"));
                                audioStream.Language = stream.GetAttribute("value", "");
                            }

                            AudioStreams.Add(audioStream);
                        }
                        else if (codecType == "video")
                        {
                            string frameRate = stream.GetAttribute("r_frame_rate", "");
                            
                            // skip image cover
                            if (frameRate == "90000/1")
                                continue;

                            VideoStream videoStream = new VideoStream
                            {
                                Index = streamIndex,
                                CodecName = stream.GetAttribute("codec_name", ""),
                                CodecLongName = stream.GetAttribute("codec_long_name", "")
                            };

                            // frame rate
                            string avgFrameRate = stream.GetAttribute("avg_frame_rate", "");
                            string[] frameRateParts = !string.IsNullOrWhiteSpace(avgFrameRate) ? avgFrameRate.Split('/')  : frameRate.Split('/');
                            videoStream.FrameRate = frameRateParts.Length != 2 ? 0.0 : Math.Round(double.Parse(frameRateParts[0]) / double.Parse(frameRateParts[1]), 3);

                            // frame count
                            int.TryParse(stream.GetAttribute("nb_frames", ""), out int frameCount);
                            if (frameCount == 0)
                                frameCount = (int)Math.Round(Duration.TotalMilliseconds * videoStream.FrameRate / 1000.0, 0);
                            videoStream.FrameCount = frameCount;

                            // field order
                            string fieldOrder = stream.GetAttribute("field_order", "");
                            if (string.IsNullOrWhiteSpace(fieldOrder))
                                fieldOrder = "progressive";
                            videoStream.FieldOrder = fieldOrder;

                            // original width and height
                            int.TryParse(stream.GetAttribute("width", ""), out int width);
                            int.TryParse(stream.GetAttribute("height", ""), out int height);
                            videoStream.OriginalSize.Width = width;
                            videoStream.OriginalSize.Height = height;
                            videoStream.UsingDAR = false;

                            // picture width and height
                            string[] sarParts = stream.GetAttribute("sample_aspect_ratio", "").Split(':');
                            if (sarParts.Length == 2 && sarParts[0] != "0" && sarParts[1] != "0" && (sarParts[0] != "1" || sarParts[1] != "1"))
                            {
                                string[] darParts = stream.GetAttribute("display_aspect_ratio", "").Split(':');
                                double sarX = double.Parse(sarParts[0]);
                                double sarY = double.Parse(sarParts[1]);
                                double darX = double.Parse(darParts[0]);
                                double darY = double.Parse(darParts[1]);
                                if (darX < darY)
                                    height = (int)(Convert.ToDouble(height) / (sarX / sarY));
                                else
                                    width = (int)(Convert.ToDouble(width) * (sarX / sarY));
                                videoStream.UsingDAR = true;
                            }
                            videoStream.PictureSize.Width = width;
                            videoStream.PictureSize.Height = height;

                            if (!stream.IsEmptyElement)
                            {
                                XPathNodeIterator videoStreamTags = stream.Select(".//tag");
                                foreach (XPathNavigator videoStreamTag in videoStreamTags)
                                {
                                    string tagKey = videoStreamTag.GetAttribute("key", "");
                                    string tagValue = videoStreamTag.GetAttribute("value", "");

                                    // language
                                    if (tagKey == "language")
                                        videoStream.Language = tagValue;

                                    // correct picture size if video is rotated
                                    if (tagKey == "rotate" && (tagValue == "90" || tagValue == "270"))
                                    {
                                        videoStream.PictureSize.Width = height;
                                        videoStream.PictureSize.Height = width;

                                        int ow = videoStream.OriginalSize.Width;
                                        int oh = videoStream.OriginalSize.Height;
                                        videoStream.OriginalSize.Width = oh;
                                        videoStream.OriginalSize.Height = ow;
                                    }
                                }
                            }

                            VideoStreams.Add(videoStream);
                        }
                    }

                    if (VideoStreams.Count == 0)
                    {
                        throw new InvalidDataException("Can't find any video stream");
                    }
                }
            }
        }
    }
}
