using Microsoft.EntityFrameworkCore;

namespace WeatherApp.Services.Data
{
    /// <summary>
    /// Represents the database context for the WeatherApp application.
    /// This class manages database interactions and configurations.
    /// </summary>
    public class WeatherAppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherAppDbContext"/> class with specified options.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext, such as the connection string.</param>
        public WeatherAppDbContext(DbContextOptions<WeatherAppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet representing the SearchHistory table in the database.
        /// </summary>
        public DbSet<SearchHistory> SearchHistories { get; set; }
    }
}
