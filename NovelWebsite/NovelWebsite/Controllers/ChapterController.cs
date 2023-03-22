using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    [Route("/{controller}")]
    [Route("/truyen")]
    public class ChapterController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ChapterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("{slug}-{id:int}/chuong-{chapterNumber:int}-{chapterSlug}-{chapterId:int}")]
        public IActionResult Index(int chapterId)
        {
            var chapter = _dbContext.Chapters.Where(c => c.ChapterId == chapterId)
                                             .Include(c => c.Book)
                                             .ThenInclude(b => b.Author)
                                             .FirstOrDefault();
            return View(chapter);
        }
    }
}
