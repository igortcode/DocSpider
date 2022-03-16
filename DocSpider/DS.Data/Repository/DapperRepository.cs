using Dapper;
using DS.Business.Interface.Repository;
using DS.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DS.Data.Repository
{
    public class DapperRepository : IDapperRepository
    {
        private readonly DbConnection connection;

        public DapperRepository(DSContext context)
        {
            connection = context.Database.GetDbConnection();

        }
        public async Task<IList<T>> DbQueryAsync<T>(string sql, object param = null)
        {
            IEnumerable<T> result = await connection.QueryAsync<T>(sql, param);
            return result.AsList();
        }

        public async Task<T> DbQueryFirstAsync<T>(string sql, object param = null)
        {
            IEnumerable<T> result = await connection.QueryAsync<T>(sql, param);
            return result.FirstOrDefault();
        }

        public async Task<T> DPExecuteScalarAsync<T>(string sql, object param = null)
        {
            return await connection.ExecuteScalarAsync<T>(sql, param);
        }
    }
}
