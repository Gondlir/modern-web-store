using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Infra.Transactions;

namespace Store.Api
{

    public class CustomerController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(CustomerHandler handler)
        {
            _handler = handler;
        }
        [HttpPost]
        [Route("v1/customers")]
        public GenericCommandResult PostCustomer([FromBody] RegisterCustomerCommand command, [FromServices] CustomerHandler handler)
        { 
            return (GenericCommandResult)handler.Handle(command);      
        }
        [HttpGet]
        [Route("v1/customers")]
        public string GetCustomer()
        {
            return $"Produto";
        }
        [HttpGet]
        [Route("v1/customers/{id}")]
        public string GetCustomerById(Guid id)
        {
            return $"Produto";
        }

    }
}
