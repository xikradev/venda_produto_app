using App.Interfaces;
using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;
using Domain.Models.Identity_Users;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleAppService _appService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public SaleController(ISaleAppService service, IMapper mapper, UserManager<User> userManager)
        {
            _appService = service;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateSaleDto saleDto)
        {
            try
            {
                Sale sale = _mapper.Map<Sale>(saleDto);
                sale.UserId = _userManager.GetUserId(User);
                ValidationResult result = _appService.Add(sale);
                if (result.IsValid)
                {
                    return Ok("Sale added successfuly.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"An exception ocurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            var lstSale = _appService.GetAll();
            if(lstSale.Count() == 0)
            {
                return NotFound("No sale data was found in the list.");
            }
            var response = _mapper.Map<List<ReadSaleDto>>(lstSale).OrderBy(x => x.Id).ToList();
            return Ok(response);
        }
    }
}
