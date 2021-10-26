using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KavaaBook.Application.SeedWork;
using FluentValidation;
using MediatR.Pipeline;

namespace KavaaBook.Application.Decorators
{
    internal class ValidationCommandPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : ICommandBase
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationCommandPreProcessor(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var errorTasks = _validators
                .Select(v => v.ValidateAsync(request));

            var errors = (await Task.WhenAll(errorTasks))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Count > 0)
            {
                throw new InvalidCommandException(errors.ConvertAll(x => x.ErrorMessage));
            }
        }
    }
}