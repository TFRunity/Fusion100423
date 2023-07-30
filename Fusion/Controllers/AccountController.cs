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

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrderRepository<Order> orderRepository, IUserRepository<User> userMethods)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderRepository = orderRepository;
            _userMethods = userMethods;
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
            return View(user);
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


        //1.Страничка с просмотром заказа 
        //2.Личный кабинет, в котором отслеживаются прошлые заказы
        //3.Страничка, создающая сам заказ (сделано)

        /// <summary>
        /// First method called by user, which creates First Order (Call if user's CurrentOrderId == null)
        /// </summary>
        /// <returns>Relate to MainView</returns>
        public async Task<IActionResult> Cart(string UserEmail, Guid ProductId)
        {
            await _orderRepository.Create(ProductId, UserEmail);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Order(Guid OrderId)
        {
            return View(await _orderRepository.Get(OrderId));
        }
        [HttpPost]
        public async Task<IActionResult> Order(Order order)
        {
            await _orderRepository.Update(order);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> DeleteProduct(Guid ProductId, Guid OrderId)
        {
            await _orderRepository.DeleteObjFromOrder(ProductId);
            return RedirectToAction(nameof(Order), new { OrderId = OrderId });
        }
        public async Task<IActionResult> ConfirmOrder(Guid orderId, string email)
        {
            await _orderRepository.ConfirmOrder(orderId, email);
            return RedirectToAction(nameof(PersonalArea), new { email = email });
        }
        [HttpPost]
        public async Task<IActionResult> ChangeCount(CounterViewModel viewModel)
        {
            await _orderRepository.ChangeCount(viewModel);
            return RedirectToAction(nameof(Order), new { OrderId = viewModel.OrderId });
        }
        public async Task<IActionResult> ClearOrder(Guid orderId)
        {
            await _orderRepository.Clear(orderId);
            return RedirectToAction(nameof(Order), new { OrderId = orderId });
        }
    }
}
