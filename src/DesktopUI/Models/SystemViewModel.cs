using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.DesktopUI.Models
{
    public class SystemViewModel
    {   
        public string SystemId { get; set; }
        [Required(ErrorMessage = "System Name is required!")]
        public string SystemName { get; set; }
        [Required(ErrorMessage = "Ip Address is required!")]
        public string IpAddress { get; set; }
        [Required(ErrorMessage = "Mac Address is required!")]
        public string MacAddress { get; set; }
    }
}