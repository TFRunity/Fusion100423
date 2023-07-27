using System.ComponentModel.DataAnnotations;

namespace Fusion.ViewModels
{
    public class AddPictureViewModel
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
