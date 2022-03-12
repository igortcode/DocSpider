using DS.Business.Entities;
using DS.Business.Interface.Repository;
using DS.Data.Context;

namespace DS.Data.Repository
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        public LogRepository(DSContext context) : base(context)
        {

        }
    }
}
