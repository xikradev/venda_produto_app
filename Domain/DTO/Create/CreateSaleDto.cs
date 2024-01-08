using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTO.Create
{
    public class CreateSaleDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int ClientId { get; set; }
        [JsonIgnore]
        public decimal TotalPrice { get; set; } = 0;
        [JsonIgnore]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [EnumDataType(typeof(PaymentMethodEnum),ErrorMessage = "A propriedade Payment method deve ser dinheiro, pix, cartao_debito, cartao_credito")]
        public string PaymentMethod { get; set; }
    }
}
