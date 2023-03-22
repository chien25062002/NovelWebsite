using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{   
    [Route("/truyen")]
    [Route("/{controller}")]
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("{slug}-{id:int}")]
        public IActionResult Index(int id)
        {
            var book = _dbContext.Books.Where(b => b.BookId == id)
                                       .Include("Author")
                                       .Include("BookStatus")
                                       .Include("User")
                                       .Include("Category")
                                       .FirstOrDefault();
            if (book == null)
            {
                return View();
            }
            return View(book);
        }

        [Route("{action}")]
        public IActionResult GetListChapters(int id)
        {
            var listChapters = _dbContext.Chapters.Where(c => c.Book.BookId == id).OrderBy(c => c.CreatedDate).ToList();
            return Json(listChapters);
        }

        [Route("{action}")]
        public IActionResult GetListReviews(int id)
        {
            var listReviews = _dbContext.Reviews.Where(r => r.Book.BookId == id).OrderByDescending(r => r.CreatedDate).ToList();
            return Json(listReviews);
        }

        [Route("{action}")]
        public IActionResult GetListComments(int id)
        {
            var listComment = _dbContext.Comments.Where(c => c.Book.BookId == id).Include("Users").OrderByDescending(c => c.CreatedDate).ToList();
            return Json(listComment);
        }

        [Route("{action}")]
        public IActionResult GetAuthorBooks(int id, int number = 6)
        {
            var listAuthorBooks = _dbContext.Books.Where(b => b.Author.AuthorId == id).OrderByDescending(b => b.CreatedDate).Take(number).ToList();
            return Json(listAuthorBooks);
        }

        [Route("{action}")]
        public IActionResult GetUserBooks(int id, int number = 6)
        {
            var user = _dbContext.Books.Where(b => b.UserId == id).OrderByDescending(b => b.CreatedDate).Take(number).ToList();
            return Json(user);
        }

        [Route("{action}")]
        public IActionResult BooksMaybeYouLike(int id, int number = 6)
        {
            var listBooks = _dbContext.Books.Where(b => b.Category.CategoryId == id).Include("Author").OrderByDescending(b => b.CreatedDate).Take(number).ToList();
            return Json(listBooks);
        }
    }
}
