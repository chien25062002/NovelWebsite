using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class CommentModel : BaseModel
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int ChapterId { get; set; }
        public int ReplyCommentId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}
