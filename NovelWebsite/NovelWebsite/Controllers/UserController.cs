using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Bookshelf(int id, int pageNumber = 1, int pageSize = 10)
        {
            var books = _dbContext.BookUsers.Where(x => x.UserId == id).ToList();
            var all = _dbContext.Books.Where(x => x.Status == 0 && x.IsDeleted == false).Include(b => b.Author).ToList();
            var bookshelf = new List<BookEntity>();
            foreach (var item in books)
            {
                bookshelf.Add(all.FirstOrDefault(x => x.BookId == item.BookId));
            }

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(bookshelf.Count() * 1.0 / pageSize);

            return View(bookshelf.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [Route("{id}/truyen-da-dang")]
        public IActionResult BookUpload(int id, int pageNumber = 1, int pageSize = 10)
        {
            var books = _dbContext.Books.Where(x => x.UserId == id && x.IsDeleted == false)
                                        .Include(b => b.Author)
                                        .Include(b => b.BookStatus)
                                        .Include(b => b.User)
                                        .ToList();

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(books.Count() * 1.0 / pageSize);

            return View(books.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [Authorize(Policy = "BookOwner")]
        [Route("/dang-tai/{userId}/truyen/{bookId}/danh-sach-chuong")]
        public IActionResult ListOfChapters(int bookId, int pageNumber = 1, int pageSize = 16)
        {
            var query = _dbContext.Chapters.Where(b => b.BookId == bookId && b.IsDeleted == false)
                                        .OrderBy(b => b.CreatedDate)
                                        .ToList();
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            ViewBag.userId = Int32.Parse(claims.FindFirst("UserId").Value);

            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }
    }
}
