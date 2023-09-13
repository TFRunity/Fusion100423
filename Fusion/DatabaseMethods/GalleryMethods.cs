using Fusion.Interfaces;
using Fusion.Models;
using Fusion.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusion.DatabaseMethods
{
    public class GalleryMethods<T> : IUserMethods<T> where T : GalleryUser
    {
        private readonly UserManager<User> _userManager;
        public GalleryMethods(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<T> GetCurrent(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            GalleryUser userAtSite = new GalleryUser(user);
            return (T)userAtSite;
        }

        public List<T> GetAll()
        {
            List<T> users = new List<T>();
            foreach (User user in _userManager.Users)
            {
                GalleryUser userAtSite = new GalleryUser(user);
                T _user = (T)userAtSite;
                users.Add(_user);
            }
            return users;
        }
    }
}
