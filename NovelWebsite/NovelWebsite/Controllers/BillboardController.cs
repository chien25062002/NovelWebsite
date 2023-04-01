using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;

namespace NovelWebsite.Controllers
{
    [Route("/bang-xep-hang")]
    [Route("/{controller}")]
    public class BillboardController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BillboardController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("")]
        public IActionResult Index(string? sort_by, string? order, int category_id = 0, int pageNumber = 1, int pageSize = 20)
        {
            var query = _dbContext.Books.Where(b => b.Status == 0 && b.IsDeleted == false)
                                        .Where(b => category_id == 0 || b.CategoryId == category_id)
                                        .Include(b => b.Author)
                                        .Include(b => b.Category)
                                        .OrderByDescending(b => b.CreatedDate);
            if (!string.IsNullOrEmpty(order))
            {
                if (order == "up")
                {
                    query = query.OrderBy(b => b.CreatedDate);
                }
            }

            if (!string.IsNullOrEmpty(sort_by))
            {
                switch (sort_by)
                {
                    case "view":
                        query.OrderByDescending(b => b.Views);
                        break;
                    case "like":
                        query.OrderByDescending(b => b.Likes);
                        break;
                    case "follow":
                        
                        break;
                    case "recommend":
                        query.OrderByDescending(b => b.Recommends);
                        break;
                }
            }

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            ViewBag.categoryId = category_id;
            ViewBag.sortBy = sort_by;
            ViewBag.order = order;

            return View(query.Skip(pageSize * pageNumber - pageSize).Take(pageSize).ToList());
        }

    }
}
