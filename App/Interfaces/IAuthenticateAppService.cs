using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models.Identity_Users;
using Domain.ModelsException;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IAuthenticateAppService
    {
        Task<UserLoginResponse> Authenticate(UserLoginRequest userLogin);
        Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister);
        Task Logout();
    }
}
