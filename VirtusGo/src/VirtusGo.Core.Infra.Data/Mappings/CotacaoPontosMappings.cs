using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.CotacaoPontos;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class CotacaoPontosMappings : EntityTypeConfiguration<CotacaoPontos>
    {
        public override void Map(EntityTypeBuilder<CotacaoPontos> builder)
        {
            builder.ToTable("cotacaopontoes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NumChave");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("ValValor");

            builder.Property(x => x.DataVigencia)
                .IsRequired()
                .HasColumnName("DatVigencia");

            builder.Property(x => x.FlagExcluido)
                .HasColumnName("FlgExcluido");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DatCriacao");

            builder.Property(x => x.DataAlteracao)
                .HasColumnName("DatAlteracao");

            builder.Property(x => x.UsuarioIdCriacao)
                .HasColumnName("NumChUsuarioCria");

            builder.Property(x => x.UsuarioIdAltera)
                .HasColumnName("NumChUsuarioAlt");

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}