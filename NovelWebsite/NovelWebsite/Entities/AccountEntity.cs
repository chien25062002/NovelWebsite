using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class AccountEntity : BaseEntity
    {
        [Key]
        public string AccountName { get; set; }
        public string Password { get; set; }
        public UserEntity User { get; set; }
    }
}
