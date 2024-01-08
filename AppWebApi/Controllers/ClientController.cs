using App.AppService;
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
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientAppService _appService;
        private readonly IAddressAppService _addressAppService;
        private IMapper _mapper;

        public ClientController(IClientAppService appService, IMapper mapper, IAddressAppService addressAppService)
        {
            _appService = appService;
            _mapper = mapper;
            _addressAppService = addressAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstClient = _appService.GetAll();
            if(lstClient.Count() == 0)
            {
                return NotFound("No Client data was found in the list");
            }
            var Resultlst = _mapper.Map<List<ReadClientDto>>(lstClient).OrderBy(x => x.Id).ToList();
            return Ok(Resultlst);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Client client = _appService.Find(id);
            if(client == null)
            {
                return NotFound($"Client with ID {id} not found");
            }

            ReadClientDto result = _mapper.Map<ReadClientDto>(client);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateClientDto clientDto)
        {
            try
            {
                Client client = _mapper.Map<Client>(clientDto);
                var address = new Address()
                {
                    Street = clientDto.Street,
                    City = clientDto.City,
                    UF = clientDto.UF,
                    CEP = clientDto.CEP,
                    Number = clientDto.Number,
                    Complement = clientDto.Complement
                };
                var addressResponse = _addressAppService.Add(address);
                if (addressResponse.IsValid)
                {
                    client.AddressId = address.Id;
                    ValidationResult result = _appService.Add(client);
                    if (result.IsValid)
                    {
                        return Ok("Client added successfully.");
                    }
                    else
                    {
                        return BadRequest(result.Errors);
                    }
                }
                else
                {
                    return BadRequest(addressResponse.Errors);
                }

                

            }catch(Exception ex)
            {
                Console.WriteLine($"An exception ocurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateClientDto clientDto)
        {
            try
            {
                Client existingClient = _appService.Find(id);
                if(existingClient == null)
                {
                    return NotFound($"Client with ID {id} not found");
                }
                _mapper.Map(clientDto, existingClient);

                ValidationResult result = _appService.Update(existingClient);
                if(result.IsValid)
                {
                    return Ok("Client updated successfully.");
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Client client = _appService.Find(id); 
            if(client == null) 
            { 
                return NotFound($"Client with ID {id} not found");
            }
            _appService.Remove(client);

            return NoContent();
        }
    }
}
