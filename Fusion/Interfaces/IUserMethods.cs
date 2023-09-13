using Fusion.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusion.Interfaces
{
    public interface IUserMethods<T> where T : class
    {
        //Метод для получения пользователя
        public Task<T> GetCurrent(string email);
        public List<T> GetAll();
        
    }
}
