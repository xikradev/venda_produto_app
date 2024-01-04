using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Read
{
    public class UserRegisterResponse
    {
        public bool Success { get; private set; }
        public List<string> Errors { get; private set; }

        public UserRegisterResponse() => Errors = new List<string>();

        public UserRegisterResponse(bool success = true) : this() { Success = success; }

        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);
        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
