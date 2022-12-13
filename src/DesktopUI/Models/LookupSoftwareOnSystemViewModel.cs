using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    public class LookupSoftwareOnSystemViewModel
    {
        public SystemViewModel System { get; set; }
        public IEnumerable<SoftwareViewModel> Software { get; set; }
    }
}