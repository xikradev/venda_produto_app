using Data.Context.Interfaces;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.Common
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        ValidationResult IDbContext.SaveChanges()
        {
            var result = new ValidationResult();
            try
            {
                base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                result.Errors.Add(new ValidationFailure("DbUpdateException", ex.Entries[0].ToString()));
            }
            catch (Exception ex)
            {
                result.Errors.Add(new ValidationFailure(ex.GetType().Name, ex.Message));
                if (ex.InnerException != null)
                {
                    result.Errors.Add(new ValidationFailure(ex.InnerException.GetType().Name, ex.InnerException.Message));
                }
            }

            return result;
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }
}

