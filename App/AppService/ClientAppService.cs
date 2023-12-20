using App.AppService._Base;
using App.Interfaces;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services._Base;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AppService
{
    public class ClientAppService : AppService<Client>, IClientAppService
    {
        private readonly IClientService _service;

        public ClientAppService(IClientService service) : base(service)
        {
            _service = service;
        }

        
    }
}
