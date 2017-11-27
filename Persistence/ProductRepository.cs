using System.Collections.Generic;
using System.Collections.ObjectModel;
using projekt.Models;

namespace projekt.Persistence
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            return new Collection<Product>() {
                new Product() { Id = 1, Name = "Mouse", ImageUrl = "https://images10.newegg.com/NeweggImage/ProductImage/26-153-231-V02.jpg" },
                new Product() { Id = 2, Name = "Mouse2", ImageUrl = "https://multimedia.bbycastatic.ca/multimedia/products/500x500/104/10497/10497231.jpg" },
                new Product() { Id = 3, Name = "Keyboard", ImageUrl = "https://images10.newegg.com/ProductImage/23-828-003-28.jpg" },
                new Product() { Id = 4, Name = "Keyboard2", ImageUrl = "https://images10.newegg.com/ProductImage/23-828-011-V05.jpg" },
                new Product() { Id = 5, Name = "Headset", ImageUrl = "https://images10.newegg.com/ProductImage/26-197-105-09.jpg" },
                new Product() { Id = 6, Name = "Headset2", ImageUrl = "http://bpc.h-cdn.co/assets/17/09/480x480/gallery-1488659377-logitech-prodigy-gaming-headset.jpg" },
            };

        }
    }
}