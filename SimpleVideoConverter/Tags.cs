namespace Alexantr.SimpleVideoConverter
{
    public class Tags
    {
        public string Title { get; set; } = "";

        public string Author { get; set; } = "";

        public string Copyright { get; set; } = "";

        public string Comment { get; set; } = "";

        public string CreationTime { get; set; } = "";

        public void Clear()
        {
            Title = "";
            Author = "";
            Copyright = "";
            Comment = "";
            CreationTime = "";
        }
    }
}
