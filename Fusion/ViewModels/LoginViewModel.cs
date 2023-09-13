using System.ComponentModel.DataAnnotations;

namespace Fusion.ViewModels
{
    public class LoginViewModel
    {
        public string Name { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Пароль должен содержать не менее 7 символов (A-Z)&&(0-9)&&(a-z)")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
