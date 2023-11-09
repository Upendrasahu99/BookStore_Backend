using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class AddAddressModel
    {
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
