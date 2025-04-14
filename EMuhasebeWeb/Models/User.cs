﻿using EMuhasebeWeb.Models;

public class User
{
    public int UserID { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleID { get; set; }

    public Role Role { get; set; }
}
