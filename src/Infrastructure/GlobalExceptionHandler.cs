using gamestoolkit.api.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace gamestoolkit.api.Infrastructure
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"Exception [{ exception.Message }]. Inner exception [{ exception.InnerException?.Message}]. Stack trace: [{ exception.StackTrace }]");

            var errorResponse = new ErrorResponseViewModel();

            switch (exception)
            {
                case BadHttpRequestException:
                    errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = exception.GetType().Name;
                    break;
                default:
                    errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal Server Error";
                    break;
            }

            httpContext.Response.StatusCode = errorResponse.StatusCode;
            await httpContext
                .Response
                .WriteAsJsonAsync(errorResponse, cancellationToken);

            // You may return false and set another ExceptionHandler to handle specific exceptions
            return true;
        }
    }
}
