using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class ProductMapp : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.Price);
            builder.Property(x => x.QuantityInBase);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(80);
        }
    }
}
