using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTO.Create
{
    public class UserRegisterRequest
    {
        [Required]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de Email Inválido")]
        public string Email {  get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Senhas não conferem.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Digite um CPF válido.")]
        public string CPF { get; set; }
        [Required]
        public string Gender { get; set; }

        [JsonIgnore]
        public int AddressId { get; set; }

        [Required]
        public string Role { get; set; }

        public string Street { get; set; }
        public string Complement { get; set; }
        public string CEP { get; set; }
        public int? Number { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
    }
}
