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
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            //RuleFor(s => s.PaymentMethod).NotEmpty().MaximumLength(80).NotNull().WithMessage(SaleMessage.PaymentMethod);
        }
    }
}
