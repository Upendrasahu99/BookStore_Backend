using System;
using System.Collections.Generic;

namespace BookStore.Entity
{
    public partial class Address
    {
        public Address()
        {
            OrderData = new HashSet<OrderData>();
        }

        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrderData> OrderData { get; set; }
    }
}
