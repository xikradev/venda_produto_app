using Domain.Interfaces.Services._Base;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AppService._Base
{
    public class AppService<TEntity> : IDisposable where TEntity : class
    {
        private readonly IService<TEntity> _service;
        protected ValidationResult Result { get; set; }

        public AppService(IService<TEntity> service)
        {
            this._service = service;
            this.Result = new ValidationResult();
        }

        public ValidationResult Add(TEntity entity)
        {
            Result = _service.Add(entity);
            return Result;
        }

        public ValidationResult Update(TEntity entity)
        {
            Result = _service.Update(entity);
            return Result;
        }

        public ValidationResult Remove(TEntity entity)
        {

            Result = _service.Remove(entity);
            return Result;
        }

        public TEntity Find(int Id)
        {
            return _service.Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
