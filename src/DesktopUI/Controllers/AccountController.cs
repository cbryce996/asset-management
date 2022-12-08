using System.Collections.Generic;
using System.Security.Claims;
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

        public AccountController(ILogger<AccountController> logger)
        {
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
        public IActionResult Login(UserViewModel _user)
        {
            if (ModelState.IsValid)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "test"),
                    new Claim(ClaimTypes.Email, "test@website.com")
                };
                var identity = new ClaimsIdentity(claims, "Auth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync("Auth", claimsPrincipal);

                return RedirectToAction("Index", "Home");
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