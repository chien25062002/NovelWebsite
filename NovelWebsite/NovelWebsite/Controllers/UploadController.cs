using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Entities
{
    public class UploadController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UploadController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/dang-truyen/{id?}")]
        public IActionResult AddOrUpdateBook(int? id)
        {
            return View();
        }

        [Route("/dang-chuong/{id?}")]
        public IActionResult AddOrUpdateChapter(int? id)
        {
            return View();
        }
    }
}
