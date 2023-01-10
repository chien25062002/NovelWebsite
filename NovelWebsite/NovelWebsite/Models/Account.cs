using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class Account : Base
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string AccountName { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
    }
}
