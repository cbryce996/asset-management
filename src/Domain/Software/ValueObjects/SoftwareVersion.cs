using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Software.ValueObjects
{
    public class SoftwareVersion
    {
        public string Version { get; set; }

        public SoftwareVersion()
        {
            
        }

        public SoftwareVersion(string _Version)
        {
            Version = _Version;
        }
    }
}