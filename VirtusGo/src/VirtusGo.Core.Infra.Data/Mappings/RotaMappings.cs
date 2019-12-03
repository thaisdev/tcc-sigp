using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Endereco;
using VirtusGo.Core.Domain.Rota;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class RotaMappings : EntityTypeConfiguration<Rota>
    {
        public override void Map(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("TCS_ROTA_END");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODROTA");

            builder.Property(x => x.EnderecoId).HasColumnName("CODEND");

            builder.HasOne(x => x.Endereco).WithMany(x => x.Rota).HasForeignKey(x => x.EnderecoId);

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}