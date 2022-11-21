using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.Logging;

namespace AssetManagement.DesktopUI.Controllers
{
    public class AdminController: Controller
    {
        private readonly ILogger<AdminController> logger;
        private readonly SystemServices systemServices;
        
        public AdminController(ILogger<AdminController> _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IActionResult GetSystems()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SystemDTO, SystemViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            IEnumerable<SystemDTO> systemList = systemServices.Get();
            IEnumerable<SystemViewModel> systemViewModelList = new SystemViewModel[]{};
            foreach (SystemDTO system in systemList)
            {
                SystemDTO source = system;
                SystemViewModel result = mapper.Map<SystemDTO, SystemViewModel>(source);
                systemViewModelList.Append<SystemViewModel>(result);
            }
            return View(systemViewModelList);
        }
    }
}