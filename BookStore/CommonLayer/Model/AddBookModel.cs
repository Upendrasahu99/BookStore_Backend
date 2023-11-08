using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class AddBookModel
    {
        public string Title { get; set; }
        public string BookCode { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public decimal? Price { get; set; }
        public int PageCount { get; set; }
        public string Image { get; set; }
        public int? Quantity { get; set; }

    }
}
