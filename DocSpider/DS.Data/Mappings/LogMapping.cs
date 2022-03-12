using DS.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Data.Mappings
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(a => a.Mensagem).HasColumnType("ntext").IsRequired();
        }
    }
}
