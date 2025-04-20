using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public string? Description { get; set; }
    }
}
