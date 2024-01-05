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
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(s => s.Quantity).NotEmpty().LessThan(50).WithMessage(SaleItemMessage.Quantity);
        }
    }
}
