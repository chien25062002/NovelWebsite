namespace NovelWebsite.Models
{
    public class User : Base
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string CoverPhoto { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
    }
}
