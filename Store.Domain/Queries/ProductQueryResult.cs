using System;

namespace Store.Domain.Queries
{
    public class ProductQueryResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }

    }
}
