using Domain.DTO.Viwers;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Repository._Base;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ProductsWithAllSupplierViewer FindProductWithSuppliers(int id)
        {
            return _repository.FindProductWithSuppliers(id);
        }
    }
}
