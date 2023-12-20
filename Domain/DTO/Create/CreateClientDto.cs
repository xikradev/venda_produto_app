using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Create
{
    public class CreateClientDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Register { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; } = null;
        [DataType(DataType.Date)]
        public DateTime? OpeningData { get; set; } = null;
        public string? Gender { get; set; } = null;
        public string? BussisnesArea { get; set; } = null;
        public int AddressId { get; set; }
    }
}
