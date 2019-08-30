using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class EmpresaMappings : EntityTypeConfiguration<Empresas>
    {
        public override void Map(EntityTypeBuilder<Empresas> builder)
        {
            builder.ToTable("empresas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("NumChave");

            builder.Property(x => x.RazaoSocial)
                .HasColumnName("DesRazSocial")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.NomeFantasia)
                .HasColumnName("DesFantasia")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.NumeroDocumento)
                .HasColumnName("DesCNPJ")
                .IsRequired()
                .HasMaxLength(19);

            builder.Property(x => x.Bloqueado)
                .HasColumnName("FlgBloqueado");

            builder.Property(x => x.Excluido)
                .HasColumnName("FlgExcluido");

            builder.Property(x => x.Email)
                .HasColumnName("DesEmail")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email2)
                .HasColumnName("DesEmail2")
                .HasMaxLength(50);

            builder.Property(x => x.Email3)
                .HasColumnName("DesEmail3")
                .HasMaxLength(50);

            builder.Property(x => x.Cep)
                .HasColumnName("DesCEP")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(x => x.Bairro)
                .HasColumnName("DesBairro")
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.Endereco)
                .HasColumnName("DesEndereco")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Uf)
                .HasColumnName("DesEstado")
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.Cidade)
                .HasColumnName("DesCidade")
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Contato)
                .HasColumnName("DesContato")
                .HasMaxLength(40);

            builder.Property(x => x.Contato2)
                .HasColumnName("DesContato2")
                .HasMaxLength(40);

            builder.Property(x => x.Ddd)
                .HasColumnName("NumDdd")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasColumnName("NumTelefone")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Ddd2)
                .HasColumnName("NumDdd2")
                .HasMaxLength(2);

            builder.Property(x => x.Telefone2)
                .HasColumnName("NumTelefone2")
                .HasMaxLength(10);

            builder.Property(x => x.Ddd3)
                .HasColumnName("NumDdd3")
                .HasMaxLength(2);

            builder.Property(x => x.Telefone3)
                .HasColumnName("NumTelefone3")
                .HasMaxLength(10);

            builder.Property(x => x.QuantidadeFilial)
                .HasColumnName("ValQtdMaxFilial");

            builder.Property(x => x.DiasParaExpiracaoPontos)
                .HasColumnName("NumDiasExpiracaoPontos");

            builder.Property(x => x.ValorComissãoGeral)
                .HasColumnName("ValComissãoGeral");

            builder.Property(x => x.PorcentagemPadraoPontos)
                .HasColumnName("ValPorcGeralPontosFaixa");

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DatCriacao");

            builder.Property(x => x.DataAlteracao)
                .HasColumnName("DatAlteracao");

            builder.Property(x => x.UsuarioIdCriacao)
                .HasColumnName("NumChUsuarioCria");

            builder.Property(x => x.UsuarioIdAlteracao)
                .HasColumnName("NumChUsuarioAlt");

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}