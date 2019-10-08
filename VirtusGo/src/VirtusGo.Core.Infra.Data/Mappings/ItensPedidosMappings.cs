using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.ItensPedidos;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class ItensPedidosMappings : EntityTypeConfiguration<ItensPedido>
    {
        public override void Map(EntityTypeBuilder<ItensPedido> builder)
        {
            builder.ToTable("TTS_PEDITE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODPED");

            builder.Property(x => x.ProdutoId).HasColumnName("CODPROD");

            builder.Property(x => x.Quantidade).HasColumnName("QTD").IsRequired();

            builder.Property(x => x.ValorUnitario).HasColumnName("VLRUNIT").IsRequired();

            builder.Property(x => x.ValorTotal).HasColumnName("VLRTOT").IsRequired();

            builder.HasOne(x => x.Produtos).WithMany(x => x.ItensPedido).HasForeignKey(x => x.ProdutoId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}