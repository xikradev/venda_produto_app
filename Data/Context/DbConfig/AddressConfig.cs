using Domain.Models;
using Domain.Models.Identity_Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.DbConfig
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
           

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Complement).IsRequired().HasMaxLength(150);
            builder.HasIndex(a => a.CEP).IsUnique();
            builder.Property(a => a.CEP).IsRequired().HasMaxLength(9);
            builder.Property(a => a.UF).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(a => a.City).HasMaxLength(80).IsRequired();

            
        }
    }
}
