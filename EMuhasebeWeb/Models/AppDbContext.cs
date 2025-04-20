using Microsoft.EntityFrameworkCore;

namespace EMuhasebeWeb.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<IncomeExpense> IncomeExpenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);

            // Role Seed
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleID = 1, Name = "Admin" },
                new Role { RoleID = 2, Name = "Staff" }
            );
            modelBuilder.Entity<Product>()
              .Property(p => p.Price)
               .HasColumnType("decimal(18,2)");

            // User Seed
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, FullName = "Ali Yönetici", Email = "admin@example.com", Password = "1234", RoleID = 1 },
                new User { UserID = 2, FullName = "Zeynep Personel", Email = "zeynep@site.com", Password = "123", RoleID = 2 },
                new User { UserID = 3, FullName = "Mehmet Personel", Email = "mehmet@site.com", Password = "123", RoleID = 2 },
                new User { UserID = 4, FullName = "Ayşe Personel", Email = "ayse@site.com", Password = "123", RoleID = 2 },
                new User { UserID = 5, FullName = "Hasan Admin", Email = "hasan@site.com", Password = "admin", RoleID = 1 }
            );
        }
    }
}
