using Domain.Interfaces;
using Domain.Models.Identity_Users;
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
    public class Address : ISelfValidation
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public string CEP { get; set; }
        public int? Number { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
        [NotMapped]
        public ValidationResult ValidationResult {  get; set; }
        [NotMapped]
        public bool IsValid
        {
            get
            {
                var validator = new AddressValidator();
                this.ValidationResult = validator.Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
