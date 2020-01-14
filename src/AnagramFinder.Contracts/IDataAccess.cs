using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder.Contracts
{
    public interface IDataAccess : IAsyncDisposable
    {
        Task<IEnumerable<TResult>> GetData<TResult>(string command, params KeyValuePair<string, object>[] commandParameters);
        Task<int> Execute(string command, params KeyValuePair<string, object>[] commandParameters);
        DbConnection Connection { get; }
    }
}
