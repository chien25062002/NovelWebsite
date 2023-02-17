using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace NovelWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AccountController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AccountModel account)
        {
            var login = _dbContext.Accounts.Where(a => a.AccountName == account.AccountName && a.Password == account.Password)
                                            .Include(a => a.User)
                                            .ThenInclude(a => a.Role);
            if (login.Any())
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountName)
                };
                claims.Add(new Claim(ClaimTypes.Role, login.First().User.Role.RoleName));
                var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIndentity));
            }
            else
            {
                TempData["LoginError"] = "Username or password is incorrect.";
            }
            return Redirect("/");
        }

    }
}
