using AnagramFinder.Contracts.Services;
using AnagramFinder.Domains.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Services.RequestHandlers
{
    public class FindAnagramRequestHandler : IRequestHandler<FindAnagramRequest, FindAnagramResponse>
    {
        private readonly IAnagramService anagramService;

        public Task<FindAnagramResponse> Handle(FindAnagramRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public FindAnagramRequestHandler(IAnagramService anagramService)
        {
            this.anagramService = anagramService;
        }
    }
}
