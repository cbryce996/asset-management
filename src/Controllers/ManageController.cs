using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using project_cbryce996.Core.IConfiguration;
using project_cbryce996.Models;
using project_cbryce996.Models.ViewModels;
using project_cbryce996.Models.ViewModels.AssetViewModels;

namespace project_cbryce996.Controllers
{
    public class ManageController : Controller
    {
        public ManageAssetViewModel view;

        private readonly ILogger<ManageController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public ManageController(ILogger<ManageController> logger, IUnitOfWork unitOfWork)
        {
            view = new ManageAssetViewModel();
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            view.ListViewModel = new ListAssetsViewModel();
            view.ListViewModel.Assets = await _unitOfWork.Assets.All();
            return View(view);
        }

        public async Task<IActionResult> AddAsset(ManageAssetViewModel assetViewModel)
        {
                Asset asset = new Asset();

                asset.SystemName = assetViewModel.CreateViewModel.SystemName;
                asset.Model = assetViewModel.CreateViewModel.Model;
                asset.Manufacturer = assetViewModel.CreateViewModel.Manufacturer;
                asset.Type = assetViewModel.CreateViewModel.Type;
                asset.Ip = assetViewModel.CreateViewModel.Ip;

                await _unitOfWork.Assets.Add(asset);
                await _unitOfWork.CompleteAsync();

                return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
