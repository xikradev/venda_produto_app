using Domain.Models;
using Domain.Validator.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validator
{
    public class ProductSupplierValidator : AbstractValidator<ProductSupplier>
    {
        public ProductSupplierValidator()
        {
            RuleFor(ps => ps.ProductId).NotNull().NotEmpty().WithMessage(ProductSupplierMessage.ProductId);
            RuleFor(ps => ps.SupplierId).NotNull().NotEmpty().WithMessage(ProductSupplierMessage.SupplierId);
        }
    }
}
