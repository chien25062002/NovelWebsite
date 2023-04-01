using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;

namespace NovelWebsite.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ReviewController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(string? sort_by, int categoryId = 0, int pageNumber = 1, int pageSize = 8)
        {
            var reviews = _dbContext.Reviews.Where(r => categoryId == 0 || r.Book.CategoryId == categoryId)
                                            .Include(b => b.User)
                                            .Include(r => r.Book).ThenInclude(b => b.Author)
                                            .OrderByDescending(r => r.CreatedDate);
            if (sort_by != null)
            {
                if (sort_by == "up")
                {
                    reviews = reviews.OrderBy(r => r.CreatedDate);
                }
            }

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(reviews.Count() * 1.0 / pageSize);
            ViewBag.categoryId = categoryId;
            ViewBag.sortBy = sort_by;
            return View(reviews.Skip(pageSize * pageNumber - pageSize).Take(pageSize).ToList());            
        }

        [HttpPost]
        public IActionResult AddReview(ReviewModel review)
        {
            var rv = new ReviewEntity()
            {
                BookId = review.BookId,
                UserId = review.UserId,
                Content = StringExtension.HtmlEncode(review.Content),
                Likes = 0,
                Dislikes = 0,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = 0,
                IsDeleted = false
            };
            _dbContext.Reviews.Add(rv);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
