using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Parceiro;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class ParceiroMappings : EntityTypeConfiguration<Parceiro>
    {
        public override void Map(EntityTypeBuilder<Parceiro> builder)
        {
            builder.ToTable("TCS_PAR");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODPAR");

            builder.Property(x => x.Nome).HasColumnName("NOMEPAR").IsRequired().HasMaxLength(40);

            builder.Property(x => x.Email).HasColumnName("EMAIL").IsRequired().HasMaxLength(40);

            builder.Property(x => x.EnderecoId).HasColumnName("CODEND");

            builder.Property(x => x.NumeroDocumento).HasColumnName("CPF_CNPJ").IsRequired().HasMaxLength(14);

            builder.Property(x => x.RgInscricaoEstadual).HasColumnName("RG_INCRIEST").IsRequired().HasMaxLength(12);

            builder.Property(x => x.Site).HasColumnName("SITE").HasMaxLength(20);

            builder.Property(x => x.Telefone).HasColumnName("TEL").HasMaxLength(20);

            builder.HasOne(x => x.Endereco).WithMany(x => x.Parceiro).HasForeignKey(x => x.EnderecoId);

            builder.HasMany(x => x.Veiculos).WithOne().HasForeignKey(x => x.ParceiroId);

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}