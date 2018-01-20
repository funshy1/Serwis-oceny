using System.ComponentModel.DataAnnotations;

namespace projekt.Controllers.Resources
{
    public class SaveProductResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(255)]
        public string UserId { get; set; }
        [Required]
        public int CategoryId { get; set; } 
        [Required]
        public string Description { get; set; } 
    }
}