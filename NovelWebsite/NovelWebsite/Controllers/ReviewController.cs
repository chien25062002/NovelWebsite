using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using System.Data.Entity;

namespace NovelWebsite.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ReviewController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int categoryId = 0)
        {
            try
            {
                var reviews = _dbContext.Reviews.Include(r => r.Book)
                                                .Where(r => categoryId == 0 || r.Book.CategoryId == categoryId)
                                                .OrderByDescending(r => r.CreatedDate).ToList();
                return View(reviews);
            }
            catch (Exception ex)
            {
                return View();
            }
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
