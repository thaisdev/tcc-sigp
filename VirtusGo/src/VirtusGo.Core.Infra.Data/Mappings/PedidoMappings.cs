using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Pedido;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class PedidoMappings : EntityTypeConfiguration<Pedido>
    {
        public override void Map(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("TTS_PED");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODPED");

            builder.Property(x => x.ParceiroId).HasColumnName("CODPAR").IsRequired();

            builder.Property(x => x.VendedorCompradorId).HasColumnName("CODVENCCOMP").IsRequired();

            builder.Property(x => x.MotoristaId).HasColumnName("CODMOT").IsRequired();

            builder.Property(x => x.DataNegociacaoPedido).HasColumnName("DTNEG").IsRequired();
            
            builder.Property(x => x.PagamentoId).HasColumnName("CODPAG").IsRequired();

            builder.Property(x => x.TipoPedido).HasColumnName("TIPO").IsRequired();

            builder.HasOne(x => x.Parceiro).WithMany(x => x.Pedidos).HasForeignKey(x => x.ParceiroId);

            builder.HasOne(x => x.Motorista).WithMany(x => x.Pedidos).HasForeignKey(x => x.MotoristaId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}