namespace projekt.Models
{
    public class User
    {
        public string user_id { get; set; }
        public string last_login { get; set; }
        public string updated_at { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public UserData user_metadata { get; set; }
    }
}