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

        public CategoryController(IDataService<Category> categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }

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
    }
}