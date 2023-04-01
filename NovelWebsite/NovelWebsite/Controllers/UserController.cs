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
        public IActionResult BookShelf(int id)
        {
            return View();
        }
    }
}
