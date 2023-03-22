using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    [Route("/{controller}")]
    [Route("/truyen")]
    public class ChapterController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public ChapterController(AppDbContext dbContext, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _cache = cache;
        }

        public int UpdateViewCount(int id, int views)
        {
            var str = "chapter-" + id.ToString();
            if (_cache.TryGetValue("cache_keys", out List<string> cachedList))
            {
                cachedList.Add(str);
                _cache.Set("cache_keys", cachedList, TimeSpan.FromMinutes(30));
            }
            else
            {
                var list = new List<String>();
                list.Add(str);
                _cache.Set("cache_keys", list, TimeSpan.FromMinutes(30));
            }
            var currentViewCount = _cache.Get<int>(str);
            if (currentViewCount == 0)
            {
                _cache.Set(str, views);
                currentViewCount = views;
            }
            _cache.Set(str, currentViewCount + 1);
            return currentViewCount + 1;
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
