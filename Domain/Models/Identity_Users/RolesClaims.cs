using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity_Users
{
    public class RolesClaims : IdentityRoleClaim<String>
    {
        [Key]
        public int Id { get; set; }

        public string RoleId {  get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue {  get; set; }

        public virtual Roles Roles { get; set; }
    }
}
