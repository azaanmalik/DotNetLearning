using Microsoft.EntityFrameworkCore;
using UserRegisteration.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext")).LogTo(Console.WriteLine, new[]
    { DbLoggerCategory.Database.Command.Name},LogLevel.Information).EnableSensitiveDataLogging());
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRouting(options => 
{ 
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
    });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Add session middleware

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();


