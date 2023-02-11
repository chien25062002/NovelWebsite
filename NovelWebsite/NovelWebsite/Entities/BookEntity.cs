using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class BookEntity : BaseEntity
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        //public string AuthorId { get; set; }
        //public string CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryEntity Category { get; set; }
        [ForeignKey("AuthorId")]
        public AuthorEntity Author { get; set; }
        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
        public int NumberOfChapters { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Recommends { get; set; }
        public string Avatar { get; set; }
        public string Introduce { get; set; }
        //public string BookStatusId { get; set; }
        [ForeignKey("BookStatusId")]
        public string BookStatusId { get; set; }
    }
}
