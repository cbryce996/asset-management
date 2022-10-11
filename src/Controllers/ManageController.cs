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
    public class ManageController : Controller
    {
        private readonly ILogger<ManageController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public ManageController(ILogger<ManageController> logger, IUnitOfWork unitOfWork)
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
            Console.Out.WriteLine(info.Cpu.Name);

            return RedirectToAction("AddAsset");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
