using Domain.DTO.Create;
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
        Task<bool> Authenticate(string email, string password);
        Task<UserException> RegisterUser(User user, string password, string role);
        Task Logout();
    }
}
