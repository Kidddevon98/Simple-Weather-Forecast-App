using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Services.Data
{
    public class WeatherAppDbContext : DbContext
    {
        public WeatherAppDbContext(DbContextOptions<WeatherAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<SearchHistory> SearchHistories { get; set; }
    }
}
