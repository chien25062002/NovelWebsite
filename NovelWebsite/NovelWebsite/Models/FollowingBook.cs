using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class FollowingBook : Base
    {
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
