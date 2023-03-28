using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class AccountModel : BaseModel
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
