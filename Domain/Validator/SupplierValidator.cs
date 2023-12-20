using CpfCnpjLibrary;
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
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(s => s.Fullname).NotEmpty().MaximumLength(150).WithMessage(ClientMessage.Fullname);
            RuleFor(s => s.Email).NotEmpty().MaximumLength(80).EmailAddress().WithMessage(ClientMessage.Email);
            RuleFor(s => s.Register).NotEmpty().MaximumLength(18).Must(BeCpfOrCnpj).WithMessage(ClientMessage.Register);
            RuleFor(s => s.AddressId).NotNull().WithMessage(ClientMessage.AddressId);
        }

        private bool BeCpfOrCnpj(string register)
        {
            if (Cpf.Validar(register))
            {
                return true;
            }
            else if (Cnpj.Validar(register))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
