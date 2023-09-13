using Fusion.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Fusion.Models;
using System.Threading.Tasks;
using Fusion.ViewModels;
using System;

namespace Fusion.Controllers
{
    //Сделать вьюхи всем контроллерам, где это необходимо
    [Authorize(Policy = "Manager")]
    public class ModeratorController : Controller
    {
        private readonly IRepository<UsersPicture> _dBMethods;
        private readonly IUserRepository<User> _identityMethods;
        private readonly IUserMethods<UserAtSite> _userMethods;
        public ModeratorController(IRepository<UsersPicture> dBMethods, IUserRepository<User> identityMethods, IUserMethods<UserAtSite> userMethods)
        {
            _dBMethods = dBMethods;
            _identityMethods = identityMethods;
            _userMethods = userMethods;
        }
        [HttpGet]
        public IActionResult List()
        {
            List<UserAtSite> users = _userMethods.GetAll();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string email)
        {
            User user = await _identityMethods.Get(email);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditedUser(User editedUser)
        {
            await _identityMethods.Update(editedUser);
            return RedirectToAction(nameof(List));
        }
        //Реализовать как кнопку
        public async Task<IActionResult> Delete(string email)
        {
            await _identityMethods.Delete(email);
            return RedirectToAction(nameof(List));
        }
        //Картинки, не Async
        public async Task<IActionResult> UsersPictures(string email)
        {
            User user = await _identityMethods.Get(email);
            List<UsersPicture> usersPictures = user.UsersPictures;
            return View(usersPictures);
        }
        //
        public async Task<IActionResult> DeletePicture(Guid id)
        {
            await _dBMethods.Delete(id);
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public IActionResult AddPicture(string email)
        {
            AddPictureViewModel model = new AddPictureViewModel { Email = email };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPicture(AddPictureViewModel pictureViewModel)
        {
            UsersPicture picture = new UsersPicture {
                URL = pictureViewModel.Url,
                User = await _identityMethods.Get(pictureViewModel.Email)
            };
            await _dBMethods.Create(picture);
            return RedirectToAction(nameof(List));
        }
    }
}
