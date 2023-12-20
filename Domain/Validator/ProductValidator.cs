using Domain.Models;
using Domain.Validator.Messages;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(x => x.ProductId).NotEmpty().WithMessage(ProductMessage.ProductId);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithMessage(ProductMessage.Name);
            RuleFor(x => x.Price).LessThan(100000000).NotNull().WithMessage(ProductMessage.Price);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(500).WithMessage(ProductMessage.Description);
            RuleFor(x => x.Quantity_in_stock).LessThan(100000000).NotNull().WithMessage(ProductMessage.Quantity_in_stock);
        }
    }
}
