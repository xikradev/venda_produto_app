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

        [HttpPost("createuser")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] RegisterModel model)
        {
            if(model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "As Senhas não conferem");
                return BadRequest(ModelState);
            }

            User user = new User {
                UserName = "aaaa111",
                FullName = model.Fullname,
                Email = model.Email,
                BirthDate = model.BirthDate,
                CPF = model.CPF,
                Gender = model.Gender
            };  

            var result = await _authenticate.RegisterUser(user, model.Password, model.Role);

            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
