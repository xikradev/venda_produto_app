using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Create
{
    public class CreateAddressDto
    {
        public string Street { get; set; }
        public string Complement { get; set; }
        public string CEP { get; set; }
        public int? Number { get; set; }
        public string UF { get; set; }
        public string City { get; set; }
    }
}
