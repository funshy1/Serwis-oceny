using System.Collections.Generic;
using projekt.Models;

namespace projekt.Persistence
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}