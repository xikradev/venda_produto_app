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
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Fullname).NotEmpty().MaximumLength(150).WithMessage(ClientMessage.Fullname);
            RuleFor(c => c.Email).NotEmpty().MaximumLength(80).EmailAddress().WithMessage(ClientMessage.Email);
            RuleFor(c => c.Register).NotEmpty().MaximumLength(18).Must(BeCpfOrCnpj).WithMessage(ClientMessage.Register);
            RuleFor(c => c.AddressId).NotNull().WithMessage(ClientMessage.AddressId);
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
