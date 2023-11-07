using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Entity
{
    public partial class Users
    {
        public Users()
        {
            Address = new HashSet<Address>();
            OrderData = new HashSet<OrderData>();
        }

        [Key]
        [Column("User_Id")]
        public int UserId { get; set; }
        [Required]
        [Column("First_Name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("Last_Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Required]
        [Column("Mobile_Num")]
        [StringLength(10)]
        public string MobileNum { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(10)]
        public string Role { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Address> Address { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<OrderData> OrderData { get; set; }
    }
}
