using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    public class BillboardController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BillboardController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(string sort_by, int category_id = 0, int pageNumber = 1, int pageSize = 20)
        {
            var query = _dbContext.Books.Where(b => b.Status == 0 && b.IsDeleted == false)
                                        .Where(b => category_id == 0 || b.CategoryId == category_id)
                                        .Include(b => b.Author)
                                        .Include(b => b.Category)
                                        .Skip(pageSize * pageNumber - pageSize)
                                        .Take(pageNumber);
            if (!string.IsNullOrEmpty(sort_by))
            {
                switch (sort_by)
                {
                    case "views":
                        break;
                    case "likes":
                        break;
                }
            }
            return View(query);
        }

    }
}
