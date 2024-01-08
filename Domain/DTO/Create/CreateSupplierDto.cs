using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTO.Create
{
    public class CreateSupplierDto
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
        [JsonIgnore]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public string CEP { get; set; }
        public int? Number { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
    }
}
