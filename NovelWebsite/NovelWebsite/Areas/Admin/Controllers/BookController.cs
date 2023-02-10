using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
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
                                        .Skip(skip)
                                        .Take(pageSize)
                                        .ToList();
            return View(query);
        }
        
    }
}
