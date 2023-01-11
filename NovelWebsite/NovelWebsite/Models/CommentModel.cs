using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class CommentModel : BaseModel
    {
        public string CommentId { get; set; }
        public UserModel User { get; set; }
        public BookModel Book { get; set; }
        public ChapterModel Chapter { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}
