using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
