using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Application.Common.Interfaces;

namespace AssetManagement.Application.Admin
{
    public class SoftwareServices
    {
        private readonly IUnitOfWork unitOfWork;

        public SoftwareServices(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
    }
}