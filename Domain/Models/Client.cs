using Domain.Interfaces;
using Domain.Validator;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Client : ISelfValidation
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Register { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? OpeningData { get; set; }
        public string? Gender { get; set; }
        public string? BussisnesArea { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }
        [NotMapped]
        public bool IsValid
        {
            get
            {
                var validator = new ClientValidator();
                this.ValidationResult = validator.Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
