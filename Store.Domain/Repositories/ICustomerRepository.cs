using System;
using Store.Domain.Entities;

namespace Store.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(Guid id);
        Customer GetCustomerById(Guid id);
        void Update(Customer customer);
        void Save(Customer customer);
        bool DocumentExist(string document);

    }
}
