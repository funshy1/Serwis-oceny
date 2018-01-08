using projekt.Extensions;

namespace projekt.Models
{
    public class ProductQuery : IQueryObject
    {
        public int? CategoryId { get; set; }
        public string UserId { get; set; }
        public string SortBy { get; set; }
        public bool isSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
