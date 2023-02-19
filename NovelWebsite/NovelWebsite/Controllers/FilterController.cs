using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace NovelWebsite.Controllers
{
    public class FilterController : Controller
    {
        private readonly AppDbContext _dbContext;

        public FilterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var query = _dbContext.Books.Where(b => b.IsDeleted == false)
                                        .Include(b => b.Author)
                                        .Include(b => b.BookStatus)
                                        .ToList();
            return View(query);
        }

        [HttpPost]
        public IActionResult Index(FilterModel filterModel)
        {
            var query = _dbContext.Books.Include(b => b.Author)
                                        .Include(b => b.BookStatus)
                                        .Where(b => b.IsDeleted == false)
                                        .Where(b => string.IsNullOrEmpty(b.CategoryId.ToString()) || b.CategoryId == filterModel.CategoryId)
                                        .Where(b => string.IsNullOrEmpty(b.BookStatusId) || b.BookStatusId == filterModel.BookStatusId);
            switch (filterModel.RankType)
            {
                case "Views":
                    query = query.OrderByDescending(b => b.Views);
                    break;
                case "Likes":
                    query = query.OrderByDescending(b => b.Likes);
                    break;
                case "Recommends":
                    query = query.OrderByDescending(b => b.Recommends);
                    break;
                default:
                    query = query.OrderByDescending(b => b.CreatedDate);
                    break;
            }
            switch (filterModel.ChapterRange)
            {
                case 299:
                    query = query.Where(b => b.NumberOfChapters < 300);
                    break;
                case 999:
                    query = query.Where(b => b.NumberOfChapters >= 300 && b.NumberOfChapters <= 1000);
                    break;
                case 1999:
                    query = query.Where(b => b.NumberOfChapters >= 1000 && b.NumberOfChapters <= 2000);
                    break;
                case 2999:
                    query = query.Where(b => b.NumberOfChapters > 2000);
                    break;
                default:
                    break;
            }
            var filterTags = _dbContext.BookTags.ToList();
            foreach (var tag in filterModel.ListTags)
            {
                filterTags = filterTags.Where(f => f.TagId == tag).ToList();
            }
            var grBooks = filterTags.GroupBy(f => f.BookId);
            var filterAll = from t in grBooks
                          join b in query on t.Key equals b.BookId
                          select b;
            switch (filterModel.OrderBy)
            {
                case "Updated":
                    filterAll = filterAll.OrderByDescending(f => f.UpdatedDate);
                    break;
                case "New":
                    filterAll = filterAll.OrderByDescending(f => f.CreatedDate);
                    break;
                case "Chapter":
                    filterAll = filterAll.OrderByDescending(f => f.NumberOfChapters);
                    break;
                default:
                    filterAll = filterAll.OrderByDescending(f => f.CreatedDate);
                    break;
            }
            return View(filterAll);
        }

        public IActionResult GetBookStatuses()
        {
            return Json(_dbContext.BookStatuses.ToList());
        }

        public IActionResult GetAllTags()
        {
            return Json(_dbContext.Tags.ToList());
        }

    }
}
