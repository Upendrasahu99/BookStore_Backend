using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ReturnModel
{
    public class OrderDetailReturn
    {
        public string Title { get; set; }
        public string BookCode { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateTime { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
    }
}
