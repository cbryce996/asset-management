using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AssetManagement.Application.Admin;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.DesktopUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.Json;

namespace AssetManagement.DesktopUI.Controllers
{
    /*
    * Main controller for admin, handles rendering of views and conversion of data from DTO to 
    * ViewModel and vice versa. Sends and receives prepared data from Application Layer.
    */

    [Authorize]
    public class HomeController : Controller
    {
        /* Local DI services */
        private readonly ILogger<HomeController> _logger;
        private readonly AdminServices adminServices;

        /* Capture DI services */
        public HomeController(ILogger<HomeController> logger, AdminServices _adminServices)
        {
            _logger = logger;
            adminServices = _adminServices;
        }

        /* Renders Index view */
        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel();
            IEnumerable<SystemDTO> systemDTOs = await adminServices.GetAllSystems();

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

        /* Adds a batch of Software entites to a System */
        [HttpPost]
        public async Task<IList<SoftwareDTO>> Software(IList<SoftwareViewModel> _softwareViewModels, string _systemId)
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

            return await adminServices.AddMultipleSoftwareToSystem(softwareDTOs, _systemId);
        }

        /* Adds a single Software entity to a System */
        [HttpPost]
        public async Task<SoftwareDTO> Software(SoftwareViewModel _software, string _systemId)
        {
            return await adminServices.AddSoftwareToSystem(new SoftwareDTO() {
                Name = _software.Name,
                Version = _software.Version,
                Manufacturer = _software.Manufacturer
            }, _systemId);
        }

        /* Gets a System entity from id */
        [HttpGet]
        public async Task<SystemViewModel> System(string _systemId)
        {
            SystemDTO systemDTO = await adminServices.GetSystemById(_systemId);
            
            return new SystemViewModel() {
                SystemId = systemDTO.Id,
                SystemName = systemDTO.Name,
                IpAddress = systemDTO.IpAddress,
                MacAddress = systemDTO.MacAddress
            };
        }

        /* Adds a single System entity */
        [HttpPost]
        public async Task<SystemDTO> System(SystemViewModel _system)
        {
            return await adminServices.AddSystem(new SystemDTO() {
                Name = _system.SystemName,
                IpAddress = _system.IpAddress,
                MacAddress = _system.MacAddress
            });
        }

        /* Renders the Add New System view */
        [HttpGet]
        public async Task<IActionResult> AddNewSystem()
        {
            return View();
        }

        /* Handles post request for Add New System view */
        [HttpPost]
        public async Task<IActionResult> AddNewSystem(SystemViewModel _system)
        {
            if (ModelState.IsValid)
            {
                await System(_system);
                return RedirectToAction("Index");
            }
            return View(_system);
        }

        /* Renders a view to add Software to a system */
        [HttpGet]
        public async Task<IActionResult> AddSoftwareToSystem(string _systemId)
        {
            AddSoftwareToSystemViewModel addSoftwareToSystem = new AddSoftwareToSystemViewModel() {
                System = await System(_systemId),
                Software = new SoftwareViewModel()
            };

            return View(addSoftwareToSystem);
        }

        /* Handles post request for Add Software to System view */
        [HttpPost]
        public async Task<IActionResult> AddSoftwareToSystem(AddSoftwareToSystemViewModel addSoftwareToSystem)
        {
            if (ModelState.IsValid)
            {
                await Software(addSoftwareToSystem.Software, addSoftwareToSystem.System.SystemId);
                return RedirectToAction("LookUpSoftwareOnSystem", "Home", new { _systemId = addSoftwareToSystem.System.SystemId });
            }
            return View(addSoftwareToSystem);
        }

        /* Renders a view which shows all Software on a given system */
        [HttpGet]
        public async Task<IActionResult> LookupSoftwareOnSystem(string _systemId)
        {
            IList<SoftwareDTO> softwareEntities = await adminServices.GetSoftwareOnSystem(_systemId);
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
                System = await System(_systemId),
                Software = softwareViewModels
            };

