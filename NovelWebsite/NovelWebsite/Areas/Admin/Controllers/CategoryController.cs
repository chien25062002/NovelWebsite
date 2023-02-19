using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
