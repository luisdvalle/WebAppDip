using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeTestTafe.ViewModels
{
    public class CategoryCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
    }
}
