using App.AppService._Base;
using App.Interfaces;
using Domain.Interfaces.Services._Base;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AppService
{
    public class AddressAppService : AppService<Address>, IAddressAppService
    {
        public AddressAppService(IService<Address> service) : base(service)
        {
        }
    }
}
