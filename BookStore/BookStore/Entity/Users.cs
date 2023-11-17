using System;
using System.Collections.Generic;

namespace BookStore.Entity
{
    public partial class Users
    {
        public Users()
        {
            Address = new HashSet<Address>();
            OrderData = new HashSet<OrderData>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string MobileNum { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<OrderData> OrderData { get; set; }
    }
}
