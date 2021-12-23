using Client.ViewModels;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    userName: model.Username,
                    password: model.Password,
                    isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", new { area = "", controller = "Home" });
                }
            }

            ModelState.AddModelError("", "Provide valid credentials to login");
            return View(model);
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        #endregion

        #region Forgot Password
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        #endregion

        #region Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //TODO: Clear existing user session
            return RedirectToAction("Login", new { area = "", controller = "Auth" });
        }
        #endregion
    }
}
