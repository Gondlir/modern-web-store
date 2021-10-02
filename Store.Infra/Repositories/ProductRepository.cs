using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Queries;
using Store.Domain.Repositories;
using Store.Infra.Context;

namespace Store.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public Product Get(Guid id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProductQueryResult> GetProduct()
        {
            using (var conn = new SqlConnection(@""))
            {
                conn.Open();
                return conn.Query<ProductQueryResult>("SELECT [Id], [Title], [Price], [Image] FROM [Product]");
            }
        }
    }
}
