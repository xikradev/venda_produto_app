using App.Interfaces;
using AutoMapper;
using Domain.DTO.Create;
using Domain.DTO.Read;
using Domain.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _appService;
        private IMapper _mapper;

        public ProductController(IMapper mapper, IProductAppService appService)
        {
            _mapper = mapper;
            _appService = appService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var lstProduct = _appService.GetAll();
            if (lstProduct.Count() == 0)
                return NotFound("No Product data was found in the list.");
            var oProduct = _mapper.Map<List<ReadProductDto>>(lstProduct).OrderBy(x => x.Id).ToList();
            return Ok(oProduct);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _appService.Find(id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            ReadProductDto result = _mapper.Map<ReadProductDto>(product);

            return Ok(result);
        }

        [HttpGet("{id}/suppliers")]
        public IActionResult GetProductsWithSuppliers(int id) 
        { 
            var product = _appService.FindProductWithSuppliers(id);
            if(product == null)
            {
                return NotFound($"Product with ID {id} not found");
            }
            return Ok(product);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);
                ValidationResult result = _appService.Add(product);

                if (result.IsValid)
                {
                    return Ok("Product added successfully.");
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
        public IActionResult Update(int id, [FromBody] CreateProductDto productDto)
        {
            try
            {
                Product existingProduct = _appService.Find(id);

                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {id} not found.");
                }

                _mapper.Map(productDto, existingProduct);

                ValidationResult result = _appService.Update(existingProduct);

                if (result.IsValid)
                {
                    return Ok("Product updated successfully.");
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
            Product product = _appService.Find(id);

            if (product == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            ValidationResult result = _appService.Remove(product);

            return NoContent();
        }
    }
}
