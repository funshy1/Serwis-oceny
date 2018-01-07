using System.Collections.Generic;

namespace projekt.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public User User { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}