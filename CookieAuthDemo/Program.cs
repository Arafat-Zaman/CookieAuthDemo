using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add cookie-based authentication service
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Path to login page
        options.AccessDeniedPath = "/Account/AccessDenied"; // Path to access denied page
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie expiration
    });

var app = builder.Build();

// Middleware pipeline configuration
app.UseStaticFiles();   // Serve static files

app.UseRouting();       // Enable routing

app.UseAuthentication();  // Enable authentication middleware
app.UseAuthorization();   // Enable authorization middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
