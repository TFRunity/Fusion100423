using System;
using System.Collections.Generic;

namespace Fusion.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public virtual IList<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public virtual ProductSubCategory ProductSubCategories { get; set; }
    }
}
