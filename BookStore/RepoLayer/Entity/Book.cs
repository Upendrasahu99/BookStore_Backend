using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoLayer.Entity
{
    public partial class Book
    {
        public Book()
        {
            OrderData = new HashSet<OrderData>();
        }

        [Key]
        [Column("Book_Id")]
        public int BookId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        [Required]
        [StringLength(50)]
        public string Language { get; set; }
        [Required]
        [StringLength(100)]
        public string Publisher { get; set; }
        [Column("price", TypeName = "decimal(10, 2)")]
        public decimal? Price { get; set; }
        [Column("Page_Count")]
        public int? PageCount { get; set; }
        public string Image { get; set; }
        public int? Quantity { get; set; }

        [InverseProperty("Book")]
        public virtual ICollection<OrderData> OrderData { get; set; }
    }
}
