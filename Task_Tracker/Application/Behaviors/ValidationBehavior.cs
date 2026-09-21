using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var validationContext =new ValidationContext<TRequest>(request);
                var validationsOnRequest = _validators.Select(v => v.Validate(validationContext));
                var errorsOfValidation = validationsOnRequest.SelectMany(e => e.Errors).Where(f => f != null).ToList();
                if (errorsOfValidation.Count() > 0)
                    throw new ValidationException(errorsOfValidation);
            }
            return await next();
        }
    }
}
