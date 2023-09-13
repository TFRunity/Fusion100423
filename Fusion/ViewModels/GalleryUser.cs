using Fusion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class GalleryUser
    {
        public GalleryUser(User user)
        {
            Email = user.Email;
            UsersPictures = user.UsersPictures;
            Name = user.UserName;
        }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<UsersPicture> UsersPictures { get; set; }
        //Передавать имейл конкретного пользователя через ViewBag
    }
}
