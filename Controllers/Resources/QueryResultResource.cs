using System.Collections.Generic;

namespace projekt.Controllers.Resources
{
    public class QueryResultResource<T>
     {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}