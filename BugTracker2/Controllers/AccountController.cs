using BugTracker2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                ViewBag.Message = "User already registered";

                //Try and find user from UserManager
                AppUser user = await _userManager.FindByNameAsync("KBW110988");
                //If it doesn't find the user, creates one with these properties
                if(user == null)
                {
                    //Change this to reflect validated user input
                    user = new AppUser
                    {
                        UserName = "KBW110988",
                        Email = "kbw110988@gmail.com",
                        FirstName = "Kyle",
                        LastName = "Witt"
                    };

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

        public async Task<IActionResult> Login(AppUser user)
        {
            //Set this up to take user input for authentication/authorization
            var result = await _signInManager.PasswordSignInAsync(user.UserName, "Test123!", false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("BugBoard", "Bugs");
            }
            else
            {
                return RedirectToAction("LoginForm", "Account");
            }
        }
        public IActionResult LoginForm()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");             
        }
    }
}
