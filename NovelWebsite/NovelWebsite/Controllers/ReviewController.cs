using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ReviewController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
