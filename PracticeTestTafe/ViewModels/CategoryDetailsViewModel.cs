using PracticeTestTafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeTestTafe.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Total { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
