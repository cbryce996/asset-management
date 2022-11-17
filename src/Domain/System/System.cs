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
        public IPAddress Ip { get; set; }
        public MACAddress Mac { get; set; }
    }
}