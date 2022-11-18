using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Domain.System.ValueObjects;

using Xunit;

namespace AssetManagement.Domain.Unit.System.ValueObjects
{
    public class IpAddressTest
    {
        private readonly IpAddress _sut;

        public IpAddressTest()
        {
            _sut = new IpAddress();
        }

        [Fact]
        public void AddTwoNumbers()
        {
            Assert.Equal(3, 2+1);
        }
    }
}