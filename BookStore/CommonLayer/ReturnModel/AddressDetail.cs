using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.ReturnModel
{
    public class AddressDetail
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
