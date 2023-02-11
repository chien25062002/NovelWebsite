using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class CommentEntity : BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        [ForeignKey("BookId")]
        public BookEntity Book { get; set; }
        [ForeignKey("ChapterId")]
        public ChapterEntity Chapter { get; set; }
        [ForeignKey("CommentId")]
        public CommentEntity ReplyCommentId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
