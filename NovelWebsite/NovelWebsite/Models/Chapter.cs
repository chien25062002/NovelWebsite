namespace NovelWebsite.Models
{
    public class Chapter : Base
    {
        public string ChapterId { get; set; }
        public Book Book { get; set; }
        public string ChapterNumber { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
    }
}
