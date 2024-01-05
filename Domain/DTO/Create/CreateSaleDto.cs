using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Create
{
    class CreateSaleDto
    {
        public decimal TotalPrice { get; set; } = 0;
        public DateTime Date { get; set; } = DateTime.Now;
        public string PaymentMethod { get; set; }
    }
}
