using DS.Business.Entities;
using DS.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DS.Data.Context
{
    public class DSContext : DbContext
    {
        public DSContext(DbContextOptions<DSContext> options) : base(options) { }
        public DbSet<Arquivo> Arquivos { get; set;}
        public DbSet<Log> Logs { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArquivoMapping());
            modelBuilder.ApplyConfiguration(new LogMapping());
        }
    }
}
