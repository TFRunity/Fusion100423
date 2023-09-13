using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.Models
{
    public class ProductSubCategory
    {
        public Guid Id { get; set; }
        //Поля для первого
        public int FirstPrice { get; set; }
        public string FirstFeature { get; set; }
        public string FirstUrl { get; set; }
        //Поля для второго
        public int SecondPrice { get; set; }
        public string SecondFeature { get; set; }
        public string SecondUrl { get; set; }
        //Поля для третьего
        public int ThirdPrice { get; set; }
        public string ThirdFeature { get; set; }
        public string ThirdUrl { get; set; }
        //Поле для навигации
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
