namespace projekt.Models
{
    public class Review
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
    }
}