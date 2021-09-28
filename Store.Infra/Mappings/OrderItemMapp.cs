using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class OrderItemMapp : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Quantity);
            builder.HasOne(x => x.Product).WithMany();

        }
    }
}
