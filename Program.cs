using WeatherApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<WeatherService>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Build the app (only do this once)
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.Urls.Add("http://*:5266"); // Add this line after building the app
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
