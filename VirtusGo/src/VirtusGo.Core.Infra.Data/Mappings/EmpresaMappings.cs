using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class EmpresaMappings : EntityTypeConfiguration<Empresa>
    {
        public override void Map(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("TCS_EMP");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODEMP");

            builder.Property(x => x.Razao).HasColumnName("RAZAO").IsRequired();

            builder.Property(x => x.CNPJ).HasColumnName("CNPJ").IsRequired();

            builder.Property(x => x.Inscri).HasColumnName("INSCRI").IsRequired();

            builder.Property(x => x.EnderecoId).HasColumnName("CODEND").IsRequired();

            builder.HasOne(x => x.Endereco).WithMany(x => x.Empresas).HasForeignKey(x => x.EnderecoId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}