using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BookController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult ListOfBooks(string name, int pageNumber = 1)
        {
            int pageSize = 10;
            int pageTotal = _dbContext.Books.Count();
            int pageCount = (int)Math.Ceiling(1.0 * pageTotal / pageSize);
            int skip = pageNumber * pageSize - pageSize;
            var query = _dbContext.Books.Where(b => string.IsNullOrEmpty(name) || b.BookName.ToLower().Contains(name.ToLower()))
                                        .Where(b => b.IsDeleted == false)
                                        .Include(b => b.Author)
                                        .Include(b => b.Category)
                                        .Include(b => b.User)
                                        .Include(b => b.BookStatus)
                                        .OrderByDescending(b => b.CreatedDate)
                                        .ToList();
            return View(query);
        }
        
        public IActionResult AddOrUpdateBook(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            var query = _dbContext.Books.Where(b => b.BookId == id && b.IsDeleted == false)
                                         .Include(b => b.Author)
                                         .Include(b => b.Category)
                                         .Include(b => b.User)
                                         .Include(b => b.BookStatus)
                                         .First();
            if (query == null)
            {
                return NotFound();
            }
            return View(query);
        }

        public IActionResult DeleteBook(int bookId)
        {
            var book = _dbContext.Books.First(x => x.BookId == bookId);
            book.IsDeleted = true;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Book/ListOfBooks");
        }
    }
}
