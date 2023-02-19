using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Areas.Admin.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
