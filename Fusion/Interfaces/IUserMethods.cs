using Fusion.Models;
using System.Collections.Generic;

namespace Fusion.Interfaces
{
    public interface IUserMethods
    {
        //Метод для получения пользователя
        public UserAtSite GetCurrentSiteUser(string name);
        public List<UserAtSite> GetAllSiteUsers();
        //Метод для изменения данных о пользователе
        
    }
}
