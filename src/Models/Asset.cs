using System;

namespace project_cbryce996.Models
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string SystemName { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string Ip { get; set; }
    }
}