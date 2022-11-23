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
using AssetManagement.Domain.Software;
using AutoMapper;
using Microsoft.AspNetCore.Builder.Extensions;
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
                        SoftwareId = software.Id,
                        SoftwareName = software.Name,
                        Version = software.Version,
                        Manufacturer = software.Manufacturer
                    }
                );
            }

            foreach (var system in systemDTOs)
            {
                model.Systems.Add(
                    new SystemViewModel() {
                        SystemId = system.Id,
                        SystemName = system.Name,
                        IpAddress = system.IpAddress,
                        MacAddress = system.MacAddress
                    }
                );
            }
            

            return View(model);
        }

        [HttpGet]
        public SoftwareViewModel Software(string _softwareId)
        {
            SoftwareDTO softwareDTO = new SoftwareDTO(); //adminServices.GetSoftwareById(_softwareId);
            
            return new SoftwareViewModel() {
                SoftwareId = softwareDTO.Id,
                SoftwareName = softwareDTO.Name,
                Version = softwareDTO.Version,
                Manufacturer = softwareDTO.Manufacturer
            };
        }

        [HttpPost]
        public SoftwareDTO Software(SoftwareViewModel _software, string _systemId)
        {
            return adminServices.AddSoftwareToSystem(new SoftwareDTO() {
                Id = _software.SoftwareId,
                Name = _software.SoftwareName,
                Version = _software.Version,
                Manufacturer = _software.Manufacturer
            }, _systemId);
        }

        [HttpGet]
        public SystemViewModel System(string _systemId)
        {
            SystemDTO systemDTO = adminServices.GetSystemById(_systemId);
            
            return new SystemViewModel() {
                SystemId = systemDTO.Id,
                SystemName = systemDTO.Name,
                IpAddress = systemDTO.IpAddress,
                MacAddress = systemDTO.MacAddress
            };
        }

        [HttpPost]
        public SystemDTO System(SystemViewModel _system)
        {
            return adminServices.AddSystem(new SystemDTO() {
                Id = _system.SystemId,
                Name = _system.SystemName,
                IpAddress = _system.IpAddress,
                MacAddress = _system.MacAddress
            });
        }

        [HttpGet]
        public IActionResult AddNewSystem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewSystem(SystemViewModel _system)
        {
            if (ModelState.IsValid)
            {
                System(_system);
                return RedirectToAction("Index");
            }
            return View(_system);
        }

        [HttpGet]
        public IActionResult AddSoftwareToSystem(string _systemId)
        {
            AddSoftwareToSystemViewModel addSoftwareToSystem = new AddSoftwareToSystemViewModel() {
                System = System(_systemId),
                Software = new SoftwareViewModel()
            };

            return View(addSoftwareToSystem);
        }

        [HttpPost]
        public IActionResult AddSoftwareToSystem(AddSoftwareToSystemViewModel addSoftwareToSystem)
        {
            if (ModelState.IsValid)
            {
                Software(addSoftwareToSystem.Software, addSoftwareToSystem.System.SystemId);
                return RedirectToAction("Index");
            }
            return View(addSoftwareToSystem);
        }

        [HttpGet]
        public IActionResult LookupSoftwareOnSystem(string _systemId)
        {
            IList<SoftwareDTO> softwareEntities = adminServices.GetSoftwareOnSystem(_systemId);
            IList<SoftwareViewModel> softwareViewModels = new List<SoftwareViewModel>();

            foreach (var software in softwareEntities)
            {
                softwareViewModels.Add(
                    new SoftwareViewModel() {
                        SoftwareId = software.Id,
                        SoftwareName = software.Name,
                        Version = software.Version,
                        Manufacturer = software.Manufacturer
                });
            }

            LookupSoftwareOnSystemViewModel lookupSoftwareOnSystem = new LookupSoftwareOnSystemViewModel() {
                System = System(_systemId),
                Software = softwareViewModels
            };
            return View(lookupSoftwareOnSystem);
        }

        [HttpGet]
        public IActionResult EditSystemInformation(string _systemId)
        {
            return View(System(_systemId));
        }

        public IActionResult NewSystem()
        {
            return View();
        }

        public IActionResult EditSystem(SystemViewModel _system)
        {
            return View(_system);
        }

        public IActionResult DeleteSoftware(SoftwareViewModel _software)
        {
            SoftwareDTO software = new SoftwareDTO() {
                Id = _software.SoftwareId,
                Name = _software.SoftwareName,
                Version = _software.Version,
                Manufacturer = _software.Manufacturer
            };
            adminServices.DeleteSoftware(software);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSystem(SystemViewModel _system)
        {
            SystemDTO system = new SystemDTO() {
                Id = _system.SystemId,
                Name = _system.SystemName,
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