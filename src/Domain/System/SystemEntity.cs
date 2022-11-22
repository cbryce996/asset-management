using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Domain.Software;
using AssetManagement.Domain.System.ValueObjects;

namespace AssetManagement.Domain.System
{
    public class SystemEntity
    {
        public Guid Id { get; set; }
        public IpAddress Ip { get; set; }
        public MacAddress Mac { get; set; }

        public IEnumerable<SoftwareEntity> InstalledSoftware { get; set; }

        public SystemEntity()
        {
            
        }

        public SystemEntity(IpAddress _Ip, MacAddress _Mac)
        {
            Id = new Guid();
            Ip = _Ip;
            Mac = _Mac;
        }

        public void AddSoftware(SoftwareEntity _Software)
        {
            InstalledSoftware.Append<SoftwareEntity>(_Software);
        }
    }
}