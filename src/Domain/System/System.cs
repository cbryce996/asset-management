using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Domain.System.ValueObjects;

namespace AssetManagement.Domain.System
{
    public class System
    {
        public SystemId Id { get; set; }
        public IpAddress Ip { get; set; }
        public MacAddress Mac { get; set; }
    }
}