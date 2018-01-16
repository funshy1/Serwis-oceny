namespace projekt.Controllers.Resources
{
    public class UserResource
    {
        public string UserId { get; set; }
        public string LastLogin { get; set; }
        public string UpdatedAt { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public UserDataResource UserMetadata { get; set; }
    }
}