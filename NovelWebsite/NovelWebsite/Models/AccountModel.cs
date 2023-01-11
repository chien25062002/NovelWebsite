using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class AccountModel : BaseModel
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public UserModel User { get; set; }
    }
}
