using AnagramFinder.Contracts;
using AnagramFinder.Domains.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Data
{
    public class AnagramDataContext : IAnagramDataContext
    {
        private readonly IDataLayer dataLayer;

        public AnagramDataContext(IDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        public async Task<IEnumerable<AnagramMatch>> GetAnagramMatches(string word, CancellationToken cancellationToken = default)
        {
            return await dataLayer.GetData<AnagramMatch>("EXEC [dbo].[FindMatchngAnagrams] @word = @word", cancellationToken,
                new KeyValuePair<string, object>("word", word));
        }
    }
}
