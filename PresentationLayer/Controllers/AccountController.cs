using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        // private readonly SignInManager<User> _signInManager;
        // private readonly UserManager<User> _userManager;

        // public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        // {
        //     _signInManager = signInManager;
        //     _userManager = userManager;
        // }
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        // 🔹 Login GET
        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel viewModel = new LoginViewModel();
            return View(viewModel);
        }

        // 🔹 Login POST
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authService.LoginAsync(model.MatricNumber, model.Password, model.RememberMe);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home", model.MatricNumber);
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        // 🔹 Logout
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login");
        }
    }
}
