using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class UserModel : BaseModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string CoverPhoto { get; set; }
        public string Email { get; set; }
        public UserRoleModel UserRole { get; set; }
    }
}
