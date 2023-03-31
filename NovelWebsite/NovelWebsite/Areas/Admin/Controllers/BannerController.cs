using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;

namespace NovelWebsite.Areas.Admin.Controllers
{
    public class BannerController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BannerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult ListBanners()
        {
            return View();
        }

        public IActionResult AddOrUpdateBanner()
        {
            return View();
        }
    }
}
