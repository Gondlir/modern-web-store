using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
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

        public IEnumerable<Product> GetProduct(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
