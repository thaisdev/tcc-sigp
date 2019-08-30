using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Faixas;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class FaixaMappings : EntityTypeConfiguration<Faixa>
    {
        public override void Map(EntityTypeBuilder<Faixa> builder)
        {
            builder.ToTable("faixas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NumChave");

            builder.Property(x => x.ValorDe)
                .HasColumnName("ValDe")
                .IsRequired();

            builder.Property(x => x.ValorAte)
                .HasColumnName("ValAte")
                .IsRequired();

            builder.Property(x => x.ValorPorcentagem)
                .HasColumnName("ValPorcentagem")
                .IsRequired();

            builder.Property(x => x.FlagExcluido)
                .HasColumnName("FlgExcluido");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DatCriacao");

            builder.Property(x => x.DataAlteracao)
                .HasColumnName("DatAlteracao");

            builder.Property(x => x.EmpresaId)
                .HasColumnName("NumChEmpresa");

            builder.Property(x => x.UnidadeId)
                .HasColumnName("NumChFilial");

            builder.Property(x => x.UsuarioIdCriacao)
                .HasColumnName("NumChUsuarioCria");

            builder.Property(x => x.UsuarioIdAltera)
                .HasColumnName("NumChUsuarioAlt");

            builder.HasOne(x => x.Empresa)
                .WithMany(e => e.Faixa)
                .HasForeignKey(x => x.EmpresaId);

            builder.HasOne(x => x.Unidades)
                .WithMany(e => e.Faixa)
                .HasForeignKey(x => x.UnidadeId);

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}