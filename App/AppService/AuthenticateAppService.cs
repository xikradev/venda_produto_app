using App.Interfaces;
using Domain.DTO.Create;
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

        public Task<bool> Authenticate(string email, string password)
        {
            return _authenticateService.Authenticate(email, password);
        }

        public Task Logout()
        {
            return _authenticateService.Logout();
        }

        public Task<UserException> RegisterUser(User user, string password, string role)
        {
            return _authenticateService.RegisterUser(user, password, role);
        }
    }
}
