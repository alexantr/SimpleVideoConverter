namespace Alexantr.SimpleVideoConverter
{
    public class Crop
    {
        public int Left { get; set; } = 0;

        public int Right { get; set; } = 0;

        public int Top { get; set; } = 0;

        public int Bottom { get; set; } = 0;

        public void Reset()
        {
            Left = 0;
            Right = 0;
            Top = 0;
            Bottom = 0;
        }
    }
}
