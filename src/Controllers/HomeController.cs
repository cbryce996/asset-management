using System;
using System.Management;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HardwareInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using project_cbryce996.Core.IConfiguration;
using project_cbryce996.Models;

namespace project_cbryce996.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Asset> _model;
            _model = _unitOfWork.Assets.All();
            return View(_model);
        }

        [HttpGet]
        public IActionResult AddAsset()
        {
            Asset _asset = new Asset();
            return View(_asset);
        }

        [HttpPost]
        public IActionResult AddAsset(Asset asset)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Assets.Add(asset);
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            else {
                return View(asset);
            }
        }

        [HttpGet]
        public IActionResult SystemInfo()
        {
            MachineInformation info = MachineInformationGatherer.GatherInformation();

            Asset asset = new Asset();

            asset.Os = info.OperatingSystem.ToString();
            asset.BiosName = info.SmBios.BIOSCodename;
            asset.BiosVersion = info.SmBios.BIOSVersion;
            asset.BiosVendor = info.SmBios.BIOSVendor;
            asset.MbName = info.SmBios.BoardName;
            asset.MbVersion = info.SmBios.BoardVersion;
            asset.MbVendor = info.SmBios.BIOSVendor;
            asset.GpuName = info.Gpus[0].Name;
            asset.GpuVendor = info.Gpus[0].Vendor;
            asset.GpuType = info.Gpus[0].Type.ToString();
            asset.CpuName = info.Cpu.Name;
            asset.CpuVendor = info.Cpu.Vendor;
            asset.CpuModel = info.Cpu.Model.ToString();
            asset.CpuArch = info.Cpu.Architecture;

            return View("AddAsset", asset);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
