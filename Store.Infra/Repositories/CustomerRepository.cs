using System;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Queries;
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

        public CustomerQueryResult GetQueryResult(string username)
        {
            // return _context.Customers.Include(x => x.User).AsNoTracking().Select(x => new CustomerQueryResult
            // {
            //     Name = x.Name.ToString(),
            //     Document = x.Document.Number,
            //     Active = x.User.Active,
            //     Email = x.Email.Address,
            //     Password = x.User.Password,
            //     Username = x.User.Username
            // }).FirstOrDefault(x => x.Username == username);

            using (var conn = new SqlConnection(@""))
            {
                conn.Open();
                return conn.Query<CustomerQueryResult>("SELECT * FROM [GetCustomerInfo] WHERE [Active]=1 AND [Username]=@username", new
                {
                    username = username
                }).FirstOrDefault();
            }
        }

        public Customer GetCustomer(Guid id)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
