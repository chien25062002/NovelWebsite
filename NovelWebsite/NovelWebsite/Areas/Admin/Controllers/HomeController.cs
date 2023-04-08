using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using System.Linq;

namespace NovelWebsite.Areas.Controllers
{
    [Area("Admin")]
    [Authorize (Roles = "Admin, Biên tập viên")]
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
            ViewBag.NumberOfBooks = _dbContext.Books.Count();
            ViewBag.NumberOfFinishedBooks = _dbContext.Books.Count(x => x.BookStatusId == "HOANTHANH");
            ViewBag.NumberOfChapters = _dbContext.Chapters.Count();
            ViewBag.NumberOfComments = _dbContext.Comments.Count();
            ViewBag.NumberOfReviews = _dbContext.Reviews.Count();
            return View();
        }
    }
}
