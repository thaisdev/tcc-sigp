using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.ItemOrdemCarga;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class ItemOrdemCargaMapping : EntityTypeConfiguration<ItemOrdemCarga>
    {
        public override void Map(EntityTypeBuilder<ItemOrdemCarga> builder)
        {
            builder.ToTable("TTS_OCITE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODOC");

            builder.Property(x => x.PedidoId).HasColumnName("CODPED");

            builder.Property(x => x.Sequencia).HasColumnName("SEQUENCIA");

            builder.HasOne(x => x.Pedidos).WithOne();

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}