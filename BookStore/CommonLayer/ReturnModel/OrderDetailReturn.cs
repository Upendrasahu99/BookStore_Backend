using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ReturnModel
{
    public class OrderDetailReturn
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string BookCode { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public int? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateTime { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
