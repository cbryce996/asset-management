using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.Application.Common.Interfaces;
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

        public async Task<IEnumerable<SystemDTO>> GetAllSystems()
        {
            IList<SystemEntity> systemEntities = new List<SystemEntity>();
            IList<SystemDTO> systemDTOs = new List<SystemDTO>();

            await foreach (SystemEntity system in unitOfWork.SystemRepository.All())
            {
                systemEntities.Add(system);
            }

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

        public async Task<SystemDTO> GetSystemById(string _systemId)
        {
            SystemEntity system = await unitOfWork.SystemRepository.Get(new Guid(_systemId));
            SystemDTO systemDTO = new SystemDTO() {
                Id = system.Id.ToString(),
                Name = system.Name.Name,
                IpAddress = system.Ip.Ip,
                MacAddress = system.Mac.Mac
            };
            
            return systemDTO;
        }

        public async  Task<SystemDTO> AddSystem(SystemDTO _system)
        {
            // Create new domain model
            SystemEntity system = new SystemEntity(
                new SystemName(_system.Name),
                IpAddress.Create(_system.IpAddress),
                MacAddress.Create(_system.MacAddress)
            );
            
            // Add changes to repository
            await unitOfWork.SystemRepository.Add(system);

            // Complete changes
            await unitOfWork.Complete();

            return _system;
        }

        public async Task<SoftwareDTO> AddSoftwareToSystem(SoftwareDTO _software, string _systemId)
        {
            SystemEntity system = await unitOfWork.SystemRepository.Get(new Guid(_systemId));
            
            system.AddSoftware(
                Software.Create(
                    _software.Name,
                    _software.Version,
                    _software.Manufacturer
                    )
                );

            await unitOfWork.Complete();

            return _software;
        }

        public async Task<IList<SoftwareDTO>> AddMultipleSoftwareToSystem(IList<SoftwareDTO> _softwareDTOs, string _systemId)
        {
            SystemEntity system = await unitOfWork.SystemRepository.Get(new Guid(_systemId));

            foreach (var software in _softwareDTOs)
            {
                system.AddSoftware(
                Software.Create(
                    software.Name,
                    software.Version,
                    software.Manufacturer
                    )
                );
            }

            await unitOfWork.Complete();
             
            return _softwareDTOs;
        }

        public async Task<IList<SoftwareDTO>> GetSoftwareOnSystem(string _systemId)
        {
            SystemEntity system = await unitOfWork.SystemRepository.Get(new Guid(_systemId));
            IList<SoftwareDTO> softwareDTOs = new List<SoftwareDTO>();

            foreach (var software in system.InstalledSoftware)
            {
                softwareDTOs.Add(
                    new SoftwareDTO() {
                        Name = software.Name,
                        Version = software.Version,
                        Manufacturer = software.Manufacturer
                    }
                );
            }

            return softwareDTOs;
        }

        public async Task DeleteSoftware(SoftwareDTO _software, string _systemId)
        {
            SystemEntity system = await unitOfWork.SystemRepository.Get(new Guid(_systemId));

            Software software = Software.Create(
                _software.Name, _software.Version, _software.Manufacturer
            );

            system.RemoveSoftware(software);
            unitOfWork.SystemRepository.Update(system);
            await unitOfWork.Complete();
        }

        public async Task<SystemDTO> EditSystemInformation(SystemDTO _system, string _systemId)
        {
            SystemEntity system = await unitOfWork.SystemRepository.Get(new Guid(_systemId));

            system.Ip = IpAddress.Create(_system.IpAddress);
            system.Mac = MacAddress.Create(_system.MacAddress);
            system.Name = new SystemName(_system.Name);

            unitOfWork.SystemRepository.Update(system);
            await unitOfWork.Complete();

            return _system;
        }

        public async Task<bool> DeleteSystem(string _systemId)
        {
            SystemEntity system = await unitOfWork.SystemRepository.Get(new Guid(_systemId));

            unitOfWork.SystemRepository.Remove(system);
            return await unitOfWork.Complete();
        }
    }
}