using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BannerController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BannerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbContext.Banners.Include(b => b.Book).ToList();

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(_dbContext.Categories.Count() * 1.0 / pageSize);

            ViewBag.Books = new SelectList(_dbContext.Books.ToList(), "BookId", "BookName");

            return View(query.Skip(pageSize * pageNumber - pageSize)
                                             .Take(pageSize)
                                             .ToList());
        }

        public IActionResult AddOrUpdateBanner(int id)
        {
            var banner = _dbContext.Banners.FirstOrDefault(x => x.BannerId == id);
            if (banner == null)
            {
                return Json("");
            }
            return Json(banner);
        }

        [HttpPost]
        public IActionResult AddOrUpdateBanner(BannerEntity banner)
        {
            var cat = _dbContext.Banners.Where(c => c.BannerId == banner.BannerId).FirstOrDefault();
            if (cat == null)
            {
                _dbContext.Banners.Add(banner);
            }
            else
            {
                _dbContext.Banners.Update(banner);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Category/Index");
        }

        public IActionResult DeleteBanner(int id)
        {
            var banner = _dbContext.Banners.FirstOrDefault(x => x.BannerId == id);
            if (banner != null)
            {
                _dbContext.Banners.Remove(banner);
                _dbContext.SaveChanges();
            }
            return Redirect("/Admin/Banner/Index");
        }
    }
}
