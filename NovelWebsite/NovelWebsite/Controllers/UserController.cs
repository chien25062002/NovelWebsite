using Microsoft.AspNetCore.Mvc;
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
        public IActionResult ListOfChapters(int bookId)
        {
            return View();
        }
    }
}
