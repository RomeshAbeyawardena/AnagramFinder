using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace AnagramFinder.Contracts
{
    public interface IDataLayer : IAsyncDisposable
    {
        IDictionary<string, object> AsDictionary(params KeyValuePair<string, object>[] commandParameters);
        Task<IEnumerable<TResult>> GetData<TResult>(string command, CancellationToken cancellationToken = default, params KeyValuePair<string, object>[] commandParameters);
        Task<int> Execute(string command, CancellationToken cancellationToken = default, params KeyValuePair<string, object>[] commandParameters);
        DbConnection Connection { get; }
    }
}
