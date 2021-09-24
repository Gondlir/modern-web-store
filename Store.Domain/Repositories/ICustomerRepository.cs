using System;
using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(Guid id);
        Customer GetCustomerById(Guid id);
    }
}
