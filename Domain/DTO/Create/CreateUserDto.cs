using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Create
{
    public class CreateUserDto
    {
        [Required]
        public string Fullname { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public string CPF { get; set; }

    }
}
