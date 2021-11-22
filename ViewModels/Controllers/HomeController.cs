using Microsoft.AspNetCore.Mvc;

namespace ViewModels.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}