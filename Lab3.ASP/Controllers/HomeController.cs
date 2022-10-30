using Microsoft.AspNetCore.Mvc;

namespace Lab3.ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
