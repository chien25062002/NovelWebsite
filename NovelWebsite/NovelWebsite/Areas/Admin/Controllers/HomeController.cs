using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
