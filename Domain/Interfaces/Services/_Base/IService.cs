using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services._Base
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity Find(int Id);
        IEnumerable<TEntity> GetAll();
        ValidationResult Add(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Remove(TEntity entity);
        void Dispose();
    }
}
