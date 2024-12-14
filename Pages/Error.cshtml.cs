using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherApp.Pages;

/// <summary>
/// Represents the error page model, handling error information and logging.
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

    private readonly ILogger<ErrorModel> _logger; // Logger for tracking error information

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorModel"/> class.
    /// </summary>
    /// <param name="logger">Logger instance for logging error-related information.</param>
    public ErrorModel(ILogger<ErrorModel> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Handles GET requests to the error page, setting the request ID for display and logging purposes.
    /// </summary>
    public void OnGet()
    {
        // Set the request ID to either the current activity ID or the trace identifier from the HTTP context
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
    }
}
