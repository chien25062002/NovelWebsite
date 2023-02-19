using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
