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
        //Count of Products
        public int Count { get; set; }
        public Guid? OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}
