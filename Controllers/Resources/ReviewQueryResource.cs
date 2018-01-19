namespace projekt.Controllers.Resources
{
    public class ReviewQueryResource
    {
        public int? ProductId { get; set; }
        public string UserId { get; set; }
        public string SortBy { get; set; }
        public bool isSortAscending { get; set; }
        public int? Page { get; set; }
        public byte? PageSize { get; set; }
    }
}