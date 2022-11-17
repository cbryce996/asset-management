using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Domain.Software.ValueObjects;
using AssetManagement.Domain.System.ValueObjects;

namespace AssetManagement.Domain.Install
{
    public class Install
    {
        public SystemId SystemId { get; set; }
        public SoftwareId SoftwareId { get; set; }
    }
}