using System.ComponentModel.DataAnnotations;

namespace Fusion.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
