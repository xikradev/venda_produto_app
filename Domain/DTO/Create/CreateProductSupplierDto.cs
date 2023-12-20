using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Create
{
    public class CreateProductSupplierDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
