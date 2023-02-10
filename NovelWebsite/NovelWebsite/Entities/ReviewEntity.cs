using NovelWebsite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Entities
{
    public class ReviewEntity : BaseEntity
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("fk_review_user")]
        public UserEntity User { get; set; }
        [ForeignKey("fk_review_book")]
        public BookEntity Book { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
