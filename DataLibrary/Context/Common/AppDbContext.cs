using DataLibrary.Context.Interfaces;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Context.Common
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        public ValidationResult SaveChanges()
        {
            var result = new ValidationResult();
            try
            {
                base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Tratar exceções do Entity Framework, se necessário
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
