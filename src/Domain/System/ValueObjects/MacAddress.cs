using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.System.ValueObjects
{
    public class MacAddress
    {
        public string Mac { get; private set; }

        public static MacAddress Create (string _Mac)
        {
            return new MacAddress(_Mac);
        }

        public static MacAddress Empty ()
        {
            return new MacAddress();
        }

        private MacAddress()
        {
        }

        private MacAddress(string _Mac)
        {
            Mac = _Mac;
        }

        public override int GetHashCode() => new { Mac }.GetHashCode();

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            var other = (MacAddress)obj;
            return other.Mac == Mac;
        }
    }
}