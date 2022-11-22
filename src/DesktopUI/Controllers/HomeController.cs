using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using AssetManagement.Application.Admin;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.DesktopUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace AssetManagement.DesktopUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AdminServices adminServices;

        public HomeController(ILogger<HomeController> logger, AdminServices _adminServices)
        {
            _logger = logger;
            adminServices = _adminServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewSoftware()
        {
            return View();
        }

        public IActionResult ViewSystem()
        {
            return View();
        }

        public IActionResult NewSoftware()
        {
            return View();
        }

        public IActionResult NewSystem()
        {
            return View();
        }

        public IActionResult AddSoftware(SoftwareViewModel _software)
        {
            SoftwareDTO software = new SoftwareDTO() {
                Name = _software.Name,
                Version = _software.Version,
                Manufacturer = _software.Manufacturer
            };
            adminServices.AddSoftware(software);
            return View("Index");
        }

        public IActionResult AddSystem(SystemViewModel _system)
        {
            SystemDTO system = new SystemDTO() {
                IpAddress = _system.IpAddress,
                MacAddress = _system.MacAddress
            };
            adminServices.AddSystem(system);
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}