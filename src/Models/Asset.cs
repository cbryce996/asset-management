using System;
using System.ComponentModel.DataAnnotations;

namespace project_cbryce996.Models
{
    public class Asset
    {
        public Guid Id { get; set; }
        // Computer system name 
        public string CName { get; set; }
        // Computer system model
        public string CModel { get; set; }
        // Computer system manufactuter
        public string CManufacturer { get; set; }
        // Computer system type (CPU arch)
        public string CType { get; set; }
        // Operating System name
        public string OSName { get; set; }
        // Operating System version
        public string OSVersion { get; set; }
        // Operating System arch
        public string OSArch { get; set; }
        // Computers IP address
        public string IPAddress { get; set; }
        // Computers MAC address
        public string MACAddress { get; set; }
    }
}