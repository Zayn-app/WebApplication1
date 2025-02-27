using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Controllers;
using WebApplication1.Data.Services; // Aray�z ve s�n�flar�n bulundu�u namespa/ce





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

// Add scoped services
builder.Services.AddScoped<IEventsService,EventsService>();

builder.Services.AddControllersWithViews();

// Yetkilendirme hizmetini ekleyin
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews(); // MVC hizmetlerini ekler

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Veritaban� ba�lat�c�s�n� �a��r�n
DbInitializer.Seed(app);

app.Run();
