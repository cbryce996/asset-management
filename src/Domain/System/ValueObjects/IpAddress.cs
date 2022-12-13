using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.System.ValueObjects
{
    public class IpAddress
    {
        public string Ip { get; private set; }

        public static IpAddress Create (string _Ip)
        {
            return new IpAddress(_Ip);
        }

        public static IpAddress Empty ()
        {
            return new IpAddress();
        }

        private IpAddress()
        {
        }

        private IpAddress(string _Ip)
        {
            Ip = _Ip;
        }

        public override int GetHashCode() => new { Ip }.GetHashCode();

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            var other = (IpAddress)obj;
            return other.Ip == Ip;
        }
    }
}