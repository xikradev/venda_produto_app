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
    public class SaleItemConfig : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Product)
                .WithMany(p => p.SaleItems)
                .HasForeignKey(s => s.ProductId);

            builder.HasOne(s => s.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(s => s.SaleId);

            builder.Property(s => s.Quantity)
                .IsRequired();
            builder.Property(s => s.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");
            builder.Property(s => s.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(20, 2)");
        }
    }
}
