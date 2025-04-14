using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
