namespace Alexantr.SimpleVideoConverter
{
    public class VideoStream
    {
        public int Index { get; set; }

        public string CodecName { get; set; }

        public string CodecLongName { get; set; }

        public double FrameRate { get; set; }

        public int FrameCount { get; set; }

        public string FieldOrder { get; set; }

        public PictureSize OriginalSize { get; set; }

        public PictureSize PictureSize { get; set; }

        public bool UsingDAR { get; set; } = false;

        public string Language { get; set; }
    }
}
