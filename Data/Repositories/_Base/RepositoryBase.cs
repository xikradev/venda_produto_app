using Data.Context.Interfaces;
using Domain.Interfaces.Repository._Base;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories._Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        private readonly IDbContext _dbContext;
        public RepositoryBase(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected DbContext Context
        {
            get { return (DbContext)_dbContext; }
        }

        public ValidationResult Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);

            ValidationResult vr = _dbContext.SaveChanges();

            if (!vr.IsValid)
                _dbContext.Set<TEntity>().Remove(entity);

            return vr;
        }

        public TEntity Find(int Id)
        {
            return _dbContext.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public ValidationResult Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return (_dbContext.SaveChanges());
        }

        public ValidationResult Update(TEntity entity)
        {
            var db_entries = _dbContext.Entry<TEntity>(entity).CurrentValues;
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;

            // Use reflection to get the properties of the entity type
            var properties = typeof(TEntity).GetProperties();
            var identityProperty = properties.FirstOrDefault(p => p.GetCustomAttributes(typeof(DatabaseGeneratedAttribute), false).Cast<DatabaseGeneratedAttribute>().Any(a => a.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity));
            if (identityProperty != null)
                _dbContext.Entry(entity).Property(identityProperty.Name).IsModified = false;


            var geoProperty = properties.FirstOrDefault(p => p.GetCustomAttributes(typeof(ColumnAttribute), false).Cast<ColumnAttribute>().Any(a => a.TypeName == "geography"));
            if (geoProperty != null)
                _dbContext.Entry(entity).Property(geoProperty.Name).IsModified = false;

            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }
    }
}
