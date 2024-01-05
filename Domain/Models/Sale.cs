using Domain.Interfaces;
using Domain.Models.Identity_Users;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sale 
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

       
    }
}
