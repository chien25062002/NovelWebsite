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
        public IActionResult Index(int chapterId)
        {
            var chapter = _dbContext.Chapters.Find(chapterId);
            return View(chapter);
        }

        public IActionResult GetAllChapters(int bookId)
        {
            var listChapters = _dbContext.Chapters.Where(c => c.BookId == bookId && c.IsDeleted == false);
            return View(listChapters);
        }

        public IActionResult GetListComments(int chapterId)
        {
            var listComments = _dbContext.Comments.Where(c => c.Chapter.ChapterId == chapterId).ToList();
            return View(listComments);
        }
    }
}
