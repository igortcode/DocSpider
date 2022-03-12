using DS.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DS.Data.Context
{
    public class DSContext : DbContext
    {
        public DSContext(DbContextOptions<DSContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArquivoMapping());
            modelBuilder.ApplyConfiguration(new LogMapping());
        }
    }
}
