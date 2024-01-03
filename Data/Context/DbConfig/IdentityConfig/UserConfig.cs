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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(o => o.FullName)
            .IsRequired()
            .HasMaxLength(150);
            builder.Property(o => o.Email)
            .IsRequired()
            .HasMaxLength(80);
            builder.Property(o => o.EmailConfirmed)
            .IsRequired()
            .HasColumnType("bit");
            builder.Property(o => o.CPF)
            .IsRequired()
            .HasMaxLength(14);
            builder.HasIndex(o => o.CPF)
            .IsUnique();
            builder.Property(o => o.BirthDate)
            .IsRequired()
            .HasColumnType("Date");
            builder.Property(o => o.Gender).HasColumnType("CHAR(1)").IsRequired(false);
            builder.HasCheckConstraint("CK_User_Gender", "Gender IN ('m', 'M', 'f', 'F')");
            builder.Property(o => o.PasswordHash)
            .IsRequired();
            builder.Property(o => o.SecurityStamp)
           .IsRequired();
            builder.Property(o => o.PhoneNumber)
            .IsRequired(false);
            builder.Property(o => o.PhoneNumberConfirmed)
            .IsRequired()
            .HasColumnType("bit");
            builder.Property(o => o.AccessFailedCount)
            .IsRequired();
            builder.Property(o => o.TwoFactorEnabled)
            .IsRequired()
            .HasColumnType("bit");
            builder.Property(o => o.LockoutEnabled)
            .IsRequired();
            builder.Property(o => o.AccessFailedCount)
            .IsRequired();

            builder.ToTable("AspNetUsers");
        }
    }
}
