using Domain.Models.Identity_Users;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Read
{
    public class ReadSaleDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Seller { get; set; }
        public int ClientId { get; set; }
        public string Client { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }
    }
}
