using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using System.Security.Claims;

namespace NovelWebsite.Controllers
{
    [Route("/ho-so")]
    [Route("/{controller}")]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [Route("{id}")]
        public IActionResult Profile(int id)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var account = _dbContext.Accounts.Where(a => a.AccountName == claims.FindFirst(ClaimTypes.NameIdentifier).Value)
                                                .Include(a => a.User)
                                                .FirstOrDefault();
            return View(account);
        }

        [Route("{id}/tu-truyen")]
        public IActionResult Bookshelf(int id)
        {
            var books = _dbContext.BookUsers.Where(x => x.UserId == id).ToList();
            var all = _dbContext.Books.Where(x => x.Status == 0 && x.IsDeleted == false).ToList();
            var bookshelf = new List<BookEntity>();
            foreach (var item in books)
            {
                bookshelf.Add(all.FirstOrDefault(x => x.BookId == item.BookId));
            }
            return View(bookshelf);
        }

        [Route("{id}/truyen-da-dang")]
        public IActionResult BookUpload(int id)
        {
            var books = _dbContext.Books.Where(x => x.UserId == id && x.IsDeleted == false).ToList();
            return View(books);
        }

        [Route("/{bookId}/danh-sach-chuong")]
        public IActionResult ListOfChapters(int bookId, int pageNumber = 1, int pageSize = 16)
        {
            var query = _dbContext.Chapters.Where(b => b.BookId == bookId && b.IsDeleted == false)
                                        .OrderBy(b => b.CreatedDate)
                                        .ToList();
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);

            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }
    }
}
