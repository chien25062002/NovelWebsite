using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
