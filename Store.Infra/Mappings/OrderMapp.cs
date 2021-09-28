using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class OrderMapp : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate);
            builder.Property(x => x.DeliveryPrice).HasColumnType("money");
            builder.Property(x => x.Discounts).HasColumnType("money");
            builder.Property(x => x.Number).IsRequired().HasMaxLength(8).IsFixedLength();
            builder.Property(x => x.Status);
            builder.HasMany(x => x.Items);
            builder.Property(x => x.Customer);
        }
    }
}