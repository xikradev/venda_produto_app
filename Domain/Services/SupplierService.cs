﻿using Domain.DTO.Viwers;
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
    public class SupplierService : Service<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public SupplierWithAllProductsViwer FindSupplierWithProducts(int id)
        {
            return _repository.FindSupplierWithProducts(id);
        }
    }
}
