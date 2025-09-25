using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public interface IExceptionHandler
{
    Task<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken);
}

public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        string errorMessage = $"Bir hata oluştu. Hata mesajı : {exception.Message}";
        _logger.LogError(exception, errorMessage);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/json";

        var responseObj = new
        {
            Title = "Server Error",
            Status = httpContext.Response.StatusCode,
            Message = errorMessage
        };

        var json = JsonConvert.SerializeObject(responseObj);
        await httpContext.Response.WriteAsync(json, cancellationToken);

        return true;
    }
}
