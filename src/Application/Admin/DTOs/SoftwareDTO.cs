using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Application.Admin.DTOs
{
    public class SoftwareDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Manufacturer { get; set; }
    }
}