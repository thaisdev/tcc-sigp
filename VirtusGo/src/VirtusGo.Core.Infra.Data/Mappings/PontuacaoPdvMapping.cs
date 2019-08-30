using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using VirtusGo.Core.Domain.PontuacaoPdv;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class PontuacaoPdvMapping : EntityTypeConfiguration<PontuacaoPDV>
    {
        public override void Map(EntityTypeBuilder<PontuacaoPDV> builder)
        {
            builder.ToTable("pontuacaopdvs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NumChave");

            builder.Property(x => x.ValorLancamento)
                .HasColumnName("ValLancto")
                .IsRequired();

            builder.Property(x => x.DataCompra)
                .HasColumnName("DatCompra");

            builder.Property(x => x.Cpf)
                .HasColumnName("NumCpf")
                .HasMaxLength(18)
                .IsRequired();

            builder.Property(x => x.Operador)
                .HasColumnName("DesOperador")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("DesEmail")
                .HasMaxLength(60);

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

            builder.Property(x => x.MensagemErroInterface)
                .HasColumnName("DesErroInterface");

            builder.Property(x => x.EmpresaId)
                .HasColumnName("NumChEmpresa");

            builder.HasOne(x => x.Unidade)
                .WithMany(u => u.PontuacaoPdv)
                .HasForeignKey(x => x.UnidadeId);

            builder.Property(x => x.UnidadeId)
                .HasColumnName("NumChFilial");

            //builder.Ignore(x => x.Usuario);
            builder.Ignore(x => x.Empresa);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}