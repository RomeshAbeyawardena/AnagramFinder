using AnagramFinder.Domains.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Contracts
{
    public interface IAnagramDataContext
    {
        public Task<IEnumerable<AnagramMatch>> GetAnagramMatches(string word, CancellationToken cancellationToken = default);
    }
}
