using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    public class SystemViewModel
    {   
        public string SystemId { get; set; }
        public string SystemName { get; set; }
        public string IpAddress { get; set; }
        public string MacAddress { get; set; }
    }
}