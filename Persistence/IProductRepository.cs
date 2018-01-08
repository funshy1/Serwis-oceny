using System.Collections.Generic;
using System.Threading.Tasks;
using projekt.Models;

namespace projekt.Persistence
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(Filter filter);
        Task<Product> GetProductById(int id, bool includeReviews = true);
        Task<IEnumerable<Product>> GetUserProducts(string userId, bool includeReviews = true);
        void Add(Product product);
        void Remove(Product product);
        
    }
}