namespace Alexantr.SimpleVideoConverter
{
    public class AudioStream
    {
        public int Index { get; set; }

        public string CodecName { get; set; }

        public string CodecLongName { get; set; }

        public string SampleRate { get; set; }

        public int BitRate { get; set; }

        public int Channels { get; set; }

        public string ChannelLayout { get; set; }

        public string Language { get; set; }
    }
}
