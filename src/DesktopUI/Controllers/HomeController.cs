using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Immutable;
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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            IndexViewModel model = new IndexViewModel();
            IEnumerable<SoftwareDTO> softwareDTOs = adminServices.GetAllSoftware();
            IEnumerable<SystemDTO> systemDTOs = adminServices.GetAllSystems();
            
            foreach (var software in softwareDTOs)
            {
                model.Software.Add(
                    new SoftwareViewModel() {
                        Id = software.Id,
                        Name = software.Name,
                        Version = software.Version,
                        Manufacturer = software.Manufacturer
                    }
                );
            }

            foreach (var system in systemDTOs)
            {
                model.Systems.Add(
                    new SystemViewModel() {
                        Id = system.Id,
                        Name = system.Name,
                        IpAddress = system.IpAddress,
                        MacAddress = system.MacAddress
                    }
                );
            }
            

            return View(model);
        }

        public IActionResult ViewSystem(SystemViewModel _system)
        {
            ViewSystemViewModel viewSystem = new ViewSystemViewModel();
            viewSystem.System = _system;
            return View(viewSystem);
        }

        public IActionResult NewSoftware(SystemViewModel _system)
        {
            NewSoftwareViewModel newSoftware = new NewSoftwareViewModel();
            newSoftware.System = _system;
            return View(newSoftware);
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
            return RedirectToAction("Index");
        }

        public IActionResult AddSystem(SystemViewModel _system)
        {
            SystemDTO system = new SystemDTO() {
                Name = _system.Name,
                IpAddress = _system.IpAddress,
                MacAddress = _system.MacAddress
            };
            adminServices.AddSystem(system);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSoftware(SoftwareViewModel _software)
        {
            SoftwareDTO software = new SoftwareDTO() {
                Id = _software.Id,
                Name = _software.Name,
                Version = _software.Version,
                Manufacturer = _software.Manufacturer
            };
            adminServices.DeleteSoftware(software);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSystem(SystemViewModel _system)
        {
            SystemDTO system = new SystemDTO() {
                Id = _system.Id,
                Name = _system.Name,
                IpAddress = _system.IpAddress,
                MacAddress = _system.MacAddress
            };
            adminServices.DeleteSystem(system);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}