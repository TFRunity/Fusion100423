using System;
using System.Collections.Generic;

namespace Fusion.Models
{
    public class Category
    {
        // PK
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Fullname { get; set; } //Для названий на русском
        // n : n
        public virtual IList<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
