using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    
    [Route("/truyen")]
    [Route("/{controller}")]
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
        [Route("{action}")]
        public IActionResult GetAllCategories()
        {
            var query = _dbContext.Categories.ToList();
            return Json(query);
        }
        [Route("{action}")]
        public IActionResult GetListComments(int id)
        {
            var listComment = _dbContext.Comments.Where(c => c.Chapter.ChapterId == id).Include("User").OrderByDescending(c => c.CreatedDate).ToList();
            return Json(listComment);
        }

        [Route("{action}")]
        public IActionResult GetListChapters(int id)
        {
            var listChapters = _dbContext.Chapters.Where(c => c.ChapterId == id).OrderBy(c => c.CreatedDate).ToList();
            return Json(listChapters);
        }

    }
}
