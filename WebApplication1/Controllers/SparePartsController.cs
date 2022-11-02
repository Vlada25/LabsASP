using Lab2.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    public class SparePartsController : Controller
    {
        private readonly ISparePartsService _sparePartsService;

        public SparePartsController(ISparePartsService sparePartsService)
        {
            _sparePartsService = sparePartsService;
        }

        [ResponseCache(Duration = 302)]
        public async Task<IActionResult> GetAll()
        {
            return View(await _sparePartsService.Get(50, "SpareParts50"));
        }
    }
}
