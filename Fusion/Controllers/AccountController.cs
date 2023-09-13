using Fusion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Fusion.ViewModels;
using Fusion.Interfaces;
using System.Threading.Tasks;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using Fusion.DatabaseMethods;

namespace Fusion.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOrderRepository<Order> _orderRepository;
        private readonly IUserRepository<User> _userMethods;
        private readonly IRepository<UsersPicture> _pictureRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrderRepository<Order> orderRepository, IUserRepository<User> userMethods, IRepository<UsersPicture> pictureRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderRepository = orderRepository;
            _userMethods = userMethods;
            _pictureRepository = pictureRepository;
        }

        //Authentification Methods

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Name, Year = model.Year, FutureJob = model.FutureJob};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Anon"));
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> PersonalArea(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            UserAtSite atSite = new UserAtSite(user);
            return View(atSite);
        }
        [Authorize(Policy = "Manager")]
        public IActionResult AdminArea()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
                var result =
                    await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            return View(model);
        }
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Policy = "Member")]
        [HttpGet]
        public async Task<IActionResult> Edit(string email)
        {
            User user = await _userMethods.Get(email);
            return View(user);
        }
        [Authorize(Policy = "Member")]
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            await _userMethods.Update(user);
            return RedirectToAction(nameof(PersonalArea), new { email = user.Email });
        }
        [Authorize(Policy = "Member")]
        [HttpGet]
        public async Task<IActionResult> EditPassword(string email)
        {
            User user = await _userMethods.Get(email);
            ChangePassword viewmodel = new ChangePassword() { Email = user.Email };
            return View(viewmodel);
        }
        [Authorize(Policy = "Member")]
        [HttpPost]
        public async Task<IActionResult> EditPassword(ChangePassword viewmodel)
        {
            await _userMethods.UpdatePassword(viewmodel.Email, viewmodel.Password);
            return RedirectToAction(nameof(PersonalArea), new { email = viewmodel.Email });
        }
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> Pictures(string email)
        {
            User user = await _userMethods.Get(email);
            UserAtSite atSite = new UserAtSite(user);
            return View(atSite);
        }
        public async Task<IActionResult> Cart(CreateOrderItemViewModel viewModel)
        {
            await _orderRepository.Create(viewModel);
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Policy = "Member")]
        [HttpGet]
        public async Task<IActionResult> Order(Guid OrderId)
        {
            return View(await _orderRepository.Get(OrderId));
        }
        [Authorize(Policy = "Member")]
        [HttpPost]
        public async Task<IActionResult> Order(Order order)
        {
            await _orderRepository.Update(order);
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> DeleteProduct(Guid ProductId, Guid OrderId)
        {
            await _orderRepository.DeleteObjFromOrder(ProductId);
            return RedirectToAction(nameof(Order), new { OrderId = OrderId });
        }
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> ConfirmOrder(Guid orderId, string email)
        {
            await _orderRepository.ConfirmOrder(orderId, email);
            return RedirectToAction(nameof(PersonalArea), new { email = email });
        }
        [Authorize(Policy = "Member")]
        [HttpPost]
        public async Task<IActionResult> ChangeCount(CounterViewModel viewModel)
        {
            await _orderRepository.ChangeCount(viewModel);
            return RedirectToAction(nameof(Order), new { OrderId = viewModel.OrderId });
        }
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> ClearOrder(Guid orderId)
        {
            await _orderRepository.Clear(orderId);
            return RedirectToAction(nameof(Order), new { OrderId = orderId });
        }
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> OrderHistory(string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            UserAtSite userAtSite = new UserAtSite(user);
            return View(userAtSite);
        }
        [Authorize(Policy = "Member")]
        [HttpGet]
        public async Task<IActionResult> Picture(string email)
        {
            User _user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (_user.CurrentOrderId != Guid.Empty)
            {
                ViewBag.Created = true;
                ViewBag.OrderId = _user.CurrentOrderId;
            }
            else
            {
                ViewBag.Created = false;
            }
            AddPictureViewModel model = new AddPictureViewModel { Email = email };
            return View(model);
        }
        [Authorize(Policy = "Member")]
        [HttpPost]
        public async  Task<IActionResult> Picture(AddPictureViewModel viewModel)
        {
            UsersPicture picture = new UsersPicture
            {
                URL = viewModel.Url,
                User = await _userMethods.Get(viewModel.Email)
            };
            await _pictureRepository.Create(picture);
            return RedirectToAction(nameof(PersonalArea), new { email = viewModel.Email });
        }
        [Authorize(Policy = "Member")]
        public async Task<IActionResult> DeletePicture(Guid pictureId, string email)
        {
            await _pictureRepository.Delete(pictureId);
            return RedirectToAction(nameof(PersonalArea), new { email = email });
        }
    }
}
