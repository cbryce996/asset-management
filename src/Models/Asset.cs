using System;
using System.ComponentModel.DataAnnotations;

namespace project_cbryce996.Models
{
    public class Asset
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter a system name")]
        public string SystemName { get; set; }
        [Required(ErrorMessage = "Enter a model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Enter a manufacturer")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Enter a type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Enter an ip address")]
        public string Ip { get; set; }
    }
}