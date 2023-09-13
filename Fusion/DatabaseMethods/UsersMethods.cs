using Fusion.Interfaces;
using Fusion.Models;
using Fusion.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusion.DatabaseMethods
{
    public class UsersMethods<T> : IUserMethods<T> where T : UserAtSite
    {
        private readonly UserManager<User> _userManager;
        public UsersMethods(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<T> GetCurrent(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            UserAtSite userAtSite = new UserAtSite(user);
            return (T)userAtSite;
        }

        public List<T> GetAll()
        {
            List<T> users = new List<T>();
            foreach(User user in _userManager.Users)
            {
                UserAtSite userAtSite = new UserAtSite(user);
                T _user = (T)userAtSite;
                users.Add(_user);
            }
            return users;
        }
    }
}
