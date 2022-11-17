using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AssetManagement.DesktopUI.Models;
using AssetManagement.Application.Common.Interfaces;

namespace AssetManagement.DesktopUI.Controllers
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
            Asset asset = new Asset();

            return View("AddAsset", asset);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
