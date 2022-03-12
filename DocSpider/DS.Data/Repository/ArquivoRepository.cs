using DS.Business.Entities;
using DS.Business.Interface.Repository;
using DS.Data.Context;

namespace DS.Data.Repository
{
    public class ArquivoRepository : GenericRepository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(DSContext context) : base(context){}
    }
}
