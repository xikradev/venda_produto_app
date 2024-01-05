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
    public class Product : ISelfValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public decimal Quantity_in_stock { get; set; }
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; }
        public virtual ICollection<SaleItem> SaleItems { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult {  get; set; }
        [NotMapped]
        public bool IsValid {
            get
            {
                var validator = new ProductValidator();
                this.ValidationResult = validator.Validate(this);

                return ValidationResult.IsValid;
            }
        }
    }
}
