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
                                            .ThenInclude(a => a.Role)
                                            .FirstOrDefault();
            if (login != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountName)
                };
                claims.Add(new Claim("Role", login.User.Role.RoleName));
                claims.Add(new Claim("Username", login.User.UserName));
                claims.Add(new Claim("Avatar", login.User.Avatar));
                var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIndentity));
            }
            else
            {
                TempData["LoginError"] = "Username or password is incorrect.";
            }
            return Redirect("/");
        }

        public IActionResult GetAccount()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = HttpContext.User.Identity as ClaimsIdentity;
                var x = claims.FindFirst("Role").Value;
                var user = new UserModel()
                {
                    AccountName = claims.FindFirst(ClaimTypes.NameIdentifier).Value,
                    Role = claims.FindFirst("Role").Value,
                    Username = claims.FindFirst("Username").Value,
                    Avatar = claims.FindFirst("Avatar").Value
                };
                return Json(user);
            }
            return Json("");
        }

        public async Task<IActionResult> SignoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
