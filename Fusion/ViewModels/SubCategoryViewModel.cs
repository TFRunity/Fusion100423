using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class SubCategoryViewModel
    {
        public Guid ProductId { get; set; }
        public Guid ProductSubCategoryId { get; set; }
        [Required]
        public string Feature { get; set; }
        public int Price { get; set; }
        public string Url { get; set; }
        public string _Case { get; set; }
    }
}
