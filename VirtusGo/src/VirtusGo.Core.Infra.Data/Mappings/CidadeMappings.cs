using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Cidade;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class CidadeMappings : EntityTypeConfiguration<Cidade>
    {
        public override void Map(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("TCS_CIDADE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODCID");

            builder.Property(x => x.NomeCidade).IsRequired().HasColumnName("NOMECID").HasMaxLength(40);

            builder.Property(x => x.EstadoId).IsRequired().HasColumnName("CODEST");

            builder.HasOne(x => x.Estado).WithMany(x => x.Cidades).HasForeignKey(x => x.EstadoId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}