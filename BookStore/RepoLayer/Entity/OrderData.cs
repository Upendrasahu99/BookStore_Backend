using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Entity
{
    [Table("Order_Data")]
    public partial class OrderData
    {
        [Key]
        [Column("Order_Id")]
        public int OrderId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Amount { get; set; }
        [Column("Date_Time", TypeName = "datetime")]
        public DateTime? DateTime { get; set; }
        [Required]
        [Column("Order_Status")]
        [StringLength(30)]
        public string OrderStatus { get; set; }
        [Required]
        [Column("Payment_Status")]
        [StringLength(30)]
        public string PaymentStatus { get; set; }
        [Column("User_Id")]
        public int? UserId { get; set; }
        [Column("Book_Id")]
        public int? BookId { get; set; }
        [Column("Address_Id")]
        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("OrderData")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(BookId))]
        [InverseProperty("OrderData")]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.OrderData))]
        public virtual Users User { get; set; }
    }
}
