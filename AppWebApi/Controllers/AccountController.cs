using App.Interfaces;
using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;
using Domain.Models.Identity_Users;
using Microsoft.AspNetCore.Mvc;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticateAppService _authenticate;
        private readonly IAddressAppService _addressAppService;

        public AccountController(IAuthenticateAppService authenticate, IAddressAppService addressAppService)
        {
            _authenticate = authenticate;
            _addressAppService = addressAppService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> Login([FromBody] UserLoginRequest userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authenticate.Authenticate(userLogin);
            if(result.Success)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserRegisterResponse>> CreateUser([FromBody] UserRegisterRequest userRegister)
        {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var address = new Address()
                {
                    Street = userRegister.Street,
                    City = userRegister.City,
                    UF = userRegister.UF,
                    CEP = userRegister.CEP,
                    Number = userRegister.Number,
                    Complement = userRegister.Complement
                };
                var addressResponse = _addressAppService.Add(address);
                if (addressResponse.IsValid)
                {
                userRegister.AddressId = address.Id;
                    var result = await _authenticate.RegisterUser(userRegister);

                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    else if (result.Errors.Count > 0)
                    {
                        return BadRequest(result);
                    }
                }
                else
                {
                    return BadRequest(addressResponse.Errors);
                }

                return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
