using System.Collections.Generic;
using System.Threading.Tasks;

namespace DS.Business.Interface.Repository
{
    public interface IDapperRepository
    {
        Task<IList<T>> DbQueryAsync<T>(string sql, object param = null);
        Task<T> DbQueryFirstAsync<T>(string sql, object param = null);
        Task<T> DPExecuteScalarAsync<T>(string sql, object param = null);
    }
}
