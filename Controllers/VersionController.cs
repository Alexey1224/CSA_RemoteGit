using Microsoft.AspNetCore.Mvc;

namespace CSA.Controllers
{
    public class VersionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
