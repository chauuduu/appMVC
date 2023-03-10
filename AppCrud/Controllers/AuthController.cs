using AppCrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCrud.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
        }
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                TempData["Message"] = "Username doesn't exist !";
            }
            else
            {
                var response =  await _signInManager.PasswordSignInAsync(user,password,true, true);
                if (response.Succeeded)
                {
                    return Redirect("/");
                }
                else 
                {
                    TempData["Message"] = "The Username or Password is Incorrect!";
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(string username, string password, string fullname)
        {
            var user = new AppUser()
            {
                UserName = username,
                EmailConfirmed = true
            };
            user.SetName(fullname);
            var userCurrent =  await _userManager.FindByNameAsync(username);
            if (userCurrent != null)
            {
                ViewData["Message"] = "Username is exist !";
            }
            var createResponse = await _userManager.CreateAsync(user, password);
            if (createResponse.Succeeded)
            {
                var role = await _roleManager.FindByNameAsync("USER");
                if (role == null)
                {
                    role= new IdentityRole()
                    {
                        Name = "USER",
                    };

                    var responseRole = await _roleManager.CreateAsync(role);
                }
                var responseAddRoleToUser =   await _userManager.AddToRoleAsync(user, role.Name);
                if (responseAddRoleToUser.Succeeded)
                    {
                     ViewData["Message"] = "Register Success!";
                }
                else
                    {
                    ViewData["Message"] = "Register Failed ! Please check and try again !";
                 }
            }
            return View();
        }
    }
}
