using Fusion.DataBase;
using Fusion.Interfaces;
using Fusion.Models;
using Fusion.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusion.DatabaseMethods
{
    public class DBUserMethods<T> : IUserRepository<T> where T : User
    {
        private readonly UserManager<User> _userManager;
        private readonly IdentityDBContext _appDBContext;
        public DBUserMethods(UserManager<User> userManager, IdentityDBContext appDBContext)
        {
            _userManager = userManager;
            _appDBContext = appDBContext;
        }
        public async Task Create(RegisterViewModel viewModel)
        {
            User user = new User { Email = viewModel.Email, UserName = viewModel.Name, Year = viewModel.Year, FutureJob = viewModel.FutureJob };
            await _userManager.CreateAsync(user, viewModel.Password);
        }
        public async Task Delete(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            await _userManager.DeleteAsync(user);
        }
        public async Task<T> Get(string email)
        {
            T currentUser = (T)await _userManager.FindByEmailAsync(email);
            T user = (T)await _appDBContext.Users.FindAsync(currentUser.Id); 
            return user;
        }
        public List<T> GetAll()
        {
            List<T> AllUser = new List<T>();
            foreach (T user in _userManager.Users)
            {
                AllUser.Add(user);
            }
            return AllUser;
        }
        public async Task Update(T updatingmodel)
        {
            T oldmodel = (T) await _userManager.FindByEmailAsync(updatingmodel.Email);
            oldmodel.FutureJob = updatingmodel.FutureJob;
            oldmodel.UserName = updatingmodel.UserName;
            oldmodel.Year = updatingmodel.Year;
            oldmodel.Description = updatingmodel.Description;
            oldmodel.Gradient = updatingmodel.Gradient;
            oldmodel.MainPicture = updatingmodel.MainPicture;
            await _userManager.UpdateAsync(oldmodel);
        }
        public async Task UpdatePassword(string email, string newpassword)
        {
            User user = await _userManager.FindByEmailAsync(email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, newpassword);
            await _userManager.UpdateAsync(user);
        }
    }
}
