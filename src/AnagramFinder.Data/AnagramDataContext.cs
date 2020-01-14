using AnagramFinder.Contracts;
using AnagramFinder.Domains.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<AnagramMatch>> GetAnagramMatches(string word)
        {
            return await dataLayer.GetData<AnagramMatch>("EXEC [dbo].[FindMatchngAnagrams] @word = @word", 
                new KeyValuePair<string, object>("word", word));
        }
    }
}
