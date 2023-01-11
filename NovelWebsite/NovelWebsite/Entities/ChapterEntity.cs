using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class ChapterEntity : BaseEntity
    {
        [Key]
        public string ChapterId { get; set; }
        public BookEntity Book { get; set; }
        public string ChapterNumber { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
    }
}
