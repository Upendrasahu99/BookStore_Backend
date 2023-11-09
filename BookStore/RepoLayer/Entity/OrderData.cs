using System;
using System.Collections.Generic;

namespace RepoLayer.Entity
{
    public partial class OrderData
    {
        public int OrderId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateTime { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public int? AddressId { get; set; }
        public int Quantity { get; set; }

        public virtual Address Address { get; set; }
        public virtual Book Book { get; set; }
        public virtual Users User { get; set; }
    }
}
