using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AssetManagement.Application.Auth;
using AssetManagement.Application.Auth.DTOs;
using AssetManagement.DesktopUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AssetManagement.DesktopUI.Controllers
{
    /*
    * Controller for handling user authentication, creates a new authenticaiton cookie and logs * user out.
    */

    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly AuthServices authServices;

        public AccountController(AuthServices _authServices, ILogger<AccountController> logger)
        {
            authServices = _authServices;
            _logger = logger;
        }

         /* Renders the login view */
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

         /* Logs user in if credentials are correct */
        [HttpPost]
        public async Task<IActionResult> Login(UserViewModel _user)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = await authServices.CheckIfUserExists(
                    new UserDTO(){
                        Username = _user.Username,
                        Password = _user.Password
                    }
                );

                if (user != null)
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "test"),
                    new Claim(ClaimTypes.Email, "test@website.com")
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Auth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync("Auth", claimsPrincipal);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(_user);
        }

         /* Removes authenticaiton cookie for logout */
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Auth");

            return RedirectToAction("Index", "Home");
        }
    }
}