using Microsoft.AspNetCore.Mvc;
using TestWebApp.Models;
using TestWebApp.Services;
using TestWebApp.Services.Interfaces;

namespace TestWebApp.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;    
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product body)
        {
            if (!ModelState.IsValid) return View(body);

            var id = _warehouseService.Save(body);

            TempData["ProductId"] = id;

            return RedirectToAction("Add");
        }
    }
}
