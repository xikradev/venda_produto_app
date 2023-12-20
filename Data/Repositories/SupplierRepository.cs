using Data.Context.Interfaces;
using Data.Repositories._Base;
using Domain.DTO.Read;
using Domain.DTO.Viwers;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public SupplierWithAllProductsViwer FindSupplierWithProducts(int id)
        {
            var supplierDTO = Context.Set<Supplier>()
            .Where(s => s.Id == id)
            .Select(s => new SupplierWithAllProductsViwer
            {
                Id = s.Id,
                Fullname = s.Fullname,
                Email = s.Email,
                Register = s.Register,
                BirthDate = s.BirthDate,
                OpeningData = s.OpeningData,
                Gender = s.Gender,
                BussisnesArea = s.BussisnesArea,
                address = s.Address,
                products = s.ProductSuppliers.Select(ps => new ReadProductDto
                {
                    Id = ps.Product.Id,
                    Name = ps.Product.Name,
                    Price = ps.Product.Price,
                    Description = ps.Product.Description,
                    Quantity_in_stock = ps.Product.Quantity_in_stock,
                }).ToList()
            })
            .FirstOrDefault();

            return supplierDTO;
        }
    }
}
