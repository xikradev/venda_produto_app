using Domain.DTO.Create;
using Domain.Interfaces.Services;
using Domain.Models.Identity_Users;
using Domain.ModelsException;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Roles> _roleManager;

        public AuthenticateService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Roles> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public Task Logout()
        {
            return _signInManager.SignOutAsync();
        }

        public async Task<UserException> RegisterUser(User user, string password, string role)
        {
            UserException response = new UserException();

            var userExist = await _userManager.FindByEmailAsync(user.Email);
            if (userExist != null)
            {
                response.Succeeded = false;
                response.StatusCode = 403;
                response.Message = "There is already a user registered with this email, please enter another one.";
                return response;
            }

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    response.Succeeded = false;
                    response.StatusCode = 500;
                    response.Message = "User Failed to Create.";
                    return response;
                }
                await _userManager.AddToRoleAsync(user, role);
                response.Succeeded = true;
                response.StatusCode = 200;
                response.Message = "User Created Successfully.";
                return response;
            }
            else
            {
                response.Succeeded = false;
                response.StatusCode = 400;
                response.Message = "this role does not exist.";
                return response;
            }
            
        }
    }
}
