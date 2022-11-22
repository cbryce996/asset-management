using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.DesktopUI.Models;

namespace AssetManagement.DesktopUI.Models
{
    public class NewSoftwareViewModel
    {
        public SystemViewModel System { get; set; }
        public SoftwareViewModel Software { get; set; }
    }
}