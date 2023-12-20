using Domain.Interfaces.Repository;
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
    public class ClientService : Service<Client>, IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository) : base(repository)
        {
            _repository = repository;
        }

      

       
    }
}
