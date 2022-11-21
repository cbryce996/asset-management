using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Domain.Software;
using AssetManagement.Domain.Software.ValueObjects;
using AssetManagement.Domain.System;
using AssetManagement.Domain.System.ValueObjects;

namespace AssetManagement.Application.Admin
{   
    public class AdminServices
    {
        private readonly IUnitOfWork unitOfWork;

        public AdminServices(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public void AddSystem(SystemDTO _system)
        {
            // Create new domain model
            SystemEntity system = new SystemEntity(
                new IpAddress(_system.IpAddress),
                new MacAddress(_system.MacAddress)
            );
            
            // Add changes to repository
            unitOfWork.SystemRepository.Add(system);

            // Complete changes
            unitOfWork.Complete();
        }

        public void InstallSoftwareOnSystem(SoftwareDTO _software, Guid _system)
        {
            // Create new domain model
            SoftwareEntity software = new SoftwareEntity(
                new SoftwareName(_software.Name),
                new SoftwareVersion(_software.Version),
                new SoftwareManufacturer(_software.Manufacturer)
            );

            try 
            {
                SystemEntity system = unitOfWork.SystemRepository.Get(_system);
                system.AddSoftware(software);
            } 
            catch 
            {

            }
        }
    }
}