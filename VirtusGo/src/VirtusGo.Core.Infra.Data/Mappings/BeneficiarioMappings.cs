using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class BeneficiarioMappings : EntityTypeConfiguration<Beneficiario>
    {
        public override void Map(EntityTypeBuilder<Beneficiario> builder)
        {
            builder.ToTable("beneficiarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("NumChave");

            builder.Property(x => x.Nome).HasColumnName("DesNome")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.TipPessoa)
                .IsRequired();

            builder.Property(x => x.NumeroDocumento)
                .HasColumnName("DesCpfCnpj")
                .IsRequired()
                .HasMaxLength(19);

            builder.Property(x => x.Ddd)
                .HasColumnName("NumDdd")
                .HasMaxLength(4);

            builder.Property(x => x.Telefone)
                .HasColumnName("NumTelefone")
                .HasMaxLength(10);

            builder.Property(x => x.Email)
                .HasColumnName("DesEmail")
                .HasMaxLength(50);

            builder.Property(x => x.Cep)
                .HasColumnName("DesCEP")
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(x => x.Bairro)
                .HasColumnName("DesBairro")
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
                .HasMaxLength(30);

            builder.Property(x => x.Excluido)
                .HasColumnName("FlgExcluido");

            builder.Property(x => x.DataCadastro)
                .HasColumnName("DatCriacao");

            builder.Property(x => x.DataAlteracao)
                .HasColumnName("DatAlteracao");

            builder.Property(x => x.UsuarioCriacaoId)
                .HasColumnName("NumChUsuarioCria");

            builder.Property(x => x.UsuarioAlteracaoId)
                .HasColumnName("NumChUsuarioAlt");

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}