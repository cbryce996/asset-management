using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Domain.System.ValueObjects;
using Xunit;

namespace AssetManagement.Domain.Unit.System.ValueObjects
{
    // MacAddress is an immutable ValueObject, it's value
    // should be tested on creation
    // Expected Domain Behaviors:
    // [x] - Is in valid format (x:x:x:x:x:x)
    public class MacAddressTest
    {
        public MacAddressTest()
        {
        }

        [Fact]
        public void ValidFormat()
        {
            // Prepare test variables
            MacAddress test = MacAddress.Create("a0:b4:aB");

            // Execute test action
            string[] slice = test.Mac.Split(":");

            // Assert test expectations
            Assert.True(slice.Length == 5, "Should not be able to create Mac Address with invalid format (Example: a0:b4:aB)");
        }   
    }
}