using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.Models
{
    public class ProductId
    {
        public Guid Id { get; set; }
        public Guid IdFromProduct { get; set; }
        public int PriceFromProduct { get; set; }
        //Count of Products
        public int CurrentCount { get; set; } = 1;
        public int PreviousCount { get; set; } = 1;
        public Guid? OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}
