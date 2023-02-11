using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    public class ChapterController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ChapterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int id)
        {
            var chapter = _dbContext.Chapters.Find(id);
            return View(chapter);
        }

        public IActionResult GetListComments(int id)
        {
            var listComments = _dbContext.Comments.Where(c => c.Chapter.ChapterId == id).ToList();
            return View(listComments);
        }
    }
}
