using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class UserRoleEntity : BaseEntity
    {
        [Key]
        public string UserRoleId { get; set; }
        public string UserRoleName { get; set; }
    }
}
