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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierAppService _service;
        private IMapper _mapper;

        public SupplierController(IMapper mapper, ISupplierAppService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstSupplier = _service.GetAll();
            if (lstSupplier.Count() == 0)
            {
                return NotFound("No Supplier data was found in the list.");
            }
            var result = _mapper.Map<List<ReadSupplierDto>>(lstSupplier).OrderBy(s => s.Id).ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Supplier supplier = _service.Find(id);
            if (supplier == null)
            {
                return NotFound($"Supplier with ID {id} not found");
            }
            ReadSupplierDto result = _mapper.Map<ReadSupplierDto>(supplier);
            return Ok(result);
        }

        [HttpGet("{id}/products")]
        public IActionResult GetSupplierWithProducts(int id)
        {
            var supplier = _service.FindSupplierWithProducts(id);
            if(supplier == null)
            {
                return NotFound($"Supplier with ID {id} not found");
            }
            return Ok(supplier);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateSupplierDto supplierDto)
        {
            try
            {
                Supplier supplier = _mapper.Map<Supplier>(supplierDto);
                ValidationResult result = _service.Add(supplier);
                if (result.IsValid)
                {
                    return Ok("Supplier added successfully.");
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception ocurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateSupplierDto supplierDto)
        { 
            try
            {
                Supplier supplier = _service.Find(id);
                if (supplier == null)
                {
                    return NotFound($"Supplier with ID {id} not found");
                }
                _mapper.Map(supplierDto, supplier);
                ValidationResult result = _service.Update(supplier);
                if (result.IsValid)
                {
                    return Ok("Supplier updated successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception ocurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            Supplier supplier = _service.Find(id);
            if(supplier == null)
            {
                return NotFound($"Client with ID {id} not found");
            }

            _service.Remove(supplier);
            return NoContent();
        }
    }
}
