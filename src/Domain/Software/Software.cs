using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Domain.Software.ValueObjects;

namespace AssetManagement.Domain.Software
{
    public class SoftwareEntity
    {
        public SoftwareId Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }

        public string Manufacturer { get; set; }
    }
}