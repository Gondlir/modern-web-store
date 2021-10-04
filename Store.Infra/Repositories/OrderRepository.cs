using System;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Context;

namespace Store.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public void Save(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
