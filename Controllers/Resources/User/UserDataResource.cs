using System.ComponentModel.DataAnnotations;

namespace projekt.Controllers.Resources
{
    public class UserDataResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string About { get; set; }
    }
}