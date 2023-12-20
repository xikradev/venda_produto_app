using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identity_Users
{
    public class UserLogins: IdentityUserLogin<String>
    {
        public UserLogins() :base()
        {
            
        }
    }
}
