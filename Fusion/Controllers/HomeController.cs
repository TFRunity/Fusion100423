using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Fusion.Models;
using Fusion.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System;
using Fusion.ViewModels;

namespace Fusion.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ICategoryMethods<Category> _categoryMethods;
        private readonly UserManager<User> _userManager;
        private readonly IUserMethods<UserAtSite> _userMethods;
        private readonly IUserMethods<GalleryUser> _galleryMethods;

        public HomeController(UserManager<User> userManager, IUserMethods<UserAtSite> userMethods, ICategoryMethods<Category> categoryMethods, IUserMethods<GalleryUser> galleryMethods)
        {
            _userMethods = userMethods;
            _categoryMethods = categoryMethods;
            _userManager = userManager;
            _galleryMethods = galleryMethods;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                User _user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (_user.CurrentOrderId != Guid.Empty)
                {
                    ViewBag.Created = true;
                }
                else
                {
                    ViewBag.Created = false;
                }
            }
            List<Category> categories = await _categoryMethods.GetAll();
            return View(categories);
        }
        //ACCESS DENIED
        public IActionResult AccessDenied()
        {
            return View();
        }
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> PictureGallery(string Email, Guid orderId)
        {
            if (User.Identity.IsAuthenticated)
            {
                User _user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (_user.CurrentOrderId != Guid.Empty)
                {
                    ViewBag.Created = true;
                }
                else
                {
                    ViewBag.Created = false;
                }
            }
            List<GalleryUser> users = _galleryMethods.GetAll();
            ViewBag.email = Email;
            ViewBag.orderId = orderId;
            return View(users);
        }
    }
}
