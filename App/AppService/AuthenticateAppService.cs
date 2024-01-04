using App.Interfaces;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Interfaces.Services;
using Domain.Models.Identity_Users;
using Domain.ModelsException;
using Microsoft.AspNetCore.Identity;

namespace App.AppService
{
    public class AuthenticateAppService : IAuthenticateAppService
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateAppService(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public async Task<UserLoginResponse> Authenticate(UserLoginRequest userLogin)
        {
            return await _authenticateService.Authenticate(userLogin);
        }

        public Task Logout()
        {
            return _authenticateService.Logout();
        }

        public Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister)
        {
            return _authenticateService.RegisterUser(userRegister);
        }
    }
}
