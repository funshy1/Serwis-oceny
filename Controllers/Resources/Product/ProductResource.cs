using System.Collections.Generic;
using projekt.Models;

namespace projekt.Controllers.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public string UserId { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public Category Category { get; set; }
    }
}