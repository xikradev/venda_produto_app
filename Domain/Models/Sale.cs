using Domain.Interfaces;
using Domain.Models.Identity_Users;
using Domain.Validator;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sale : ISelfValidation
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        [NotMapped]
        public bool IsValid
        {
            get
            {
                var validator = new SaleValidator();
                this.ValidationResult = validator.Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
