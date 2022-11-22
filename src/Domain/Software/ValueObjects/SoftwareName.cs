using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.Software.ValueObjects
{
    public class SoftwareName
    {
        public string Name { get; set; }

        public SoftwareName()
        {
            
        }

        public SoftwareName(string _Name)
        {
            Name = _Name;
        }
    }
}