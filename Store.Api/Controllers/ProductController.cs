using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Store.Domain.Repositories;

namespace Store.Api
{

    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repo)
        {
            _repository = repo;
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
        public string PostProduct()
        {
            return $"Produto";
        }
    }
}
