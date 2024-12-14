using Microsoft.EntityFrameworkCore;
using WeatherApp.Services;
using WeatherApp.Services.Data; // This is correct for accessing WeatherAppDbContext

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddRazorPages(); // Adds Razor Pages services to the app for server-side rendering.
builder.Services.AddHttpClient<WeatherService>(); // Registers the WeatherService with dependency injection using HttpClient.

// Configure the database connection
builder.Services.AddDbContext<WeatherAppDbContext>(options =>
    options.UseSqlite("Data Source=weatherapp.db")); // Sets up SQLite as the database provider with a specified connection string.

builder.Logging.ClearProviders(); // Clears default logging providers to set up custom logging.
builder.Logging.AddConsole(); // Adds console logging to output logs during application runtime.

var app = builder.Build(); // Builds the application pipeline.

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Specifies a custom error handler page for non-development environments.
    app.UseHsts(); // Enables HTTP Strict Transport Security (HSTS) for added security.
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.
app.UseStaticFiles(); // Serves static files like CSS, JavaScript, and images.
app.UseRouting(); // Enables routing for incoming requests.
app.UseAuthorization(); // Adds authorization middleware (even if no authorization is used yet).
app.MapRazorPages(); // Maps Razor Pages to endpoints in the request pipeline.
app.Run(); // Runs the application.
