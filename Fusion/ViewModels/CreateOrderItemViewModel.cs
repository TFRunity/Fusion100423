using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class CreateOrderItemViewModel
    {
        public Guid _ProductId { get; set; }
        public string Email { get; set; }
        public Guid SubCategoryId { get; set; }
        public string _Case { get; set; }
    }
}
