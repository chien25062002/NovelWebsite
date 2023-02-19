using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PostController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddOrUpdatePost(int postId)
        {
            var post = _dbContext.Posts.FirstOrDefault(x => x.PostId == postId);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        public IActionResult AddOrUpdatePost(PostModel postModel)
        {
            if (!ModelState.IsValid)
            {
                return Redirect($"/Admin/Post/AddOrUpdate?postId={postModel.PostId}");
            }
            var post = _dbContext.Posts.FirstOrDefault(p => p.PostId == postModel.PostId);
            if (post == null)
            {
                post = new PostEntity()
                {
                    Title = postModel.Title,
                    Description = postModel.Description,
                    Content = postModel.Content,
                    Views = 0,
                    Likes = 0,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                _dbContext.Posts.Add(post);
            }
            else
            {
                post.Title = postModel.Title;
                post.Description = postModel.Description;
                post.Content = postModel.Content;
                post.UpdatedDate = DateTime.Now;
                _dbContext.Posts.Update(post);
            }
            _dbContext.SaveChanges();
            return Redirect($"/Admin/Post/AddOrUpdate?postId={postModel.PostId}");
        }

        public IActionResult DeletePost(int postId)
        {
            var post = _dbContext.Posts.First(p => p.PostId == postId);
            post.IsDeleted = true;
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Post/Index");
        }
    }
}
