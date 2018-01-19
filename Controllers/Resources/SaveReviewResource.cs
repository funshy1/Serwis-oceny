namespace projekt.Controllers.Resources
{
    public class SaveReviewResource
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
    }
}