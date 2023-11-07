using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Entity
{
    public partial class Address
    {
        public Address()
        {
            OrderData = new HashSet<OrderData>();
        }

        [Key]
        [Column("Address_Id")]
        public int AddressId { get; set; }
        [Column("User_Id")]
        public int? UserId { get; set; }
        [Required]
        [Column("Address")]
        [StringLength(300)]
        public string Address1 { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string PinCode { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [Column("country")]
        [StringLength(50)]
        public string Country { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Address))]
        public virtual Users User { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<OrderData> OrderData { get; set; }
    }
}
