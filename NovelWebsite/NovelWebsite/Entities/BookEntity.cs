using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class BookEntity : BaseEntity
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        //public string AuthorId { get; set; }
        //public string CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public AuthorEntity Author { get; set; }
        public int Chapter { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Recommends { get; set; }
        public string Avatar { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string AnotherName { get; set; }
        //public string BookStatusId { get; set; }
        public BookStatusEntity BookStatus { get; set; }
    }
}
