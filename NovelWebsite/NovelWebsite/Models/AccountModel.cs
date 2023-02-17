using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class AccountModel : BaseModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống tên đăng nhập")]
        public string AccountName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không được để trống mật khẩu")]
        public string Password { get; set; }
    }
}
