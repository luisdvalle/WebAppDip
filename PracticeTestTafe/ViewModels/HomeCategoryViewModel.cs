using PracticeTestTafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeTestTafe.ViewModels
{
    public class HomeCategoryViewModel
    {
        public int Total { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
    }
}
