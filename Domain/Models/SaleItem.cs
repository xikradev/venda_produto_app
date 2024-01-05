using Domain.Interfaces;
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
    public class SaleItem : ISelfValidation
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        [NotMapped]
        public bool IsValid
        {
            get
            {
                var validator = new SaleItemValidator();
                this.ValidationResult = validator.Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
