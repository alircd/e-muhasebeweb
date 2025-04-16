using EMuhasebeWeb.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int UserID { get; set; }

    [Required(ErrorMessage = "Full name is required.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Role is required.")]
    public int RoleID { get; set; }

    public Role Role { get; set; }
}

