using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherApp.Pages
{
    /// <summary>
    /// The PrivacyModel class handles the logic for the Privacy page in the application.
    /// </summary>
    public class PrivacyModel : PageModel
    {
        // Logger instance for recording messages and debugging information.
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Initializes a new instance of the PrivacyModel class with the specified logger.
        /// </summary>
        /// <param name="logger">Logger used for recording messages and events.</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles GET requests for the Privacy page.
        /// This method is executed when the Privacy page is accessed.
        /// </summary>
        public void OnGet()
        {
            // Currently, no specific logic is implemented for the Privacy page.
            // This can be expanded in the future as needed.
        }
    }
}
