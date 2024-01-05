using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity_Users
{
    public class User : IdentityUser<String>
    {
        public User() : base()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string FullName { get; set; }
        public string CPF { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public virtual ICollection<UserClaims> UserClaims { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }

    }
}
