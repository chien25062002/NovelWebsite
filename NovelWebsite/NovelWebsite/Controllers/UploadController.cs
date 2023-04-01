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

        [Route("/dang-truyen")]
        public IActionResult AddOrUpdateBook()
        {
            return View();
        }

        [Route("/{id}/dang-chuong")]
        public IActionResult AddOrUpdateChapter(int id)
        {
            return View();
        }
    }
}
