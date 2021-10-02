using System;
using System.Collections.Generic;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<ProductQueryResult> GetProduct();
    }
}
