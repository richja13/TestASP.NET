using Microsoft.AspNetCore.Mvc;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
            var productList = new List<Product>
            {
                new Product
                {
                    Id=1,
                    Category = "Samochod",
                    Description = "To jest super samochod",
                    Name = "BMW M5"
                },

                new Product
                {
                    Id=2,
                    Category = "Napoje",
                    Description = "To opis napoju",
                    Name = "Cola"
                },

                new Product
                {
                    Id=3,
                    Category = "Gra",
                    Description = "To jest super gra",
                    Name = "Cyberpunk"
                },
            };

            return View(productList);
        }

        public IActionResult Data()
        {
            ViewBag.Name = "Jacek";

            return View();
        }

       
    }
}
