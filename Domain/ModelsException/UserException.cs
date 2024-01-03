using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelsException
{
    public class UserException
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public int StatusCode{ get; set; }

    }
}
