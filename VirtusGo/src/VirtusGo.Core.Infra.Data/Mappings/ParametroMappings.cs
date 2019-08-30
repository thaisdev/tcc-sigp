using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Parametro;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class ParametroMappings : EntityTypeConfiguration<Parametro>
    {
        public override void Map(EntityTypeBuilder<Parametro> builder)
        {
            builder.ToTable("parametroes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NumChave");

            builder.Property(x => x.DiasParaExpiracaoPontos)
                .IsRequired()
                .HasColumnName("NumDiasExpiracaoPontos");

            builder.Property(x => x.ValorComissaoGeral)
                .IsRequired()
                .HasColumnName("ValComissãoGeral");

            builder.Property(x => x.FlagExcluido)
                .HasColumnName("FlgExcluido");

            builder.Property(x => x.DataAlteracao)
                .HasColumnName("DatAlteracao");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DatCriacao");

            builder.Property(x => x.UsuarioIdCriacao)
                .HasColumnName("NumChUsuarioCria");

            builder.Property(x => x.UsuarioIdAlteracao)
                .HasColumnName("NumChUsuarioAlt");

            builder.Property(x => x.ValorPorcentagemGeralPontosFaixa)
                .IsRequired()
                .HasColumnName("ValPorcGeralPontosFaixa");

//          builder.Ignore(x => x.Usuario);
            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);

        }
    }
}