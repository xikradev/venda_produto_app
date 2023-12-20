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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(10, 2)");
            builder.Property(p => p.Description).HasColumnName("descricao").IsRequired().HasMaxLength(500);
            builder.Property(p => p.Quantity_in_stock).IsRequired().HasColumnType("decimal(10, 2)");

        }
    }
}