            return View(lookupSoftwareOnSystem);
        }

        /* Renders a view which checks the vulnerability of a Software entity */
        [HttpGet]
        public async Task<IActionResult> CheckVulnerabilityOfSoftware(SoftwareViewModel _software)
        {
            CheckVulnerabilityOfSoftwareViewModel checkVulnerability = new CheckVulnerabilityOfSoftwareViewModel() {
                Software = _software
            };

            /* RestClient package used to communicate with API */
            using (RestClient client = new RestClient("https://services.nvd.nist.gov/rest/json/cves/2.0"))
            {
                    client.UseSystemTextJson();
                    var request = new RestRequest();

                    /* Required format for CVE Vulnerability search */
                    request.AddParameter("virtualMatchString",
                        "cpe:2.3:*:" +
                        _software.Manufacturer.ToLower().Replace(" ", "_") + ":" +
                        _software.Name.ToLower().Replace(" ", "_") + ":" +
                        "*"
                    );

                    request.AddParameter("resultsPerPage", 5);

                    RestResponse response = await client.ExecuteAsync(request);

                    checkVulnerability.CveResponse = JsonConvert.DeserializeObject<CveResponseViewModel>(response.Content);
            }

            return View(checkVulnerability);
        }

        /* Renders a view to Edit System Information */
        [HttpGet]
        public async Task<IActionResult> EditSystemInformation(string _systemId)
        {
            SystemViewModel system = await System(_systemId);
            return View(system);
        }

        /* Handles post request for Edit System Information view */
        [HttpPost]
        public async Task<IActionResult> EditSystemInformation(SystemViewModel _system)
        {
            SystemDTO system = new SystemDTO() {
                Id = _system.SystemId,
                IpAddress = _system.IpAddress,
                MacAddress = _system.MacAddress,
                Name = _system.SystemName
            };

            await adminServices.EditSystemInformation(system, _system.SystemId);

            return RedirectToAction("Index");
        }

        /* Get's all software on the running system */
        [HttpGet]
        public async Task<IActionResult> AutoGetSoftwareOnSystem(string _systemId)
        {
            IList<SoftwareViewModel> softwareViewModels = new List<SoftwareViewModel>();

            /* Use Uninstall registry key to get software */
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
                            /* If all fields exist create a new Software view model */
                            softwareViewModels.Add( new SoftwareViewModel() {
                                Name = (string)subkey.GetValue("DisplayName"),
                                Version = (string)subkey.GetValue("DisplayVersion"),
                                Manufacturer = (string)subkey.GetValue("Publisher")
                            });
                        }
                    }
                }
            }

            /* Batch add Software to System */
            await Software(softwareViewModels, _systemId);

            /* Return to Software Lookup view */
            return RedirectToAction("LookupSoftwareOnSystem", "Home", new { _systemId = _systemId });
        }

        /* Renders view for creating a new System */
        [HttpGet]
        public async Task<IActionResult> NewSystem()
        {
            return View();
        }

        /* Renders view for editing system */
        [HttpGet]
        public async Task<IActionResult> EditSystem(SystemViewModel _system)
        {
            return View(_system);
        }

        /* Deletes a Software entity from a System */
        [HttpGet]
        public async Task<IActionResult> DeleteSoftware(SoftwareViewModel _software, string _systemId)
        {
            SoftwareDTO software = new SoftwareDTO() {
                Name = _software.Name,
                Version = _software.Version,
                Manufacturer = _software.Manufacturer
            };
            await adminServices.DeleteSoftware(software, _systemId);
            return RedirectToAction("LookupSoftwareOnSystem", "Home", new { _systemId = _systemId });
        }

        /* Deletes a System */
        [HttpGet]
        public async Task<IActionResult> DeleteSystem(string _systemId)
        {
            await adminServices.DeleteSystem(_systemId);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}