﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ReturnModel
{
    public class BookDetailReturnModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string BookCode { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public decimal? Price { get; set; }
        public int? PageCount { get; set; }
        public string Image { get; set; }
        public int? Stock { get; set; }
    }
}
