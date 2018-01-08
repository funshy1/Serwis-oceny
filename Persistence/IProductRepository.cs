using System.Collections.Generic;
using System.Threading.Tasks;
using projekt.Models;

namespace projekt.Persistence
{
    public interface IProductRepository
    {
        Task<QueryResult<Product>> GetProducts(ProductQuery filter);
        Task<Product> GetProductById(int id, bool includeReviews = true);
        void Add(Product product);
        void Remove(Product product);
        
    }
}