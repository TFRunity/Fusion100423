using System;
using System.Collections.Generic;

namespace Fusion.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Done { get; set; } = DateTime.Now;
        public bool Paid { get; set; } = false;
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<ProductId> ProductIds { get; set; } = new List<ProductId>();
    }
}
