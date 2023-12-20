using Domain.Interfaces.Repository._Base;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AddressService : Service<Address>, IAddressService
    {
        public AddressService(IRepository<Address> repository) : base(repository)
        {
        }
    }
}
