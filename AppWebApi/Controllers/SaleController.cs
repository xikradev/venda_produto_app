using App.Interfaces;
using AutoMapper;
using Domain.DTO.Create;
using Domain.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleAppService _appService;
        private readonly IMapper _mapper;

        public SaleController(ISaleAppService service, IMapper mapper)
        {
            _appService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateSaleDto saleDto)
        {
            try
            {
                Sale sale = _mapper.Map<Sale>(saleDto);
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
    }
}
