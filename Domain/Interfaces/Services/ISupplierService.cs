using Domain.DTO.Viwers;
using Domain.Interfaces.Services._Base;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ISupplierService : IService<Supplier>
    {
        public SupplierWithAllProductsViwer FindSupplierWithProducts(int id);
    }
}
