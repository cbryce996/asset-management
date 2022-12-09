using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.System.ValueObjects
{
    /*
    * MacAddress ValueObject implemented as an immutable object whos identity
    * is determined by its values.
    */

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

        /* Overrides the GetHashCode method, necessary for certain comparison operations */
        public override int GetHashCode() => new { Mac }.GetHashCode();

        /* Overrides the Equals operator to provide a comparison based on the value of the fields */
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            var other = (MacAddress)obj;
            return other.Mac == Mac;
        }
    }
}