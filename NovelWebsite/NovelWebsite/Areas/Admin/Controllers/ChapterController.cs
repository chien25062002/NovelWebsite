using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChapterController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ChapterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult ListOfChapters(int bookId, string name, int pageNumber = 1)
        {
            var query = _dbContext.Chapters.Where(c => c.BookId == bookId && c.IsDeleted == false)
                                        .Where(c => string.IsNullOrEmpty(name) || c.ChapterName.ToLower().Contains(name.ToLower()))
                                        .ToList();
            return View(query);
        }

        public IActionResult AddOrUpdateChapter(int chapterId)
        {
            var chapter = _dbContext.Chapters.First(c => c.ChapterId == chapterId);
            return View(chapter);
        }

        [HttpPost]
        public IActionResult AddOrUpdateChapter(ChapterModel chapterModel)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Admin/Chapter/ListOfChapter?bookId=" + chapterModel.BookId);
            }
            var chapter = _dbContext.Chapters.FirstOrDefault(c => c.ChapterId == chapterModel.ChapterId && c.IsDeleted == false);
            if (chapter == null)
            {
                chapter = new ChapterEntity()
                {
                    ChapterName = chapterModel.ChapterName,
                    Content = chapterModel.Content,
                    Views = 0,
                    Likes = 0,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                _dbContext.Chapters.Add(chapter);
            }
            else
            {
                chapter.ChapterName = chapterModel.ChapterName;
                chapter.Content = chapterModel.Content;
                chapter.UpdatedDate = DateTime.Now;
                _dbContext.Chapters.Update(chapter);
            }
            _dbContext.SaveChanges();
            return AddOrUpdateChapter(chapter.ChapterId);
        }

        public IActionResult DeleteChapter(int chapterId)
        {
            var chapter = _dbContext.Chapters.First(c => c.ChapterId == chapterId);
            chapter.IsDeleted = true;
            _dbContext.Chapters.Update(chapter);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Chapter/ListOfChapters?bookId=" + chapter.BookId);
        }
    }
}
