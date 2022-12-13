using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    [Serializable]
    public class CveViewModel
    {
        public string id { get; set; }
        public string sourceIdentifier { get; set; }
        public string published { get; set; }
        public string lastModified { get; set; }
    }
}