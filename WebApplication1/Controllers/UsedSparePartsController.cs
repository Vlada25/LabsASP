using Lab2.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    public class UsedSparePartsController : Controller
    {
        private readonly IUsedSparePartsService _usedSparePartsService;

        public UsedSparePartsController(IUsedSparePartsService usedSparePartsService)
        {
            _usedSparePartsService = usedSparePartsService;
        }

        [ResponseCache(Duration = 302)]
        public async Task<IActionResult> GetAll()
        {
            return View(await _usedSparePartsService.Get(50, "UsedSpareParts50"));
        }
    }
}
