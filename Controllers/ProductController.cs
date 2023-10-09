using Microsoft.AspNetCore.Mvc;
using TestWebApp.Models;
using TestWebApp.Services.Interfaces;

namespace TestWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IWarehouseService _warehouseService;

        public ProductController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }


        public IActionResult Product()
        {
            var product = new Product
            {
                Id = 1,
                Category = "Samochod",
                Description = "To jest super samochod",
                Name = "BMW M5",
            };

            return View(product);

        }

        public IActionResult List()
        {
            var productList = _warehouseService.GetAll();
            return View(productList);
        }

        public IActionResult Data()
        {
            ViewBag.Name = "Jacek";

            return View();
        }

       
    }
}
