using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Domain.Software.ValueObjects;

namespace AssetManagement.Domain.Software
{
    public class SoftwareEntity
    {
        public Guid Id { get; set; }
        public SoftwareName Name { get; set; }
        public SoftwareVersion Version { get; set; }

        public SoftwareManufacturer Manufacturer { get; set; }

        public SoftwareEntity()
        {
            
        }

         public SoftwareEntity(Guid _Id, SoftwareName _Name, SoftwareVersion _Version, SoftwareManufacturer _Manufacturer)
        {
            Id = _Id;
            Name = _Name;
            Version = _Version;
            Manufacturer = _Manufacturer;
        }

        public SoftwareEntity(SoftwareName _Name, SoftwareVersion _Version, SoftwareManufacturer _Manufacturer)
        {
            Id = new Guid();
            Name = _Name;
            Version = _Version;
            Manufacturer = _Manufacturer;
        }
    }
}