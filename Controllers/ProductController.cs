using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projekt.Models;
using projekt.Persistence;

namespace projekt.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            var products = repository.GetProducts();
            return products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
        
            var products = repository.GetProducts();

            return products.SingleOrDefault(p => p.Id == id);
        }

    }
}