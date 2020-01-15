using MediatR;

namespace AnagramFinder.Domains.Requests
{
    public class FindAnagramRequest : IRequest<FindAnagramResponse>
    {
        public string Word { get;  set; }
    }
}
