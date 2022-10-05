using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var assets = await _unitOfWork.Assets.All();
            await _unitOfWork.CompleteAsync();
            return View(assets);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
