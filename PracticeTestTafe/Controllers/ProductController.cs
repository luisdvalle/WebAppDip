using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeTestTafe.Models;
using PracticeTestTafe.Services;
using PracticeTestTafe.ViewModels;

namespace PracticeTestTafe.Controllers
{
    public class ProductController : Controller
    {
        private IDataService<Product> _productDataService;

        public ProductController(IDataService<Product> productDataService)
        {
            _productDataService = productDataService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateViewModel vm)
        {
            // Get categoryId
            int catId = int.Parse(TempData["catId"].ToString());

            Product product = new Product
            {
                Name = vm.Name,
                Details = vm.Details,
                Price = vm.Price,
                CategoryId = catId
            };

            _productDataService.Add(product);

            return RedirectToAction("Details", "Category", new { Id = catId });
        }
    }
}