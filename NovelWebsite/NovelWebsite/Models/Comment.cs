namespace NovelWebsite.Models
{
    public class Comment : Base
    {
        public string CommentId { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public Chapter Chapter { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}
