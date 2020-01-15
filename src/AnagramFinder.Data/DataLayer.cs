using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Common;
using AnagramFinder.Contracts;
using AnagramFinder.Domains;
using System.Threading;

namespace AnagramFinder.Data
{
    public class DataAccess : IDataLayer
    {
        public DataAccess(SqlClientFactory sQLClientFactory, ApplicationSettings applicationSettings)
        {
            Connection = sQLClientFactory.CreateConnection();
            Connection.ConnectionString = applicationSettings.ConnectionString;
        }

        public IDictionary<string, object> AsDictionary(params KeyValuePair<string, object>[] commandParameters)
        {
            return new Dictionary<string, object>(commandParameters);
        }

        public async Task<IEnumerable<TResult>> GetData<TResult>(string command, CancellationToken cancellationToken = default, params KeyValuePair<string, object>[] commandParameters)
        {
            return await SqlMapper.QueryAsync<TResult>(Connection, command, AsDictionary(commandParameters));
        }

        public async Task<int> Execute(string command, CancellationToken cancellationToken = default, params KeyValuePair<string, object>[] commandParameters)
        {
            return await SqlMapper.ExecuteAsync(Connection, command, AsDictionary(commandParameters));
        }

        public DbConnection Connection { get; }

        public async ValueTask DisposeAsync()
        {
            await Dispose(true);
        }

        async ValueTask Dispose(bool gc)
        {
            if(gc)
                await Connection.DisposeAsync();
        }
    }
}
