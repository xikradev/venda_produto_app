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
    public class AddressValidator : AbstractValidator<Address>
    {

        public AddressValidator()
        {
            RuleFor(x => x.Street).NotEmpty().MaximumLength(100).WithMessage(AddressMessage.Street);
            RuleFor(x => x.Complement).NotEmpty().MaximumLength(150).WithMessage(AddressMessage.Complement);
            RuleFor(x => x.CEP).NotEmpty().MaximumLength(9).WithMessage(AddressMessage.CEP);
            RuleFor(x => x.UF).NotEmpty().MaximumLength(2).WithMessage(AddressMessage.UF);
            RuleFor(x => x.City).NotEmpty().MaximumLength(80).WithMessage(AddressMessage.City);
        }
    }
}
