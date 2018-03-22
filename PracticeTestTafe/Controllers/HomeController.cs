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
    public class HomeController : Controller
    {
        private IDataService<Category> _categoryDataService;

        public HomeController(IDataService<Category> categoryDataService)
        {
            _categoryDataService = categoryDataService;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _categoryDataService.GetAll();

            HomeCategoryViewModel vm = new HomeCategoryViewModel
            {
                Total = categoryList.Count(),
                CategoryList = categoryList
            };

            return View(vm);
        }
    }
}