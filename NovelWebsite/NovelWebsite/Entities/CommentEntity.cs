using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class CommentEntity : BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public UserEntity User { get; set; }
        [ForeignKey("BookId")]
        public int? BookId { get; set; }
        public BookEntity Book { get; set; }
        [ForeignKey("ChapterId")]
        public int? ChapterId { get; set; }
        public ChapterEntity Chapter { get; set; }
        [ForeignKey("CommentId")]
        public int? ReplyCommentId { get; set; }
        public CommentEntity ReplyComment { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }
    }
}
