using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DesktopUI.Models
{
    public class SoftwareViewModel
    {
        public string SoftwareId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string SoftwareName { get; set; }
        [Required(ErrorMessage = "Version is required")]
        public string Version { get; set; }
        [Required(ErrorMessage = "Manufacturer is required")]
        public string Manufacturer { get; set; }
    }
}