using BugTracker2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BugTracker2.Controllers
{
    public class AccountController : Controller
    {
        //DI properties for AppUser class created using UserManager
        //Same for SignInManager
        private UserManager<AppUser> _userManager { get; }
        private SignInManager<AppUser> _signInManager { get; }

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered";

                //Try and find "TestUser" from UserManager
                AppUser user = await _userManager.FindByNameAsync("TestUser");
                //If it doesn't find the user, creates one with these properties
                if(user == null)
                {
                    user = new AppUser();
                    user.UserName = "TestUser";
                    user.Email = "TestUser@test.com";
                    user.FirstName = "Testboy";
                    user.LastName = "Magee";

                    IdentityResult result = await _userManager.CreateAsync(user, "Test123!");
                    ViewBag.Message = "User was created";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> Login()
        {
            //Set this up to take user input for authentication/authorization
            var result = await _signInManager.PasswordSignInAsync("TestUser", "Test123!", false, false);

            //result.Succeeded ? return RedirectToAction("Index", "Home") : ViewBag.Result = "Result is:" + result.ToString();
            if (result.Succeeded)
            {
                return RedirectToAction("BugBoard", "Bugs");
            }
            else
            {
                ViewBag.Result = "Result is:" + result.ToString();
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");             
        }
    }
}
