using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Domain.User
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}