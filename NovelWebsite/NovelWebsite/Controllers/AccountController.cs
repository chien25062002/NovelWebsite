using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;

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
                claims.Add(new Claim("UserId", login.UserId.ToString()));
                claims.Add(new Claim("Username", login.User.UserName));
                claims.Add(new Claim("Avatar", login.User.Avatar));
                claims.Add(new Claim(ClaimTypes.Email, login.User.Email));
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
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).First();
                return Json(error);
            }
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
                if (User.Identity.AuthenticationType == GoogleDefaults.AuthenticationScheme)
                {
                    try
                    {
                        var account = _dbContext.Accounts.Where(x => x.AccountName == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) + "@google")
                                                         .Include(x => x.User).ThenInclude(x => x.Role).FirstOrDefault();
                        var ggUser = new UserModel()
                        {
                            AccountName = account.AccountName,
                            Role = account.User.Role.RoleName,
                            UserId = account.UserId,
                            Username = account.User.UserName,
                            Avatar = account.User.Avatar,
                        };
                        return Json(ggUser);
                    }
                    catch (Exception ex)
                    {
                        return Json("");
                    }
                }
                var claims = HttpContext.User.Identity as ClaimsIdentity;
                var user = new UserModel()
                {
                    AccountName = claims.FindFirst(ClaimTypes.NameIdentifier).Value,
                    Role = claims.FindFirst(ClaimTypes.Role).Value,
                    UserId = Int32.Parse(claims.FindFirst("UserId").Value),
                    Username = claims.FindFirst("Username").Value,
                    Avatar = claims.FindFirst("Avatar").Value,
                };
                return Json(user);
            }
            return Json("");
        }

        public IActionResult GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var accountName = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (User.Identity.AuthenticationType == GoogleDefaults.AuthenticationScheme)
                {
                    accountName += "@google";
                }
                var account = _dbContext.Accounts.Where(a => a.AccountName == accountName)
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

        [Route("/signup-google")]
        public IActionResult SignUpWithGoogle()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = "/google-signup-callback"
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("/google-signup-callback")]
        public async Task<IActionResult> HandleGoogleResponseSignUp()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (result?.Principal is { Identity: { IsAuthenticated: true } } principal)
            {
                var identity = result.Principal.Identity as ClaimsIdentity;
                var accountName = principal.FindFirstValue(ClaimTypes.NameIdentifier) + "@google";
                var account = _dbContext.Accounts.Where(a => a.AccountName == accountName)
                                                 .Include(a => a.User).ThenInclude(a => a.Role)
                                                 .FirstOrDefault();
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, accountName));
                identity.AddClaim(new Claim(ClaimTypes.Role, account.User.Role.RoleName));
                identity.AddClaim(new Claim("UserId", account.UserId.ToString()));
                identity.AddClaim(new Claim("Username", account.User.UserName));
                identity.AddClaim(new Claim("Avatar", account.User.Avatar));
                await HttpContext.SignInAsync(result.Principal, result.Properties);
                var email = principal.FindFirst(ClaimTypes.Email)?.Value;
                if (_dbContext.Users.FirstOrDefault(x => x.Email == email) != null)
                {
                    TempData["log"] = "Tài khoản này đã được đăng ký";
                    return Redirect("/Error/Log");
                }
                var user = new UserEntity()
                {
                    UserName = principal.FindFirst(ClaimTypes.Name)?.Value,
                    Email = email,
                    Avatar = "/image/default.jpg",
                    CoverPhoto = "/image/bg_default.png",
                    RoleId = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = 0,
                    IsDeleted = false,
                };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                var acc = new AccountEntity()
                {
                    UserId = user.UserId,
                    AccountName = accountName,
                    Password = email.Split("@")[0],
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Status = 0,
                    IsDeleted = false,
                };
                _dbContext.Accounts.Add(acc);
                _dbContext.SaveChanges();
                return Redirect("/");
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["log"] = "Đăng ký thất bại";
            return Redirect("/Error/Log");
        }

        [HttpGet]
        [Route("/login-google")]
        public IActionResult LogInWithGoogle()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = "/google-login-callback"
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("/google-login-callback")]
        public async Task<IActionResult> HandleGoogleResponseLogIn()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (result?.Principal is { Identity: { IsAuthenticated: true } } principal)
            {
                var email = principal.FindFirst(ClaimTypes.Email)?.Value;
                if (_dbContext.Users.FirstOrDefault(x => x.Email == email) != null)
                {
                    var identity = result.Principal.Identity as ClaimsIdentity;
                    var accountName = principal.FindFirstValue(ClaimTypes.NameIdentifier) + "@google";
                    var account = _dbContext.Accounts.Where(a => a.AccountName == accountName)
                                                     .Include(a => a.User).ThenInclude(a => a.Role)
                                                     .FirstOrDefault();
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, accountName));
                    identity.AddClaim(new Claim(ClaimTypes.Role, account.User.Role.RoleName));
                    identity.AddClaim(new Claim("UserId", account.UserId.ToString()));
                    identity.AddClaim(new Claim("Username", account.User.UserName));
                    identity.AddClaim(new Claim("Avatar", account.User.Avatar));
                    await HttpContext.SignInAsync(result.Principal, result.Properties);
                    return Redirect("/");
                }
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                TempData["log"] = "Tài khoản này chưa đăng ký!";
                return Redirect("/Error/Log");
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["log"] = "Đăng nhập thất bại";
            return Redirect("/Error/Log");
        }
    }
}
