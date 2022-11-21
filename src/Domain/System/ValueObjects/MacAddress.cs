using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.System.ValueObjects
{
    public class MacAddress
    {
        public string Mac { get; set; }
        public MacAddress(string _Mac)
        {
            Mac = _Mac;
        }
    }
}