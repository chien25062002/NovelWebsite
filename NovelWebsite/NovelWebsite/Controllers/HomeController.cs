using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;

namespace NovelWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllCategories()
        {
            var query = _dbContext.Categories.ToList();
            return Json(query);
        }

        public IActionResult GetPosts(int number = 10)
        {
            return Json(_dbContext.Posts.OrderByDescending(p => p.UpdatedDate).Take(number).ToList());
        }

        public IActionResult GetChapterUpdated(int number = 10)
        {
            var query = _dbContext.Chapters.OrderByDescending(p => p.UpdatedDate).Include(b => b.Book);
            List<ChapterEntity> listChapters = new List<ChapterEntity>();
            foreach (var chapter in query)
            {
                if (listChapters.FirstOrDefault(c => c.Book.BookId == chapter.Book.BookId) != null)
                {
                    listChapters.Add(chapter);
                }
                if (listChapters.Count == number)
                {
                    break;
                }
            }
            return Json(listChapters);
        }

        public IActionResult GetMostRecommends(int number = 10)
        {
            return Json(_dbContext.Books.OrderByDescending(b => b.Recommends).Take(number).ToList());
        }

        public IActionResult GetMostViews(int number = 10)
        {
            return Json(_dbContext.Books.OrderByDescending(b => b.Views).Take(number).ToList());
        }

        public IActionResult GetMostLikes(int number = 10)
        {
            return Json(_dbContext.Books.OrderByDescending(b => b.Likes).Take(number).ToList());
        }

        public IActionResult GetMostFollows(int number = 10)
        {
            var grBook = _dbContext.BookUsers.GroupBy(b => b.Book.BookId);
            var query = grBook.Select(g => new
            {
                BookId = g.Key,
                UserFollow = g.Count()
            }).OrderByDescending(g => g.UserFollow).Take(number);
            List<BookEntity> listBooks = new List<BookEntity>();
            foreach (var item in query)
            {
                listBooks.Add(_dbContext.Books.Find(item.BookId));
            }
            return Json(listBooks);
        }

        public IActionResult GetNewBooks(int number = 10)
        {
            return Json(_dbContext.Books.OrderByDescending(b => b.CreatedDate)
                                        .Include(b => b.BookStatus)
                                        .Include(b => b.Category)
                                        .Include(b => b.Author).Take(number).ToList());
        }

        public IActionResult GetFinishedBooks(int number = 10)
        {
            return Json(_dbContext.Books.Where(b => b.BookStatusId == "HOANTHANH")
                                        .OrderByDescending(b => b.CreatedDate)
                                        .Include(b => b.BookStatus)
                                        .Include(b => b.Category)
                                        .Include(b => b.Author)
                                        .Take(number).ToList());
        }
    }
}