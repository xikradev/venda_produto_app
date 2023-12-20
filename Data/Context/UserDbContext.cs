using Data.Context.Common;
using Data.Context.DbConfig;
using Data.Context.DbConfig.IdentityConfig;
using Domain.Models;
using Domain.Models.Identity_Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class UserDbContext : BaseContextIdentity
    {
        public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

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

            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SupplierConfig());
            modelBuilder.ApplyConfiguration(new ProductSupplierConfig());

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserRolesConfig());
            modelBuilder.ApplyConfiguration(new UserClaimsConfig());
            modelBuilder.ApplyConfiguration(new RolesConfig());

        }
    }
    /// EntityFrameworkCore\Add-Migration GenerateDB -Context UserDbContext
    /// EntityFrameworkCore\Update-Database -verbose -Context UserDbContext
    /// EntityFrameworkCore\Remove-Migration -Context UserDbContext
    /// EntityFrameworkCore\Update-Database -Migration "20231206175258_Adicionando a entidade Address" -Context UserDbContext
}
