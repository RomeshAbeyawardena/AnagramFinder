using System.Threading;
using System.Threading.Tasks;
using AnagramFinder.Domains.Requests;
using FluentValidation;
using MediatR.Pipeline;

namespace AnagramFinder.Services.Pipelines
{
    public class FindAnagramRequestPreProcessor : IRequestPreProcessor<FindAnagramRequest>
    {
        private readonly IValidator<FindAnagramRequest> _findAnagramRequestValidator;

        public async Task Process(FindAnagramRequest request, CancellationToken cancellationToken)
        {
            await _findAnagramRequestValidator.ValidateAsync(request);
        }

        public FindAnagramRequestPreProcessor(IValidator<FindAnagramRequest> findAnagramRequestValidator)
        {
            _findAnagramRequestValidator = findAnagramRequestValidator;
        }
    }
}
