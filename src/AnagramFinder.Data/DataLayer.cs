using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Common;

namespace AnagramFinder.Data
{
    public class DataAccess
    {
        public DataAccess(SqlClientFactory sQLClientFactory, string connectionString)
        {
            Connection = sQLClientFactory.CreateConnection();
            Connection.ConnectionString = connectionString;
        }

        private IDictionary<string, object> AsDictionary(params KeyValuePair<string, object>[] commandParameters)
        {
            return new Dictionary<string, object>(commandParameters);
        }

        public async Task<IEnumerable<TResult>> GetData<TResult>(string command, params KeyValuePair<string, object>[] commandParameters)
        {
            return await SqlMapper.QueryAsync<TResult>(Connection, command, AsDictionary(commandParameters));
        }

        public async Task<int> Execute(string command, params KeyValuePair<string, object>[] commandParameters)
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
