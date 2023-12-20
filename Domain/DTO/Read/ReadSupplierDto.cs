using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Read
{
    public class ReadSupplierDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Register { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OpeningData {  get; set; }
        public string? Gender { get; set; }
        public string? BussisnesArea { get; set; }
        public ReadAddressDto address { get; set; }
    }
}
