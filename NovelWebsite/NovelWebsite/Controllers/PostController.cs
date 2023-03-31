using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    [Route("/tin-tuc")]
    public class PostController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PostController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("")]
        public IActionResult ListOfPosts(int pageNumber = 1, int pageSize = 10)
        {
            var query = _dbContext.Tags;

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
         
            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .ToList());
        }

        [Route("{slug}-{id:int}")]
        public IActionResult Index(int id)
        {
            var post = _dbContext.Posts.Where(p => p.Status == 0 && p.IsDeleted == true && p.PostId == id).FirstOrDefault();
            return View(post);
        }
    }
}
