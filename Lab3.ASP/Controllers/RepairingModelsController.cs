using Lab2.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.ASP.Controllers
{
    public class RepairingModelsController : Controller
    {
        private readonly IRepairingModelsService _repairingModelsService;

        public RepairingModelsController(IRepairingModelsService repairingModelsService)
        {
            _repairingModelsService = repairingModelsService;
        }

        [ResponseCache(Duration = 302)]
        public async Task<IActionResult> GetAll()
        {
            return View(await _repairingModelsService.Get(50, "RepairingModels50"));
        }
    }
}
