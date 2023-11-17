using System;
using System.Collections.Generic;

namespace BookStore.Entity
{
    public partial class Book
    {
        public Book()
        {
            OrderData = new HashSet<OrderData>();
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public decimal? Price { get; set; }
        public int? PageCount { get; set; }
        public string Image { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<OrderData> OrderData { get; set; }
    }
}
