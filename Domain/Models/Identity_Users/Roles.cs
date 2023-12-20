using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity_Users
{
    public class Roles : IdentityRole<String>
    {
        public Roles() : base(){ }

        public virtual ICollection<RolesClaims> RoleClaims { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
