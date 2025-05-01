using DinkToPdf;
using DinkToPdf.Contracts;
using EMuhasebeWeb.Helpers;
using EMuhasebeWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Session, HTTP context
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

// View Rendering + PDF
builder.Services.AddSingleton<IConverter>(new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<PdfGenerator>();
builder.Services.AddScoped<IViewRenderService, ViewRenderService>();

// MVC
builder.Services.AddControllersWithViews();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Roles.Any(r => r.Name == "Admin"))
    {
        var adminRole = new Role { Name = "Admin" };
        db.Roles.Add(adminRole);
        db.SaveChanges();
    }

    if (!db.Users.Any(u => u.Email == "admin@example.com"))
    {
        var adminUser = new User
        {
            FullName = "System Admin",
            Email = "admin@example.com",
            Password = PasswordHasher.Hash("1234"),
            RoleID = db.Roles.First(r => r.Name == "Admin").RoleID
        };
        db.Users.Add(adminUser);
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
