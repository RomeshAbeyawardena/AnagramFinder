using AnagramFinder.Contracts.Services;
using AnagramFinder.Domains.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Services.RequestHandlers
{
    public class FindAnagramRequestHandler : IRequestHandler<FindAnagramRequest, FindAnagramResponse>
    {
        private readonly IAnagramService _anagramService;

        public async Task<FindAnagramResponse> Handle(FindAnagramRequest request, CancellationToken cancellationToken)
        {
            return new FindAnagramResponse { AnagramMatches = await _anagramService.FindAnagrams(request.Word, cancellationToken) };
        }

        public FindAnagramRequestHandler(IAnagramService anagramService)
        {
            _anagramService = anagramService;
        }
    }
}
