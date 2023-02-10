using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class BookUserEntity
    {
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        [ForeignKey("BookId")]
        public BookEntity Book { get; set; }
    }
}
