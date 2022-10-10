using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project_cbryce996.Models.ViewModels.AssetViewModels;

namespace project_cbryce996.Models.ViewModels
{
    public class ManageAssetViewModel
    {
        public ListAssetsViewModel ListViewModel { get; set; }
        public CreateAssetViewModel CreateViewModel { get; set; }
    }
}