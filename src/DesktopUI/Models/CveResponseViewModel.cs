using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.DesktopUI.Models
{
    [Serializable]
    public class CveResponseViewModel
    {
        public int resultsPerPage { get; set; }
        public int totalResults { get; set; }
        public string timestamp { get; set; }
        public IList<VulnerabilitiesViewModel> vulnerabilities { get; set; }
    }
}
