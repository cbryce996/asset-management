using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Application.Common.Interfaces.IRepositories;

namespace AssetManagement.Application.Admin
{
    public class InstallServices
    {
        private readonly IUnitOfWork unitOfWork;

        public InstallServices(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public InstallDTO Add(InstallDTO _install)
        {
            // Check for existing system
            //
            return new InstallDTO();
        }
    }
}