using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    public class IndexViewModel
    {
        public IList<SoftwareViewModel> Software { get; set; }
        public IList<SystemViewModel> Systems { get; set; }

        public IndexViewModel()
        {
            Systems = new List<SystemViewModel>();
            Software = new List<SoftwareViewModel>();
        }
    }
}