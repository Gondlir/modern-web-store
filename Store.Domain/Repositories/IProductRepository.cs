using System;
using System.Collections.Generic;
using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<Product> GetProduct(List<Guid> ids);
    }
}
