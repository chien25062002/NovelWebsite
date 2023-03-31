using NovelWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Entities
{
    public class BannerEntity : BaseEntity
    {
        [Key]
        public int BannerId { get; set; }
        public string BannerSize { get; set; }
        public string BannerImage { get; set; }

        public int? BookId { get; set; }

    }
}
