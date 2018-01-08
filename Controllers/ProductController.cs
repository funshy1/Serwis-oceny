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
        public async Task<IEnumerable<Product>> GetProducts(FilterResource filterResource)
        {
            var filter = mapper.Map<FilterResource, Filter>(filterResource);
            var products = await repository.GetProducts(filter);

            return products;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await repository.GetProductById(id);;
        }

    }
}