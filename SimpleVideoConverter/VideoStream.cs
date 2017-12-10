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

        public PictureSize OriginalSize = new PictureSize();

        public PictureSize PictureSize = new PictureSize();

        public bool UsingDAR { get; set; }

        public string Language { get; set; }
    }
}
