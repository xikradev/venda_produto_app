using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Read
{
    public class ReadProductSupplierDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ReadProductDto Product { get; set; }
        public int SupplierId { get; set; }
        public ReadSupplierDto Supplier { get; set; }
    }
}
