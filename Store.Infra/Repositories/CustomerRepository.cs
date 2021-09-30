using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Context;

namespace Store.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        public bool DocumentExist(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public Customer GetCustomer(Guid id)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);

        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
