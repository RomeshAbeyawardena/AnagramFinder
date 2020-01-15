using AnagramFinder.Contracts;
using AnagramFinder.Contracts.Services;
using AnagramFinder.Domains.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Services
{
    public class AnagramService : IAnagramService
    {
        private readonly IAnagramDataContext anagramDataContext;

        public AnagramService(IAnagramDataContext anagramDataContext)
        {
            this.anagramDataContext = anagramDataContext;
        }

        public async Task<IEnumerable<AnagramMatch>> FindAnagrams(string word, CancellationToken cancellationToken = default)
        {
            var result = await anagramDataContext.GetAnagramMatches(word, cancellationToken);

            return result;
        }
    }
}
