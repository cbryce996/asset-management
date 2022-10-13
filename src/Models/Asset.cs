using System;
using System.ComponentModel.DataAnnotations;

namespace project_cbryce996.Models
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string Os { get; set; }
        public string BiosName { get; set; }
        public string BiosVersion { get; set; }
        public string BiosVendor { get; set; }
        public string MbName { get; set; }
        public string MbVersion { get; set; }
        public string MbVendor { get; set; }
        public string CpuName { get; set; }
        public string CpuVendor { get; set; }
        public string CpuModel { get; set; }
        public string CpuArch { get; set; }
        public string GpuName { get; set; }
        public string GpuVendor { get; set; }
        public string GpuType { get; set; }
        public string SystemName { get; set; }
        public string Ip { get; set; }
    }
}