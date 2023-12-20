using App.Interfaces._Base;
using Domain.DTO.Viwers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Interfaces
{
    public interface IProductAppService : IAppService<Product>
    {
        public ProductsWithAllSupplierViewer FindProductWithSuppliers(int id);
    }
}
