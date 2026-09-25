using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Task_Tracker.Middlewares
{
    public class GlobalExceptionHanndling
    {
        private readonly RequestDelegate _next;
        public readonly ILogger<GlobalExceptionHanndling> _logger;

        public GlobalExceptionHanndling(RequestDelegate next, ILogger<GlobalExceptionHanndling> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var problemDetails = new ProblemDetails();
                problemDetails.Status = 500;
                problemDetails.Title = "Unexpected server error accured";
                problemDetails.Detail = ex.Message;
                var jsonser = JsonSerializer.Serialize(problemDetails);
                await context.Response.WriteAsync(jsonser);
            }
        }
    }
}
