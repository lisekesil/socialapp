using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using socialapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialapp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserModel> _userManager;
        private SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await _userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/");
                    }
                }
            }
            ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
            
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    UserName = registerModel.Name,
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Find");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError("", "Błąd rejestracji");
            }
            return View(registerModel);
        }
    }
}
