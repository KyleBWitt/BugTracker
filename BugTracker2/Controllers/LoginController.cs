using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;

namespace BugTracker2.Controllers
{
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {

            return View();
        }  

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Validate(string username, string password)
        {
            if(username == "Kyle" && password == "password")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return Ok();

            }
                return BadRequest();



        }

    }
}
