using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.System.ValueObjects
{
    public class SystemName
    {
        public string Name { get; set; }
        public SystemName()
        {
        }
        public SystemName(string _Name)
        {
            Name = _Name;
        }
    }
}