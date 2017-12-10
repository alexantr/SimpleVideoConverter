namespace Alexantr.SimpleVideoConverter
{
    public class PictureSize
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public string ToString(string separator = "x")
        {
            return $"{Width}{separator}{Height}";
        }
    }
}
