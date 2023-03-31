using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index(string? name, int pageNumber = 1, int pageSize = 5)
        {
            var query = _dbContext.Posts.Where(p => p.IsDeleted == false)
                                        .Where(p => string.IsNullOrEmpty(name) || p.Title.ToLower().Trim().Contains(name.ToLower().Trim()))
                                        .Include(p => p.User);

            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.pageCount = Math.Ceiling(query.Count() * 1.0 / pageSize);
            ViewBag.searchName = name;

            return View(query.Skip(pageSize * pageNumber - pageSize)
                         .Take(pageSize)
                         .OrderByDescending(p => p.CreatedDate)
                         .ToList());
        }

        [HttpGet]
        public IActionResult AddOrUpdatePost(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(x => x.PostId == id && x.IsDeleted == false);
            return View(post);
        }

        [HttpPost]
        public IActionResult AddOrUpdatePost(PostModel postModel)
        {
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
            return Redirect($"/Admin/Post/Index");
        }

        public IActionResult DeletePost(int id)
        {
            var post = _dbContext.Posts.First(p => p.PostId == id);
            post.IsDeleted = true;
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
            return Redirect("/Admin/Post/Index");
        }
    }
}
