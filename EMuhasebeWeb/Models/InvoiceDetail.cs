using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMuhasebeWeb.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }

        [Required]
        public int InvoiceID { get; set; }

        public Invoice Invoice { get; set; }

        [Required]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit price is required.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [NotMapped]
        public decimal LineTotal => Quantity * UnitPrice;
    }
}
