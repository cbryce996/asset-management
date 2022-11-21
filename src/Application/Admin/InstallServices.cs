using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Application.Common.Interfaces.IRepositories;
using AssetManagement.Domain.Install;
using AssetManagement.Domain.Software.ValueObjects;

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
            this.unitOfWork.InstallRepository.Add(new InstallEntity());
            this.unitOfWork.Complete();
            return _install;
        }
    }
}