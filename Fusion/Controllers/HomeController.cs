using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Fusion.Models;
using Fusion.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Fusion.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ICategoryMethods<Category> _categoryMethods;
        private readonly IUserMethods _userMethods;
        public HomeController(IUserMethods userMethods, ICategoryMethods<Category> categoryMethods)
        {
            _userMethods = userMethods;
            _categoryMethods = categoryMethods;
        }
        public async Task<IActionResult> Index()
        {
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
        public IActionResult Navbar()
        {
            return PartialView("_Navbar");
        }
        
    }
}
