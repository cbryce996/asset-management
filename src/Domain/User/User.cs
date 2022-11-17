using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Domain.User.ValueObjects;

namespace AssetManagement.Domain.User
{
    public class User
    {
        public UserId MyProperty { get; set; }
        public string Username { get; set; }
    }
}