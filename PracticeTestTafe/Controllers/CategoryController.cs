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
    public class CategoryController : Controller
    {
        private IDataService<Category> _categoryDataService;
        private IDataService<Product> _productDataService;

        public CategoryController(
            IDataService<Category> categoryDataService,
            IDataService<Product> productDataService
            )
        {
            _categoryDataService = categoryDataService;
            _productDataService = productDataService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // check if name already exists
                Category existingCategory = _categoryDataService.GetSingle(c => c.Name == vm.Name);

                if (existingCategory == null)
                {
                    // map
                    Category category = new Category
                    {
                        Name = vm.Name,
                        Details = vm.Details
                    };

                    // call service
                    _categoryDataService.Add(category);

                    // Go to home/index
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "This name already exists");
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            TempData["catId"] = id.ToString();

            // Get category by Id
            Category category = _categoryDataService.GetSingle(c => c.CategoryId == id);
            // Get Products by Category Id
            IEnumerable<Product> products = _productDataService.Query(p => p.CategoryId == id);

            // vm
            CategoryDetailsViewModel vm = new CategoryDetailsViewModel
            {
                Id = category.CategoryId,
                Name = category.Name,
                Details = category.Details,
                Total = products.Count(),
                Products = products
            };

            return View(vm);
        }
    }
}