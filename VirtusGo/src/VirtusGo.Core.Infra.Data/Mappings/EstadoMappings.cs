using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Estado;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class EstadoMappings : EntityTypeConfiguration<Estado>
    {
        public override void Map(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("TCS_ESTADO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODEST");

            builder.Property(x => x.NomeEstado).IsRequired().HasColumnName("NOMEEST").HasMaxLength(40);

            builder.Property(x => x.SiglaEstado).IsRequired().HasColumnName("SIGLAEST").HasMaxLength(2);

            builder.HasMany(x => x.Cidades).WithOne(x => x.Estado).HasForeignKey(x => x.EstadoId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}