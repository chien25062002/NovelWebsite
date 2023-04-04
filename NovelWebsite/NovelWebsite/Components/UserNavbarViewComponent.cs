using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using System.Security.Claims;

namespace NovelWebsite.Components
{
    public class UserNavbarViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public UserNavbarViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IViewComponentResult Invoke()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var userId = _dbContext.Accounts.Where(a => a.AccountName == claims.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefault().UserId;
            return View(userId);
        }

    }
}
