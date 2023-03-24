using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private readonly AppDbContext _dbContext;

        public TagController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var query = _dbContext.Tags.ToList();
            return View(query);
        }

        [HttpPost]
        public IActionResult AddOrUpdateTag(TagModel tag)
        {
            var t = _dbContext.Tags.Where(t => t.TagId == tag.TagId).FirstOrDefault();
            if (t == null)
            {
                _dbContext.Tags.Add(new TagEntity()
                {
                    TagId = tag.TagId,
                    TagName = tag.TagName,
                    Slug = StringExtension.Slugify(tag.TagName),
                });
            }
            else
            {
                t.TagName = tag.TagName;
                t.Slug = StringExtension.Slugify(tag.TagName);
                _dbContext.Tags.Update(t);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Tag/Index");
        }

        public IActionResult AddOrUpdateTag(int id)
        {
            var tag = _dbContext.Tags.Where(t => t.TagId == id).FirstOrDefault();
            if (tag == null)
            {
                return Json("");
            }
            return Json(tag);
        }

        [HttpDelete]
        public IActionResult DeleteTag(int id)
        {
            var tag = _dbContext.Tags.Where(t => t.TagId == id).FirstOrDefault();
            if (tag != null)
            {
                _dbContext.Tags.Remove(tag);
                _dbContext.SaveChanges();
            }
            return Redirect("/Admin/Tag/Index");
        }
    }
}
