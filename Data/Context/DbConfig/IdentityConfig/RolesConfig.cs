using Domain.Models.Identity_Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.DbConfig.IdentityConfig
{
    public class RolesConfig : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(o => o.Id)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(o => o.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.ToTable("AspNetRoles");
        }
    }
}
