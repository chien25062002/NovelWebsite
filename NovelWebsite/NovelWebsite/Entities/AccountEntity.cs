using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class AccountEntity : BaseEntity
    {
        [Key]
        public string AccountName { get; set; }
        public string Password { get; set; }

        [ForeignKey("UserId")]
        public UserEntity User { get; set; }
    }
}
