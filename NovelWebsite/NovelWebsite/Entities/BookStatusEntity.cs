using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class BookStatusEntity : BaseEntity
    {
        [Key]
        public string BookStatusId { get; set; }
        public string StatusName { get; set; }
    }
}
