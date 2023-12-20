using Data.Context.Interfaces;
using Domain.Models.Identity_Users;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.Common
{
    public class BaseContextIdentity : IdentityDbContext<User, Roles, String>, IDbContext
    {

        public BaseContextIdentity(DbContextOptions<UserDbContext> options) : base(options)
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
                result.Errors.Add(new ValidationFailure("DbUpdateException", ex.Message));
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
