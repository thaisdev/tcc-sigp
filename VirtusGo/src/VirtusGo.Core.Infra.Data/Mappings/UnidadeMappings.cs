using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Unidades;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class UnidadeMappings : EntityTypeConfiguration<Unidade>
    {
        public override void Map(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable("filials");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NumChave");

            builder.Property(x => x.RazaoSocial)
                .HasColumnName("DesRazSocial")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.Fantasia)
                .HasColumnName("DesFantasia")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.Documento)
                .HasColumnName("DesCNPJ")
                .IsRequired()
                .HasMaxLength(18);

            builder.Property(x => x.Email)
                .HasColumnName("DesEmail")
                .HasMaxLength(60);

            builder.Property(x => x.Ddd)
                .HasColumnName("NumDdd")
                .HasMaxLength(2);

            builder.Property(x => x.Telefone)
                .HasColumnName("NumTelefone")
                .HasMaxLength(10);

            builder.Property(x => x.Cep)
                .HasColumnName("DesCEP")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(x => x.Bairro)
                .HasColumnName("DesBairro")
                .HasMaxLength(50);

            builder.Property(x => x.Endereco)
                .HasColumnName("DesEndereco")
                .HasMaxLength(60);

            builder.Property(x => x.Uf)
                .HasColumnName("DesEstado")
                .HasMaxLength(2);

            builder.Property(x => x.Cidade)
                .HasColumnName("DesCidade")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.FlagBloqueado)
                .HasColumnName("FlgBloqueado");

            builder.Property(x => x.FlagExcluido)
                .HasColumnName("FlgExcluido");

            builder.Property(x => x.UsuarioIdCriador)
                .HasColumnName("NumChUsuarioCria");

            builder.Property(x => x.UsuarioIdAltera)
                .HasColumnName("NumChUsuarioAlt");

            builder.Property(x => x.EmpresaId)
                .HasColumnName("NumChEmpresa");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DatCriacao");

            builder.Property(x => x.DataAlteracao)
                .HasColumnName("DatAlteracao");

            builder.Property(x => x.NumeroDiasParaExpiracaoPontos)
                .HasColumnName("NumDiasExpiracaoPontos")
                .IsRequired();

            builder.Property(x => x.ComissaoGeral)
                .IsRequired()
                .HasColumnName("ValComissãoGeral");

            builder.Property(x => x.ValorPorcentagemGeralPontos)
                .IsRequired()
                .HasColumnName("ValPorcGeralPontosFaixa");

            builder.HasOne(x => x.Empresa)
                .WithMany(e => e.Unidade)
                .HasForeignKey(x => x.EmpresaId);

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}