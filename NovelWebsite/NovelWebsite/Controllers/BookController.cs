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
        public IActionResult Index(int id)
        {
            var book = _dbContext.Books.Find(id);
            return View(book);
        }

        public IActionResult GetListChapters(int id)
        {
            var listChapters = _dbContext.Chapters.Where(c => c.Book.BookId == id).OrderBy(c => c.CreatedDate).ToList();
            return Json(listChapters);
        }

        public IActionResult GetListReviews(int id)
        {
            var listReviews = _dbContext.Reviews.Where(r => r.Book.BookId == id).OrderByDescending(r => r.CreatedDate).ToList();
            return Json(listReviews);
        }

        public IActionResult GetListComments(int id)
        {
            var listComment = _dbContext.Comments.Where(c => c.Book.BookId == id).OrderByDescending(c => c.CreatedDate).ToList();
            return Json(listComment);
        }

        public IActionResult GetAuthorBooks(int id, int number = 10)
        {
            var listAuthorBooks = _dbContext.Books.Where(b => b.Author.AuthorId == id).OrderByDescending(b => b.CreatedDate).Take(number).ToList();
            return Json(listAuthorBooks);
        }

        public IActionResult GetUserInfo(int id)
        {
            var user = _dbContext.Users.Find(id);
            return Json(user);
        }

        public IActionResult BooksMaybeYouLike(int id, int number = 6)
        {
            var listBooks = _dbContext.Books.Where(b => b.Category.CategoryId == id).OrderByDescending(b => b.CreatedDate).Take(number).ToList();
            return Json(listBooks);
        }
    }
}
