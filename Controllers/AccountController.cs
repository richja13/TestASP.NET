﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        string Error = "";

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login userLoginData)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginData);
            }


            var result = await _signInManager.PasswordSignInAsync(userLoginData.UserName, userLoginData.Password, false, false);

            if (result.Succeeded)
            {
                Error = " ";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Error = "Hasło lub nazwa użytkownika nieprawidłowa";
                ViewData["Error"] = Error;
                return View();
            }
           
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register userRegisterData)
        {
            if(!ModelState.IsValid)
            {
                return View(userRegisterData);
            }
            
            await _userManager.CreateAsync(new UserModel
            {
                Email = userRegisterData.Email,
                UserName = userRegisterData.UserName

            }, userRegisterData.Password);


            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

      
    }
}
