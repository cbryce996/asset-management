using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Domain.System;

namespace AssetManagement.Application.Admin
{
    public class SystemServices
    {
        private readonly IUnitOfWork unitOfWork;

        public SystemServices(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IEnumerable<SystemDTO> Get()
        {
            IEnumerable<SystemEntity> systemList = unitOfWork.SystemRepository.All();
            IEnumerable<SystemDTO> systemDtoList = new SystemDTO[]{};
            foreach (SystemEntity system in systemList)
            {
                SystemDTO result = new SystemDTO() {
                    IpAddress = system.Ip.Ip,
                    MacAddress = system.Mac.Mac
                };
                systemDtoList.Append<SystemDTO>(result);
            }
            return systemDtoList;
        }
    }
}