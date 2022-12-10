using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Domain.System;
using AssetManagement.Domain.System.ValueObjects;
using Xunit;

namespace AssetManagement.Tests.Domain.Unit.System
{
    public class SystemTest
    {
        // System is an Entity, it's value should
        // be tested on creation and the methods
        // which operate on on those values
        // Expected Domain Behaviors:
        // [x] - Software can be added to a software collection
        // [x] - Software can be removed from a software collection
        // [x] - Duplicate software adds are rejected

        public SystemTest()
        {
            
        }

        [Fact]
        public void SoftwareAddedToSystem()
        {
            // Prepare test variables
            Software software = Software.Create("Name", "Version", "Manufacturer");
            SystemEntity system = new SystemEntity(new SystemName("name"), IpAddress.Create("192.168.0.1"), MacAddress.Create("00:00:5e:00:53:af"));

            // Execute test action
            system.AddSoftware(software);

            // Assert test expectations
            Assert.True(system.InstalledSoftware.Contains(software), "Software was not added to system software collection");
        }

        [Fact]
        public void SoftwareRemovedFromSystem()
        {
            // Prepare test variables
            Software software = Software.Create("Name", "Version", "Manufacturer");
            SystemEntity system = new SystemEntity(new SystemName("name"), IpAddress.Create("192.168.0.1"), MacAddress.Create("00:00:5e:00:53:af"));

            // Execute test action
            system.AddSoftware(software);
            system.RemoveSoftware(software);

            // Assert test expectations
            Assert.True(!system.InstalledSoftware.Contains(software), "Software was not removed from system software collectin");
        }

        [Fact]
        public void RejectDuplicateAddSoftware()
        {
            // Prepare test variables
            Software software = Software.Create("Name", "Version", "Manufacturer");
            SystemEntity system = new SystemEntity(new SystemName("name"), IpAddress.Create("192.168.0.1"), MacAddress.Create("00:00:5e:00:53:af"));

            // Execute test action
            system.AddSoftware(software);

            // Assert test expectations
            Assert.True(!system.AddSoftware(software), "Should not be able to add duplicate software to system software collection");
        }
    }
}