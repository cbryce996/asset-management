using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_cbryce996.Models.ViewModels.AssetViewModels
{
    public class CreateAssetViewModel
    {
        public string SystemName { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string Ip { get; set; }
    }
}