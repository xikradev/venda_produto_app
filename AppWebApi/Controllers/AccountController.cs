using App.Interfaces;
using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models.Identity_Users;
using Microsoft.AspNetCore.Mvc;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticateAppService _authenticate;
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper, IAuthenticateAppService authenticate, IConfiguration config)
        {
            _mapper = mapper;
            _authenticate = authenticate;
            _config = config;
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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authenticate.RegisterUser(userRegister);
            if (result.Success)
            {
                return Ok(result);
            }else if (result.Errors.Count >0)
            {
                return BadRequest(result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
