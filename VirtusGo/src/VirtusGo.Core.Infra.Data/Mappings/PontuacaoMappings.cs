using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Pontuacao;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class PontuacaoMappings : EntityTypeConfiguration<Pontuacao>
    {
        public override void Map(EntityTypeBuilder<Pontuacao> builder)
        {
            builder.ToTable("pontuacaos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NumChave")
                .IsRequired();

            builder.Property(x => x.BeneficiarioId)
                .HasColumnName("NumChBeneficiario")
                .IsRequired();

            builder.Property(x => x.ValorLancamento)
                .HasColumnName("ValLancto")
                .IsRequired();

            builder.Property(x => x.UsuarioIdCriacao)
                .HasColumnName("NumChUsuarioCria")
                .IsRequired();

            builder.Property(x => x.UsuarioIdAlteracao)
                .HasColumnName("NumChUsuarioAlt");

            builder.Property(x => x.DataCompra)
                .HasColumnName("DatCompra")
                .IsRequired();

            builder.Property(x => x.DataLancamento)
                .HasColumnName("DatLancamento")
                .IsRequired();

            builder.Property(x => x.DataAlteracao)
                .HasColumnName("DatAlteracao");

            builder.Property(x => x.FlagExcluido)
                .HasColumnName("FlgExcluido");

            builder.Property(x => x.FlagInterface)
                .HasColumnName("FlgInterface");

            builder.Property(x => x.DataInterface)
                .HasColumnName("DatInterface");

            builder.Property(x => x.UsuarioIdInterface)
                .HasColumnName("NumChUsuarioInterface");

            builder.Property(x => x.FlagErroInterface)
                .HasColumnName("FlgErroInterface");

            builder.Property(x => x.DescricaoErroInterface)
                .HasColumnName("DesErroInterface")
                .HasMaxLength(100);

            builder.Property(x => x.EmpresaId)
                .HasColumnName("NumChEmpresa")
                .IsRequired();

            builder.Property(x => x.UnidadeId)
                .HasColumnName("NumChFilial");

            builder.HasOne(x => x.Beneficiarios)
                .WithMany(e => e.Pontuacao)
                .HasForeignKey(x => x.BeneficiarioId);

            builder.HasOne(x => x.Unidade)
                .WithMany(e => e.Pontuacao)
                .HasForeignKey(x => x.UnidadeId);

            builder.HasOne(x => x.Empresa)
                .WithMany(e => e.Pontuacao)
                .HasForeignKey(x => x.EmpresaId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}