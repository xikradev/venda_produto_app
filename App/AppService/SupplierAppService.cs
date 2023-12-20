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
    public class SupplierAppService : AppService<Supplier>, ISupplierAppService
    {
        private readonly ISupplierService _service;

        public SupplierAppService(ISupplierService service) : base(service) 
        {
            _service = service;
        }

        public SupplierWithAllProductsViwer FindSupplierWithProducts(int id)
        {
            return _service.FindSupplierWithProducts(id);
        }
    }
}
