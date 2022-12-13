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
        public string Password { get; set; }

        public UserEntity()
        {
            
        }

        public UserEntity(string _Username, string _Password)
        {
            Id = new Guid();
            Username = _Username;
            Password = _Password;
        }

        public UserEntity(Guid _Id, string _Username, string _Password)
        {
            Id = _Id;
            Username = _Username;
            Password = _Password;
        }
    }
}