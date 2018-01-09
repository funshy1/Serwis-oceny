using System.ComponentModel.DataAnnotations;

namespace projekt.Controllers.Resources
{
    public class SaveProductResource
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CategoryId { get; set; } 
        [Required]
        public string Description { get; set; } 
    }
}