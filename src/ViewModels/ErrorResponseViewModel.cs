using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace gamestoolkit.api.ViewModels
{
    public class ErrorResponseViewModel
    {
        public string? Message { get; set; }

        public int StatusCode { get; set; }
    }
}
