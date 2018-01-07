using System.Collections.Generic;

namespace projekt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string PictureUrl { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}