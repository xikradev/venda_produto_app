using App.AppService._Base;
using App.Interfaces;
using Domain.DTO.Viwers;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services._Base;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AppService
{
    public class ProductAppService : AppService<Product>, IProductAppService
    {
        private readonly IProductService _service;

        public ProductAppService(IProductService service) : base(service)
        {
            _service = service;
        }

        public ProductsWithAllSupplierViewer FindProductWithSuppliers(int id)
        {
            return _service.FindProductWithSuppliers(id);
        }
    }
}
