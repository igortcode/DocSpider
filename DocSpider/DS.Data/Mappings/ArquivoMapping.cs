using DS.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Data.Mappings
{
    public class ArquivoMapping : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nome).HasColumnType("nvarchar").HasMaxLength(255).IsRequired();
            builder.Property(a => a.Titulo).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(a => a.Descricao).HasColumnType("ntext").HasMaxLength(2000);
        }
    }
}
