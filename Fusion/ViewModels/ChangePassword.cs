using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class ChangePassword
    {
        public string Email { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Пароль должен содержать не менее 7 символов")]
        public string Password { get; set; }
    }
}
