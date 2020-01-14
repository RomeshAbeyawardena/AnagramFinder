using AnagramFinder.Contracts;
using AnagramFinder.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<string>> FindAnagrams(string word)
        {
            var result = await anagramDataContext.GetAnagramMatches(word);

            return result
                .Select(anagramMatch => anagramMatch.Word)
                .ToArray();
        }
    }
}
