using Microsoft.EntityFrameworkCore;
using WeatherApp.Services;
using WeatherApp.Services.Data; // This is correct for accessing WeatherAppDbContext

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<WeatherService>();

// Configure the database connection
builder.Services.AddDbContext<WeatherAppDbContext>(options =>
    options.UseSqlite("Data Source=weatherapp.db"));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
