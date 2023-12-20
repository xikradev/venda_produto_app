using Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sale : ISelfValidation
    {
        public int Id { get; set; }


        public ValidationResult ValidationResult => throw new NotImplementedException();

        public bool IsValid => throw new NotImplementedException();
    }
}
