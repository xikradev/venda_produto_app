using Data.Context.Interfaces;
using Data.Repositories._Base;
using Domain.DTO.Read;
using Domain.DTO.Viwers;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public ProductsWithAllSupplierViewer FindProductWithSuppliers(int id)
        {
            var productDTO = Context.Set<Product>()
                .Where(p => p.Id == id)
                .Select(p => new ProductsWithAllSupplierViewer
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Quantity_in_stock = p.Quantity_in_stock,
                    Suppliers = p.ProductSuppliers.Select(ps => new ReadSupplierDto
                    {
                        Id = ps.Supplier.Id,
                        Fullname = ps.Supplier.Fullname,
                        Email =ps.Supplier.Email,
                        Register = ps.Supplier.Register,
                        BirthDate = ps.Supplier.BirthDate,
                        OpeningData = ps.Supplier.OpeningData,
                        Gender = ps.Supplier.Gender,
                        BussisnesArea = ps.Supplier.BussisnesArea,
                        address = new ReadAddressDto
                        {
                            Id = ps.Supplier.Address.Id,
                            Street = ps.Supplier.Address.Street,
                            Complement = ps.Supplier.Address.Complement,
                            CEP = ps.Supplier.Address.CEP,
                            Number = ps.Supplier.Address.Number,
                            UF = ps.Supplier.Address.UF,
                            City = ps.Supplier.Address.City,
                        }
                    }).ToList()
                }).FirstOrDefault();
            return productDTO;
        }
    }
}
