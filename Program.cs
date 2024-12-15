using Microsoft.EntityFrameworkCore;
using WeatherApp.Services; // Your Logger class
using WeatherApp.Services.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddDbContext<WeatherAppDbContext>(options =>
    options.UseSqlite("Data Source=weatherapp.db"));

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Global Exception Handling Middleware
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        // Log the error to file
        WeatherApp.Services.Logger.LogError("A global error occurred", ex);

        // Redirect to the error page
        context.Response.Redirect("/Error");
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
