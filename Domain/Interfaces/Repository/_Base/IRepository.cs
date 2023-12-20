using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository._Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValidationResult Add(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Remove(TEntity entity);
        TEntity Find(int Id);
        IEnumerable<TEntity> GetAll();
    }
}
