using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

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
            return View();
        }

        [Route("{id}/tu-truyen")]
        public IActionResult Bookshelf(int id)
        {
            return View();
        }

        [Route("{id}/truyen-da-dang")]
        public IActionResult BookUpload(int id)
        {
            return View();
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
