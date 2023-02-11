using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Controllers
{
    public class FilterController : Controller
    {
        private readonly AppDbContext _dbContext;

        public FilterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FilterModel filterModel)
        {
            return View();
        }

        public IActionResult GetBookStatuses()
        {
            return Json(_dbContext.BookStatuses.ToList());
        }

        public IActionResult GetAllTags()
        {
            return Json(_dbContext.Tags.ToList());
        }
    }
}
