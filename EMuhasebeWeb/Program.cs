using DinkToPdf;
using DinkToPdf.Contracts;
using EMuhasebeWeb.Helpers;
using EMuhasebeWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ libwkhtmltox.dll yükle
var wkHtmlToXFilePath = Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll");
var loadContext = new CustomAssemblyLoadContext();
loadContext.LoadUnmanagedLibrary(wkHtmlToXFilePath);

// ✅ Gerekli servisler
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IConverter>(new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<PdfGenerator>();
builder.Services.AddScoped<IViewRenderService, ViewRenderService>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



// ✅ Middleware sıralaması
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

// ✅ Giriş sayfası default olarak açılır
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
