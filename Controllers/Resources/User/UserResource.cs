using System.ComponentModel.DataAnnotations;

namespace projekt.Controllers.Resources
{
    public class UserResource
    {
        public string UserId { get; set; }
        public string LastLogin { get; set; }
        public string UpdatedAt { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        [Required]
        public UserDataResource UserMetadata { get; set; }
    }
}