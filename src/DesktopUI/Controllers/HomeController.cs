using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Reflection.PortableExecutable;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using AssetManagement.Application.Admin;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.DesktopUI.Models;
using AssetManagement.Domain.System.ValueObjects;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;

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
            IEnumerable<SystemDTO> systemDTOs = adminServices.GetAllSystems();

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
                Name = softwareDTO.Name,
                Version = softwareDTO.Version,
                Manufacturer = softwareDTO.Manufacturer
            };
        }

        [HttpPost]
        public IList<SoftwareDTO> Software(IList<SoftwareViewModel> _softwareViewModels, string _systemId)
        {
            IList<SoftwareDTO> softwareDTOs = new List<SoftwareDTO>();

            foreach (var software in _softwareViewModels)
            {
                softwareDTOs.Add( new SoftwareDTO() {
                    Name = software.Name,
                    Version = software.Version,
                    Manufacturer = software.Manufacturer
            });
            }

            return adminServices.AddMultipleSoftwareToSystem(softwareDTOs, _systemId);
        }

        [HttpPost]
        public SoftwareDTO Software(SoftwareViewModel _software, string _systemId)
        {
            return adminServices.AddSoftwareToSystem(new SoftwareDTO() {
                Name = _software.Name,
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
                        Name = software.Name,
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
        public IActionResult CheckVulnerabilityOfSoftware(SoftwareViewModel _software)
        {
            using (RestClient client = new RestClient("https://services.nvd.nist.gov/rest/json/cves/2.0"))
            {
                    client.UseSystemTextJson();
                    RestRequest request = new RestRequest();
/*
                    request.AddParameter("keywordSearch",
                        HttpUtility.UrlPathEncode(_software.Version.ToLower().Replace(" ", "_")) + " " +
                        HttpUtility.UrlPathEncode(_software.Name.ToLower().Replace(" ", "_"))
                    );
*/
                    
                    request.AddParameter("keywordSearch",
                        HttpUtility.UrlPathEncode(_software.Name).ToLower().Replace(" ", "_") + " " +
                        HttpUtility.UrlPathEncode(_software.Version).ToLower().Replace(" ", "_")
                    );
                    

                    try
                    {
                        var response = client.ExecuteAsync(request).Result;
                        var deserialized = JsonConvert.DeserializeObject<dynamic>(response.Content);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    };
            }

            CheckVulnerabilityOfSoftwareViewModel checkVulnerability = new CheckVulnerabilityOfSoftwareViewModel() {
                Software = _software
            };

            return View(checkVulnerability);
        }

        [HttpGet]
        public IActionResult EditSystemInformation(string _systemId)
        {
            return View(System(_systemId));
        }

        [HttpGet]
        public IActionResult AutoGetSoftwareOnSystem(string _systemId)
        {
            IList<SoftwareViewModel> softwareViewModels = new List<SoftwareViewModel>();

            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using(Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach(string subkey_name in key.GetSubKeyNames())
                {
                    using(RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        if (
                            subkey.GetValue("DisplayName") != null &&
                            subkey.GetValue("DisplayVersion") != null &&
                            subkey.GetValue("Publisher")  != null
                        )
                        {
                            softwareViewModels.Add( new SoftwareViewModel() {
                                Name = (string)subkey.GetValue("DisplayName"),
                                Version = (string)subkey.GetValue("DisplayVersion"),
                                Manufacturer = (string)subkey.GetValue("Publisher")
                            });
                        }
                    }
                }
            }
            Software(softwareViewModels, _systemId);
            return RedirectToAction("LookupSoftwareOnSystem", "Home", new { _systemId = _systemId });
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