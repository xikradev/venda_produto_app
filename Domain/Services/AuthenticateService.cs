using Data.AuthConfig;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Interfaces.Services;
using Domain.Models.Identity_Users;
using Domain.ModelsException;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Roles> _roleManager;
        private readonly JwtOptions _jwtOptions;

        public AuthenticateService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Roles> roleManager, IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtOptions = jwtOptions.Value;
        }



        public Task Logout()
        {
            return _signInManager.SignOutAsync();
        }

        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister)
        {
            var response = new UserRegisterResponse(false);

            var user = new User()
            {
                UserName = userRegister.Email,
                FullName = userRegister.Fullname,
                Email = userRegister.Email,
                CPF = userRegister.CPF,
                BirthDate = userRegister.BirthDate,
                Gender = userRegister.Gender,
                AddressId = userRegister.AddressId
            };

            if (await _roleManager.RoleExistsAsync(userRegister.Role))
            {
                var result = await _userManager.CreateAsync(user, userRegister.Password);
                if (!result.Succeeded)
                {
                    response.AddErrors(result.Errors.Select(r => r.Description));
                    return response;

                }
                await _userManager.SetLockoutEnabledAsync(user, false);
                await _userManager.AddToRoleAsync(user, userRegister.Role);
                response = new UserRegisterResponse(true);
                return response;
            }
            else
            {
                response.AddError("this role does not exist.");
                return response;
            }
            
            
        }

        public async Task<UserLoginResponse> Authenticate(UserLoginRequest userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);
            if (result.Succeeded)
            {
                return await GenerateToken(userLogin.Email);
            }

            var response = new UserLoginResponse(result.Succeeded);
            if (result.Succeeded)
            {
                if (result.IsLockedOut)
                    response.AddError($"Locked out: {userLogin.Email}");
                else if (result.IsNotAllowed)
                    response.AddError("This account does not have permission to login.");
                else if (result.RequiresTwoFactor)
                    response.AddError($"TwoFactor Authentication required.");
                else
                    response.AddError("Email or password is incorrect");
            }

            return response;
        }

        private async Task<UserLoginResponse> GenerateToken(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            var tokenClaims = await GetClaims(user);
            var expirationDate = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken
            (
             issuer: _jwtOptions.Issuer,
             audience: _jwtOptions.Audience,
             claims: tokenClaims,
             notBefore: DateTime.Now,
             expires: expirationDate,
             signingCredentials: _jwtOptions.SigningCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new UserLoginResponse
            (
                success: true,
                token: token,
                expirationDate: expirationDate
            );
        }

        private async Task<IList<Claim>> GetClaims(User user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach(var role in roles)
            {
                claims.Add(new Claim("role", role));
            }
            return claims;
        }
    }
}
