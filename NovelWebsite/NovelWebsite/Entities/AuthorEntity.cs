using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class AuthorEntity : BaseEntity
    {
        [Key]
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
