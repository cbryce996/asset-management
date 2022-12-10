using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Enumeration;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Domain.System.ValueObjects;

namespace AssetManagement.Domain.System
{
    public class SystemEntity
    {
        public Guid Id { get; set; }
        public SystemName Name { get; set; }
        public IpAddress Ip { get; set; }
        public MacAddress Mac { get; set; }
        public IList<Software> InstalledSoftware { get; set; }

        public SystemEntity()
        {
            
        }

        public SystemEntity(Guid _Id, SystemName _Name, IpAddress _Ip, MacAddress _Mac)
        {
            Id = _Id;
            Name = _Name;
            Ip = _Ip;
            Mac = _Mac;
            InstalledSoftware = new List<Software>();
        }

        public SystemEntity(SystemName _Name, IpAddress _Ip, MacAddress _Mac)
        {
            Id = new Guid();
            Name = _Name;
            Ip = _Ip;
            Mac = _Mac;
            InstalledSoftware = new List<Software>();
        }

        public bool AddSoftware(Software _software)
        {
            if (!InstalledSoftware.Contains(_software))
            {
                InstalledSoftware.Add(_software);
                return true;
            }

            return false;
        }

        public void RemoveSoftware(Software _software)
        {
            InstalledSoftware.Remove(_software);
        }
    }
}