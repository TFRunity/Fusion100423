using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Fusion.Models;
using Fusion.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System;

namespace Fusion.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ICategoryMethods<Category> _categoryMethods;
        private readonly UserManager<User> _userManager;
        private readonly IUserMethods _userMethods;
        private readonly IUserRepository<User> _userRepository;

        public HomeController(UserManager<User> userManager, IUserMethods userMethods, ICategoryMethods<Category> categoryMethods, IUserRepository<User> userRepository)
        {
            _userMethods = userMethods;
            _categoryMethods = categoryMethods;
            _userRepository = userRepository;
            _userManager = userManager;
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
        //Макет для создания/отображения зарегистрированных пользователей
        public IActionResult UsersAtSite()
        {
            List<UserAtSite> users = _userMethods.GetAllSiteUsers();
            return View(users);
        }
        //ACCESS DENIED
        public IActionResult AccessDenied()
        {
            return View();
        }
        //Посмотреть на конкретного пользователя ( со стороны НЕ администратора )
        public IActionResult Visitors(string name)
        {
            UserAtSite user = _userMethods.GetCurrentSiteUser(name);
            return View(user);
        }
    }
}
