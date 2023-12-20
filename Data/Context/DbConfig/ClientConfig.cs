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
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Fullname)
                .IsRequired()
                .HasMaxLength(150);    
            builder.Property(o => o.Email)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(o => o.Register)
                .IsRequired()
                .HasMaxLength(18);
            builder.HasIndex(o => o.Register)
                .IsUnique();
            builder.Property(o => o.BirthDate)
                .IsRequired(false)
                .HasColumnType("Date");
            builder.Property(o => o.OpeningData)
                .IsRequired(false)
                .HasColumnType("Date");
            builder.Property(o => o.Gender).HasColumnType("CHAR(1)").IsRequired(false);
            builder.HasCheckConstraint("CK_Client_Gender", "Gender IN ('m', 'M', 'f', 'F')");
            builder.Property(o => o.BussisnesArea)
                .IsRequired(false)
                .HasMaxLength(100);

            

            builder.HasOne(a => a.Address)
            .WithOne()
            .HasForeignKey<Client>(e => e.AddressId);

        }
    }
}
