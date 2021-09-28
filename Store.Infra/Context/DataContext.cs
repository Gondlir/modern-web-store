using System;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.ValueObjects;
using Store.Infra.Mappings;

namespace Store.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ignorando validações e notificações do ef
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new CustomerMapp());
            modelBuilder.ApplyConfiguration(new ProductMapp());
            modelBuilder.ApplyConfiguration(new OrderItemMapp());
            modelBuilder.ApplyConfiguration(new OrderMapp());
            modelBuilder.ApplyConfiguration(new UserMapping());

        }
    }
}
