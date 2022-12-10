using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Domain.System.ValueObjects;
using FluentAssertions.Extensions;
using Newtonsoft.Json.Converters;
using Xunit;

namespace AssetManagement.Domain.Unit.System.ValueObjects
{
    // IpAddress is an immutable ValueObject, it's value
    // should be tested on creation
    // Expected Domain Behaviors:
    // [x] - Is in valid format (x.x.x.x)
    // [x] - In expected local range (192.168.x.x)
    // [x] - Is not too large
    public class IpAddressTest
    {
        public IpAddressTest()
        {
        }

        [Fact]
        public void ValidFormat()
        {
            // Prepare test variables
            IpAddress test = IpAddress.Create("192.168");

            // Execute test action
            string[] slice = test.Ip.Split(".");

            // Assert test expectations
            Assert.True(slice.Length == 4, "Should not be able to create IP with invalid format (Example: 192.158.0)");
        }

        [Fact]
        public void IsInLocalRange()
        {
            // Prepare test variables
            IpAddress test = IpAddress.Create("172.0.0.0");

            // Execute test action
            string[] slice = test.Ip.Split(".");
            
            // Assert test expectations
            Assert.True(slice[0] == "192", "Should not be able to create IP outside of local range (Allowed: 170.0.0.0)");
        }

        [Fact]
        public void IsCorrectSize()
        {
            // Prepare test variables
            IpAddress test = IpAddress.Create("192.168.1000.1000");

            // Execute test action
            string[] slice = test.Ip.Split(".");
            
            // Assert test expectations
            foreach (string s in slice)
            {
                Assert.True(s.Length <= 3, "Should not be able to create IP with invalid fields (Example: 192.168.1000.1000)");
            }
        }
    }
}