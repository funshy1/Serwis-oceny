using System.ComponentModel.DataAnnotations;

namespace projekt.Controllers.Resources
{
    public class SaveReviewResource
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public float Rating { get; set; }
        [Required]
        [StringLength(255)]
        public string Text { get; set; }
    }
}