using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Software.ValueObjects
{
    public class SoftwareManufacturer
    {
        public string Manufacturer { get; set; }

        public SoftwareManufacturer()
        {
            
        }

        public SoftwareManufacturer(string _Manufacturer)
        {
            Manufacturer = _Manufacturer;
        }
    }
}