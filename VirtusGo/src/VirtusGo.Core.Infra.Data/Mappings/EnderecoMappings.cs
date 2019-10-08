using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Endereco;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class EnderecoMappings : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TCS_ENDERECO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODEND");

            builder.Property(x => x.Logradouro).IsRequired().HasColumnName("LOGRADOURO").HasMaxLength(40);

            builder.Property(x => x.Bairro).IsRequired().HasColumnName("BAIRRO").HasMaxLength(40);

            builder.Property(x => x.Cep).IsRequired().HasColumnName("CEP").HasMaxLength(40);

            builder.Property(x => x.Numero).IsRequired().HasColumnName("NUM");

            builder.Property(x => x.CidadeId).HasColumnName("CODCID");

            builder.HasOne(x => x.Cidade).WithMany(x => x.Endereco).HasForeignKey(x => x.CidadeId);

            builder.Ignore(x => x.Rota);
            
            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}