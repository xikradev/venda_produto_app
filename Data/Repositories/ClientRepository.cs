﻿using Data.Context.Interfaces;
using Data.Repositories._Base;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        
    }
}
