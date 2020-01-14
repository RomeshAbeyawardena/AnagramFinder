using AnagramFinder.Domains.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder.Contracts
{
    public interface IAnagramDataContext
    {
        public Task<IEnumerable<AnagramMatch>> GetAnagramMatches(string word);
    }
}
