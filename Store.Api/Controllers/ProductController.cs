using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;

namespace Store.Api
{

    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly CustomerHandler _handler;
        public ProductController(CustomerHandler handler)
        {
            _handler = handler;
        }
        [HttpGet]
        [Route("v1/products")]
        public string GetProducts()
        {
            return $"Produto";
        }
        [HttpGet]
        [Route("v1/products/{id}")]
        public string GetProductsById(Guid id)
        {
            return $"Produto";
        }
        [HttpPost]
        [Route("v1/products")]
        public GenericCommandResult PostProduct([FromBody] RegisterCustomerCommand command, [FromServices] CustomerHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
