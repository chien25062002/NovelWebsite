using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    public class ChapterController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ChapterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
