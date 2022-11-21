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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Asset> _model;
            _model = _unitOfWork.Assets.All();
            return View(_model);
        }
    }
}
