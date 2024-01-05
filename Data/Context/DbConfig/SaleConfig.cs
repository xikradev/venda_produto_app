using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.DbConfig
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);

            builder
               .HasOne(s => s.User)
               .WithMany(u => u.Sales)
               .HasForeignKey(s => s.UserId);

            builder
                .HasOne(s => s.Client)
                .WithMany(c => c.Sales)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(20, 2)");
            builder.Property(s => s.Date)
               .HasColumnType("Date")
               .IsRequired();
            builder.Property(s => s.PaymentMethod)
                .HasMaxLength(80)
                .IsRequired();

           
        }
    }
}
