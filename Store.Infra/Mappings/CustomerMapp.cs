using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class CustomerMapp : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BirthDate);
            builder.OwnsOne(x => x.Document).Property(x => x.Number).IsRequired().HasMaxLength(11).IsFixedLength();
            builder.OwnsOne(x => x.Email).Property(x => x.Address).IsRequired().HasMaxLength(160);
            builder.OwnsOne(x => x.Name).Property(x => x.FirstName).IsRequired().HasMaxLength(60);
            builder.OwnsOne(x => x.Name).Property(x => x.LastName).IsRequired().HasMaxLength(60);
            builder.OwnsOne(x => x.User).Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.OwnsOne(x => x.User).Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            builder.OwnsOne(x => x.User).Property(x => x.Active);
        }
    }
}
