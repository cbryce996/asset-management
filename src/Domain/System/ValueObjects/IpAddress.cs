using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.System.ValueObjects
{
    public class IpAddress
    {
        public string Ip { get; set; }

        public IpAddress()
        {
        }

        public IpAddress(string _Ip)
        {
            Ip = _Ip;
        }
    }
}