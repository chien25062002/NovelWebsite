using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using NovelWebsite.Models;

namespace NovelWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(_dbContext.Categories.ToList());
        }

        [HttpPost]
        public IActionResult AddOrUpdateCategory(CategoryModel category)
        {
            var cat = _dbContext.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
            if (cat == null)
            {
                _dbContext.Categories.Add(new CategoryEntity()
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryImage = category.CategoryImage,
                    Slug = StringExtension.Slugify(category.CategoryName),
                });
            }
            else
            {
                cat.CategoryName = category.CategoryName;
                cat.CategoryImage = category.CategoryImage;
                cat.Slug = StringExtension.Slugify(category.CategoryName);
            }
            _dbContext.SaveChanges();
            return Redirect("/Admin/Tag/Index");
        }

        public IActionResult AddOrUpdateCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return Json("");
            }
            return Json(category);
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
            return Redirect("/Admin/Category/Index");
        }
    }
}
