using App.Interfaces;
using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize(Roles = "Admin")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressAppService _appService;
        private IMapper _mapper;

        public AddressController(IMapper mapper, IAddressAppService appService)
        {
            _mapper = mapper;
            _appService = appService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstAddress = _appService.GetAll();
            if (lstAddress.Count() == 0)
                return NotFound("No Address data was found in the list.");
            var Resultlst = _mapper.Map<List<ReadAddressDto>>(lstAddress).OrderBy(x => x.Id).ToList();
            return Ok(Resultlst);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Address address = _appService.Find(id);

            if (address == null)
            {
                return NotFound($"Address with ID {id} not found");
            }

            ReadAddressDto result = _mapper.Map<ReadAddressDto>(address);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateAddressDto addressDto)
        {
            try
            {
                Address address = _mapper.Map<Address>(addressDto);
                ValidationResult result = _appService.Add(address);

                if (result.IsValid)
                {
                    return Ok($"Address added successfully. id: {address.Id}");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");

                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateAddressDto addressDto)
        {
            try
            {
                Address existingAddress = _appService.Find(id);

                if (existingAddress == null)
                {
                    return NotFound($"Address with ID {id} not found.");
                }

                _mapper.Map(addressDto, existingAddress);

                ValidationResult result = _appService.Update(existingAddress);

                if (result.IsValid)
                {
                    return Ok("Address updated successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Address address = _appService.Find(id);

            if (address == null)
            {
                return NotFound($"Address with ID {id} not found");
            }

            _appService.Remove(address);

            return NoContent();
        }
    }
}
