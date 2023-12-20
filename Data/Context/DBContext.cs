using Castle.Core.Resource;
using Data.Context.Common;
using Data.Context.DbConfig;
using Data.Context.DbConfig.IdentityConfig;
using Domain.Models;
using Domain.Models.ConfigDbContext;
using Domain.Models.Identity_Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class DBContext : AppDbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<RolesClaims> RolesClaims { get; set; }
        public DbSet<UserLogins> UserLogins { get; set; }
        public DbSet<UsersToken> UsersTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRoles>().HasNoKey();

            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SupplierConfig());
            modelBuilder.ApplyConfiguration(new ProductSupplierConfig());

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RolesConfig());
            modelBuilder.ApplyConfiguration(new UserRolesDbConfig());
            modelBuilder.ApplyConfiguration(new UserClaimsDbConfig());
            modelBuilder.ApplyConfiguration(new RolesClaimsConfig());
            modelBuilder.ApplyConfiguration(new UserLoginConfig());
            modelBuilder.ApplyConfiguration(new UserTokensConfig());
        }
    }
}
/// EntityFrameworkCore\Add-Migration GenerateDB -Context DBContext
/// EntityFrameworkCore\Update-Database -verbose -Context DBContext
/// EntityFrameworkCore\Remove-Migration -Context DBContext
/// EntityFrameworkCore\Update-Database -Migration "20231206175258_Adicionando a entidade Address" -Context DBContext
