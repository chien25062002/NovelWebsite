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
            var login = _dbContext.Accounts.Where(a => a.AccountName == account.AccountName && a.Password == account.Password && a.IsDeleted == false && a.Status == 0)
                                            .Include(a => a.User)
                                            .ThenInclude(a => a.Role)
                                            .FirstOrDefault();
            if (login != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountName)
                };
                claims.Add(new Claim(ClaimTypes.Role, login.User.Role.RoleName));
                claims.Add(new Claim("Username", login.User.UserName));
                claims.Add(new Claim("Avatar", login.User.Avatar));
                var claimIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIndentity));
                return Json("");
            }
            else
            {
                return Json("Tên đăng nhập hoặc mật khẩu không chính xác");
            }
        }

        [HttpPost]
        public IActionResult Signup(AccountModel account)
        {
            var check = _dbContext.Accounts.FirstOrDefault(p => p.AccountName == account.AccountName && p.IsDeleted == false && p.Status == 0);
            if (check != null)
            {
                return Json("Tên tài khoản trùng với một tài khoản khác");
            }
            check = _dbContext.Accounts.Include(p => p.User).FirstOrDefault(u => u.User.Email == account.Email && u.IsDeleted == false && u.Status == 0);
            if (check != null)
            {
                return Json("Đã có tài khoản đăng ký email này");
            }
            var user = new UserEntity()
            {
                UserName = account.AccountName,
                Avatar = "/image/default.jpg",
                CoverPhoto = "image/bg_default.png",
                Email = account.Email,
                RoleId = 3,
                CreatedDate = DateTime.Now,
                CreatedBy = "system",
                UpdatedDate = DateTime.Now,
                UpdatedBy = "system",
                Status = 0,
                IsDeleted = false,
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var acc = new AccountEntity()
            {
                AccountName = account.AccountName,
                Password = account.Password,
                UserId = user.UserId,
                CreatedDate = DateTime.Now,
                CreatedBy = "system",
                UpdatedDate = DateTime.Now,
                UpdatedBy = "system",
                Status = 0,
                IsDeleted = false,
            };
            _dbContext.Accounts.Add(acc);
            _dbContext.SaveChanges();
            return Json("");
        }

        public IActionResult GetAccount()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = HttpContext.User.Identity as ClaimsIdentity;
                var user = new UserModel()
                {
                    AccountName = claims.FindFirst(ClaimTypes.NameIdentifier).Value,
                    Role = claims.FindFirst(ClaimTypes.Role).Value,
                    Username = claims.FindFirst("Username").Value,
                    Avatar = claims.FindFirst("Avatar").Value
                };
                return Json(user);
            }
            return Json("");
        }

        public IActionResult GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var claims = HttpContext.User.Identity as ClaimsIdentity;
                var account = _dbContext.Accounts.Where(a => a.AccountName == claims.FindFirst(ClaimTypes.NameIdentifier).Value)
                                                 .Include(a => a.User)
                                                 .FirstOrDefault();
                return Json(account);
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
