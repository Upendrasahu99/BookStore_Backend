using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RepoLayer.Entity
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

        [JsonIgnore]
        public virtual Users User { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderData> OrderData { get; set; }
    }
}
