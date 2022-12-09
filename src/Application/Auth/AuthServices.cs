using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Application.Auth.DTOs;
using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Domain.User;
using AutoMapper;

namespace AssetManagement.Application.Auth
{
    public class AuthServices
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthServices(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        /* TODO: Better handling of null response */
        public async Task<UserDTO> CheckIfUserExists(UserDTO _user)
        {
            UserEntity user = unitOfWork.UserRepository.GetEntity(new UserEntity(
                _user.Username,
                _user.Password
            ));

            if (user.Username != null && user.Password != null)
            {
                return new UserDTO(){
                    Id = user.Id.ToString(),
                    Username = user.Username,
                    Password = user.Password
                };
            }

            return new UserDTO();
        }
    }
}