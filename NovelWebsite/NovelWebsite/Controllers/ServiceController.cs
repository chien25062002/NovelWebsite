using Microsoft.AspNetCore.Mvc;

namespace NovelWebsite.Controllers
{
    public class ServiceController : Controller
    {
        IHostApplicationLifetime _lifeTime;
        public ServiceController(IHostApplicationLifetime lifeTime)
        {
            _lifeTime = lifeTime;
        }
        public IActionResult CloseProgram()
        {
            _lifeTime.StopApplication();
            return Json("success");
        }
    }
}
