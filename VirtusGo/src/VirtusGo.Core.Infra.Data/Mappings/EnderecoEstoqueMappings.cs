using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.EnderecoEstoque;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class EnderecoEstoqueMappings : EntityTypeConfiguration<EnderecoEstoque>
    {
        public override void Map(EntityTypeBuilder<EnderecoEstoque> builder)
        {
            builder.ToTable("TCS_ESTEND");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODEND");

            builder.Property(x => x.DescricaoEndereco).HasColumnName("DESCREND").IsRequired();

            builder.Property(x => x.Rua).HasColumnName("RUA").IsRequired();

            builder.Property(x => x.Coluna).HasColumnName("COLUNA").IsRequired();

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}