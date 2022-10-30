using Lab2.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.ASP.Controllers
{
    public class FaultsController : Controller
    {
        private readonly IFaultsService _faultsService;

        public FaultsController(IFaultsService faultsService)
        {
            _faultsService = faultsService;
        }

        [ResponseCache(Duration = 302)]
        public async Task<IActionResult> GetAll()
        {
            return View(await _faultsService.Get(50, "Faults50"));
        }
    }
}
