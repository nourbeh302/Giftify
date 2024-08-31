using Serilog.Context;
using System.Diagnostics;

namespace WebApi.Middlewares;

public class RequestLoggingMiddleware(
    RequestDelegate next,
    ILogger<RequestLoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestLoggingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
        {
            _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

            try
            {
                await _next(context);

                _logger.LogInformation("Request succeeded: {Method} {Path} in {ElapsedMilliseconds} ms",
                    context.Request.Method, context.Request.Path, stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Request failed: {Method} {Path} in {ElapsedMilliseconds} ms",
                    context.Request.Method, context.Request.Path, stopwatch.ElapsedMilliseconds);

                throw;
            }
        }
    }
}
