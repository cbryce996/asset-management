using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public IEnumerable<SystemDTO> GetAllSystems()
        {
            IEnumerable<SystemEntity> systemEntities = unitOfWork.SystemRepository.All();
            IList<SystemDTO> systemDTOs = new List<SystemDTO>();

            foreach (SystemEntity system in systemEntities)
            {
                systemDTOs.Add(
                    new SystemDTO() {
                        Id = system.Id.ToString(),
                        Name = system.Name.Name,
                        IpAddress = system.Ip.Ip,
                        MacAddress = system.Mac.Mac
                    }
                );
            }

            return systemDTOs;
        }


        // TODO: Fix ValueObject getters
        public IEnumerable<SoftwareDTO> GetAllSoftware()
        {
            IEnumerable<SoftwareEntity> softwareEntities = unitOfWork.SoftwareRepository.All();
            IList<SoftwareDTO> softwareDTOs = new List<SoftwareDTO>();

            foreach (SoftwareEntity software in softwareEntities)
            {
                softwareDTOs.Add(
                    new SoftwareDTO() {
                        Id = software.Id.ToString(),
                        Name = software.Name.Name,
                        Version = software.Version.Version,
                        Manufacturer = software.Manufacturer.Manufacturer
                    }
                );
            }

            return softwareDTOs;
        }

        public IList<SoftwareDTO> GetSoftwareOnSystem(string _systemId)
        {
            IEnumerable<SoftwareEntity> softwareEntities = unitOfWork.SoftwareRepository.All();
            IList<SoftwareDTO> softwareDTOs = new List<SoftwareDTO>();
            foreach (var software in softwareEntities)
            {
                if (software.SystemId.ToString() == _systemId)
                {
                    softwareDTOs.Add(new SoftwareDTO() {
                        Id = software.Id.ToString(),
                        Name = software.Name.Name,
                        Version = software.Version.Version,
                        Manufacturer = software.Manufacturer.Manufacturer
                    });
                }
            }
            return softwareDTOs;
        }

        public SystemDTO GetSystemById(string _systemId)
        {
            SystemEntity system = unitOfWork.SystemRepository.Get(new Guid(_systemId));
            SystemDTO systemDTO = new SystemDTO() {
                Id = system.Id.ToString(),
                Name = system.Name.Name,
                IpAddress = system.Ip.Ip,
                MacAddress = system.Mac.Mac
            };
            
            return systemDTO;
        }

        public SystemDTO AddSystem(SystemDTO _system)
        {
            // Create new domain model
            SystemEntity system = new SystemEntity(
                new SystemName(_system.Name),
                new IpAddress(_system.IpAddress),
                new MacAddress(_system.MacAddress)
            );
            
            // Add changes to repository
            unitOfWork.SystemRepository.Add(system);

            // Complete changes
            unitOfWork.Complete();

            return _system;
        }

        public SoftwareDTO AddSoftwareToSystem(SoftwareDTO _software, string _systemId)
        {
            // Create new domain model
            SoftwareEntity software = new SoftwareEntity(
                new SoftwareName(_software.Name),
                new SoftwareVersion(_software.Version),
                new SoftwareManufacturer(_software.Manufacturer),
                new Guid(_systemId)
            );

            unitOfWork.SoftwareRepository.Add(software);
            unitOfWork.Complete();

            return _software;
        }

        public void DeleteSoftware(SoftwareDTO _software)
        {
            /*
            SoftwareEntity software = new SoftwareEntity(
                new Guid(_software.Id),
                new SoftwareName(_software.Name),
                new SoftwareVersion(_software.Version),
                new SoftwareManufacturer(_software.Manufacturer)
            );

            unitOfWork.SoftwareRepository.Remove(software);
            unitOfWork.Complete();
            */
        }

        public void DeleteSystem(SystemDTO _system)
        {
            SystemEntity system = new SystemEntity(
                new Guid(_system.Id),
                new SystemName(_system.Name),
                new IpAddress(_system.IpAddress),
                new MacAddress(_system.MacAddress)
            );

            unitOfWork.SystemRepository.Remove(system);
            unitOfWork.Complete();
        }
    }
}