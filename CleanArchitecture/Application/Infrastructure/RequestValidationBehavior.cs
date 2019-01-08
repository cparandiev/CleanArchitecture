using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Infrastructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = Validate(request);

            if (failures.Count != 0)
            {
                throw new Exceptions.ValidationException(failures);
            }

            failures = Validate(request, new[] { "Second Phase" });

            if (failures.Count != 0)
            {
                throw new Exceptions.ValidationException(failures);
            }

            return next();
        }

        private List<ValidationFailure> Validate(TRequest request, string[] selectors = null)
        {
            var context = new ValidationContext(request, new PropertyChain(), new RulesetValidatorSelector(selectors ?? new[] { "default" }));

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures;
        }
    }
}
