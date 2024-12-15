using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherApp.Services; // For Logger.

namespace WeatherApp.Pages
{
    /// <summary>
    /// Represents the error page model.
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        /// <summary>
        /// Gets or sets the ID of the current request, used for error tracking.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Determines whether to show the request ID on the error page.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorModel"/> class.
        /// </summary>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles GET requests to the error page and logs error details.
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            // Retrieve the exception details, if available
            var exceptionFeature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();

            if (exceptionFeature?.Error != null)
            {
                var error = exceptionFeature.Error;

                // Log error to file system using Logger
                Logger.LogError($"Error occurred: {error.Message}", error);

                // Log error to built-in logger
                _logger.LogError(error, "An error occurred: {Message}", error.Message);
            }
        }
    }
}
