using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class BookModel : BaseModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string AuthorName { get; set; }
        public int UserId { get; set; }
        public int NumberOfChapters { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Recommends { get; set; }
        public string Avatar { get; set; }
        public string Introduce { get; set; }
        public string BookStatusId { get; set; }

    }
}
