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
    public class ProductSupplierController : ControllerBase
    {
        private readonly IProductSupplierAppService _service;
        private IMapper _mapper;

        public ProductSupplierController(IMapper mapper, IProductSupplierAppService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lstProdSup = _service.GetAll();
            if(lstProdSup.Count() == 0)
            {
                return NotFound("No ProductSupplier data was found in the list");
            }
            var result = _mapper.Map<List<ReadProductSupplierDto>>(lstProdSup).OrderBy(ps => ps.Id).ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ProductSupplier prodSup = _service.Find(id);
            if(prodSup == null)
            {
                return NotFound($"ProductSupplier with ID {id} not found");
            }
            ReadProductSupplierDto result = _mapper.Map<ReadProductSupplierDto>(prodSup);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductSupplierDto prodSupDto)
        {
            try
            {
                ProductSupplier prodSup = _mapper.Map<ProductSupplier>(prodSupDto);
                ValidationResult result = _service.Add(prodSup);
                if (result.IsValid)
                {
                    return Ok("ProductSupplier added successfully.");
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex) {
                Console.WriteLine($"An exception ocurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreateProductSupplierDto prodSupDto)
        {
            try
            {
                ProductSupplier prodSup = _service.Find(id);
                if(prodSup == null)
                {
                    return NotFound($"ProductSupplier with ID {id} not found");
                }
                _mapper.Map(prodSupDto, prodSup);
                ValidationResult result = _service.Update(prodSup);
                if (result.IsValid)
                {
                    return Ok("ProductSupplier updated successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"An exception ocurred: {ex.Message}");
                return StatusCode(500, "An internal error occurred while processing the request.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            ProductSupplier prodSup = _service.Find(id);
            if(prodSup == null)
            {
                return NotFound($"ProductSupplier with ID {id} not found");
            }
            _service.Remove(prodSup);
            return NoContent();
        }
    }
}
