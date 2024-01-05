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
    public class SaleService : Service<Sale>, ISaleService
    {
        public SaleService(IRepository<Sale> repository) : base(repository)
        {
        }
    }
}
