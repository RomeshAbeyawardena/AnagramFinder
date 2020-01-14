using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.Contracts.Services
{
    public interface IAnagramService
    {
        Task<IEnumerable<string>> FindAnagrams(string word);
    }
}
