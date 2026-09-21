using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Now I handle the {typeof(TRequest).Name}.");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = await next();
            stopWatch.Stop();
            _logger.LogInformation($"The {typeof(TRequest).Name} request is finisherd after {stopWatch.ElapsedMilliseconds} ms");
            return response;
        }
    }
}
