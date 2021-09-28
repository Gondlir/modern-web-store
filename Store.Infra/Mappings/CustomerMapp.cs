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
            builder.Property(x => x.Document.Number).IsRequired().HasMaxLength(11).IsFixedLength();
            builder.Property(x => x.Email.Address).IsRequired().HasMaxLength(160);
            builder.Property(x => x.Name.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Name.LastName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.User.Username).IsRequired().HasMaxLength(20);
            builder.Property(x => x.User.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            builder.Property(x => x.User.Active);
        }
    }
}
