using Fusion.Interfaces;
using Fusion.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Fusion.DatabaseMethods
{
    public class UsersMethods : IUserMethods
    {
        private readonly UserManager<User> _userManager;
        public UsersMethods(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public UserAtSite GetCurrentSiteUser(string name)
        {
            User user = _userManager.FindByNameAsync(name).GetAwaiter().GetResult();
            UserAtSite userAtSite = new UserAtSite(user);
            return userAtSite;
        }

        public List<UserAtSite> GetAllSiteUsers()
        {
            List<UserAtSite> users = new List<UserAtSite>();
            foreach(User user in _userManager.Users)
            {
                UserAtSite atSite = new UserAtSite(user);
                users.Add(atSite);
            }
            return users;
        }
    }
}
