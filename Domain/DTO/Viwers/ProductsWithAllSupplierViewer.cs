using Domain.DTO.Read;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Viwers
{
    public class ProductsWithAllSupplierViewer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Quantity_in_stock { get; set; }
        public ICollection<ReadSupplierDto> Suppliers { get; set; }
    }
}
