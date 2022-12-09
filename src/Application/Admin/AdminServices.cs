using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement.Application.Admin.DTOs;
using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Domain.System;
using AssetManagement.Domain.System.ValueObjects;

namespace AssetManagement.Application.Admin
{   
    /*
    * Provides business logic and interaction with data persistence, interacts with Domain layer
    * and provides interfaces for Infrastructure layer, Dependency Injected into DesktopUI
    */

    public class AdminServices
    {
        /* Local DI services */
        private readonly IUnitOfWork unitOfWork;

        /* Capture DI services */
        public AdminServices(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        /* Gets a list of all Systems from Repository and returns DTO collection */
        public async Task<IEnumerable<SystemDTO>> GetAllSystems()
        {
            // Create lists for Domain Models and DTOs
            IList<SystemEntity> systemEntities = new List<SystemEntity>();
            IList<SystemDTO> systemDTOs = new List<SystemDTO>();

            // Async get systems from repository
            await foreach (SystemEntity system in unitOfWork.SystemRepository.All())
            {
                systemEntities.Add(system);
            }


            // Map system entities to DTOs
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

        /* Gets a System from Repository by Id and returns DTO */
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

        /* Adds a System through Repository and returns added DTO */
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

        /* Adds Software to a System by Id and returns DTO of added Software */
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

        /* Adds a batch of Software to a System by id and returns DTO Collection of added Software */
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

        /* Gets Software on a System by Id and returns DTO collection */
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

        /* Deletes Software from System by Id */
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

        /* Edits System information and returns DTO of updated System */
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

        /* Deletes System and returns bool result */
        public async Task<bool> DeleteSystem(string _systemId)
        {
            SystemEntity system = await unitOfWork.SystemRepository.Get(new Guid(_systemId));

            unitOfWork.SystemRepository.Remove(system);
            return await unitOfWork.Complete();
        }
    }
}