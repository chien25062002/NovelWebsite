using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class UserEntity : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string CoverPhoto { get; set; }
        public string Email { get; set; }
        public UserRoleEntity UserRole { get; set; }
    }
}
