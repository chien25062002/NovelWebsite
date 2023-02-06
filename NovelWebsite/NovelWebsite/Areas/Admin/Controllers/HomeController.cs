using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using System.Linq;

namespace NovelWebsite.Areas.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.NumberOfUsers = _dbContext.Users.Count();
            ViewBag.NumberOfAcceptedBooks = _dbContext.Books.Count(x => x.Status == 1);
            ViewBag.NumberOfBooks = _dbContext.Books.Count();
            ViewBag.NumberOfChapters = _dbContext.Chapters.Count(x => x.Status == 1);
            ViewBag.NumberOfComments = _dbContext.Comments.Count();
            // views lấy từ session
            ViewBag.Views = 123456789;
            return View();
        }
    }
}
