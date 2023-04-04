using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using System.Security.Claims;

namespace NovelWebsite.Controllers
{
    public class PartialController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PartialController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult UserNavbar()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var userId = _dbContext.Accounts.Where(a => a.AccountName == claims.FindFirst(ClaimTypes.NameIdentifier).Value).FirstOrDefault().UserId;
            return PartialView("UserNavbar", userId);
        }
    }
}
