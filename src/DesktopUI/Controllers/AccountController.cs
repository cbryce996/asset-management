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
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly AuthServices authServices;

        public AccountController(AuthServices _authServices, ILogger<AccountController> logger)
        {
            authServices = _authServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

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
                    new Claim(ClaimTypes.Name, _user.Username)
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Auth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync("Auth", claimsPrincipal);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(_user);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("Auth");

            return RedirectToAction("Index", "Home");
        }
    }
}