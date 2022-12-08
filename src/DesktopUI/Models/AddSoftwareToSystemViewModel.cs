using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.DesktopUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.DesktopUI.Models
{
    public class AddSoftwareToSystemViewModel
    {
        public SystemViewModel System { get; set; }
        public SoftwareViewModel Software { get; set; }
    }
}