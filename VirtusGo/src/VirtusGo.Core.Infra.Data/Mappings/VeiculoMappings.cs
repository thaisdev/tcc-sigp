using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Veiculo;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class VeiculoMappings : EntityTypeConfiguration<Veiculo>
    {
        public override void Map(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TCS_VEI");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("CODVEI");
            builder.Property(x => x.Placa).HasColumnName("PLACA");
            builder.Property(x => x.Modelo).HasColumnName("MODELO");
            builder.Property(x => x.Cor).HasColumnName("COR");
            builder.Property(x => x.Marca).HasColumnName("MARCA");
            builder.Property(x => x.Renavam).HasColumnName("RENAVAM");
        }
    }
}