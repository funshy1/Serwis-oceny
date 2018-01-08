using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Product>> GetProducts(Filter filter)
        {
            var query =  this.context.Products
                .Include(p => p.Reviews)
                .Include(p => p.Category)
                .AsQueryable();

            if (filter.CategoryId.HasValue)
                query = query.Where(p => p.Category.Id == filter.CategoryId);

            return await query.ToListAsync();
        }

        public async Task<Product> GetProductById(int id, bool includeReviews = true) {
            if (!includeReviews)
                return await context.Products.FindAsync(id);

            return await context.Products
                .Include(p => p.Reviews)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetUserProducts(string userId, bool includeReviews = true) {
            if (!includeReviews)
                return await context.Products
                    .Include(p => p.Category)
                    .Where(p => p.UserId == userId)
                    .ToArrayAsync();

            return await context.Products
                .Include(p => p.Reviews)
                .Include(p => p.Category)
                .Where(p => p.UserId == userId)
                .ToArrayAsync();
        }

        public void Add(Product product) {
            context.Products.Add(product);
        }

        public void Remove(Product product) {
            context.Remove(product);
        }
    }
}