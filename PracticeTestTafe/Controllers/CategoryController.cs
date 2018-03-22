using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticeTestTafe.Models;
using PracticeTestTafe.Services;

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
    }
}