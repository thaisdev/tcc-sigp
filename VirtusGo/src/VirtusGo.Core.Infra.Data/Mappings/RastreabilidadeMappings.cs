using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Rastreabilidade;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class RastreabilidadeMappings : EntityTypeConfiguration<Rastreabilidade>
    {
        public override void Map(EntityTypeBuilder<Rastreabilidade> builder)
        {
            builder.ToTable("TTS_RASTRE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODRASTRE");
            builder.Property(x => x.PedidoCompraId).HasColumnName("CODPEDC");

            builder.Property(x => x.PedidoVendaId).HasColumnName("CODPEDV");

            builder.Property(x => x.ProdutoId).HasColumnName("CODPROD").IsRequired();

            builder.Property(x => x.Quantidade).HasColumnName("QTD").IsRequired();

            builder.HasOne(x => x.Produtos).WithMany(x => x.Rastreabilidade).HasForeignKey(x => x.ProdutoId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}