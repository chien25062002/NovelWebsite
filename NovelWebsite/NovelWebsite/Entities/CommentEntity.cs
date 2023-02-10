using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class CommentEntity : BaseEntity
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("fk_comment_user")]
        public UserEntity User { get; set; }
        [ForeignKey("fk_comment_book")]
        public BookEntity Book { get; set; }
        [ForeignKey("fk_comment_chapter")]
        public ChapterEntity Chapter { get; set; }
        [ForeignKey("fk_comment_comment")]
        public CommentEntity ReplyCommentId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
