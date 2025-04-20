using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        public Customer? Customer { get; set; }
        public ICollection<InvoiceDetail>? InvoiceDetails { get; set; }
    }
}
