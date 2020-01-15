using AnagramFinder.Domains.Data;
using System.Collections.Generic;

namespace AnagramFinder.Domains.Requests
{
    public class FindAnagramResponse
    {
        public IEnumerable<AnagramMatch> AnagramMatches { get; set; }
    }
}
