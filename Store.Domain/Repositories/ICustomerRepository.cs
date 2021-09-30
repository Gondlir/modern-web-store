using System;
using Store.Domain.Commands;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(Guid id);
        CustomerQueryResult GetQueryResult(string username);
        void Update(Customer customer);
        void Save(Customer customer);
        bool DocumentExist(string document);

    }
}
