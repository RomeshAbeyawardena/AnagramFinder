using AnagramFinder.Domains.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Contracts.Services
{
    public interface IAnagramService
    {
        Task<IEnumerable<AnagramMatch>> FindAnagrams(string word, CancellationToken cancellationToken = default); 
    }
}
