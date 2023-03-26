using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Controllers
{
    public class CommentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CommentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(CommentModel comment)
        {
            var cmt = new CommentEntity()
            {
                ChapterId = comment.ChapterId,
                BookId = comment.BookId,
                UserId = comment.UserId,
                ReplyCommentId = comment.ReplyCommentId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _dbContext.Comments.Add(cmt);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteComment(int commentId)
        {
            var cmt = _dbContext.Comments.Where(c => c.ChapterId == commentId).FirstOrDefault();
            _dbContext.Comments.Remove(cmt);
            return NoContent();
        }
    }
}
