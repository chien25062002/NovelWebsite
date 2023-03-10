using NovelWebsite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Entities
{
    public class ReviewEntity : BaseEntity
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public BookEntity Book { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }
    }
}
