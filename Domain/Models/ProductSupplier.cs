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
    public class ProductSupplier : ISelfValidation
    {
        public int Id { get; set; } 
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        [NotMapped]
        public bool IsValid
        {
            get
            {
                var validator = new ProductSupplierValidator();
                this.ValidationResult = validator.Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
