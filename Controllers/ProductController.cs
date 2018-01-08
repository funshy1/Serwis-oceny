using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekt.Controllers.Resources;
using projekt.Models;
using projekt.Persistence;

namespace projekt.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public ProductController(IProductRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<QueryResultResource<Product>> GetProducts(ProductQueryResource filterResource)
        {
            var filter = mapper.Map<ProductQueryResource, ProductQuery>(filterResource);
            var queryResult = await repository.GetProducts(filter);

            return mapper.Map<QueryResult<Product>, QueryResultResource<Product>>(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await repository.GetProductById(id);

            if (product == null)
                return NotFound();

            var productResource = mapper.Map<Product, ProductResource>(product);
            
            return Ok(productResource);
        }

    }
}