using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projekt.Extensions;
using projekt.Models;

namespace projekt.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ServiceDbContext context;
        public ProductRepository(ServiceDbContext context)
        {
            this.context = context;
        }

        public async Task<QueryResult<Product>> GetProducts(ProductQuery queryObject)
        {
            var result = new QueryResult<Product>();

            var query = this.context.Products
                .Include(p => p.Reviews)
                .Include(p => p.Category)
                .AsQueryable();

            if (queryObject.CategoryId.HasValue)
                query = query.Where(p => p.Category.Id == queryObject.CategoryId);
            if (!String.IsNullOrEmpty(queryObject.UserId))
                query = query.Where(p => p.UserId == queryObject.UserId);

            var map = new Dictionary<string, Expression<Func<Product, object>>>()
            {
                ["name"] = p => p.Name,
                ["rating"] = p => p.Rating,
                ["category"] = p => p.Category.Name,
                ["reviewCount"] = p => p.Reviews.Count()
            };
 
            query = query.ApplyOrdering(queryObject, map);
            result.TotalItems = await query.CountAsync();
            query = query.ApplyPaging(queryObject);
            result.Items = await query.ToListAsync();

            return result;
        }

        public async Task<Product> GetProductById(int id, bool includeReviews = true)
        {
            if (!includeReviews)
                return await context.Products.FindAsync(id);

            return await context.Products
                .Include(p => p.Reviews)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public void Remove(Product product)
        {
            context.Remove(product);
        }
    }
}