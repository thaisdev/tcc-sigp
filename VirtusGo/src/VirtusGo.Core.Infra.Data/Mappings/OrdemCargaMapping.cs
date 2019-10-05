using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Motoristas;
using VirtusGo.Core.Domain.OrdemCarga;
using VirtusGo.Core.Domain.Rota;
using VirtusGo.Core.Domain.Veiculo;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class OrdemCargaMapping : EntityTypeConfiguration<OrdemCarga>
    {
        public override void Map(EntityTypeBuilder<OrdemCarga> builder)
        {
            builder.ToTable("TTS_OC");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODOC");

            builder.Property(x => x.DataSaida).HasColumnName("DTSAIDA");

            builder.Property(x => x.DataChegada).HasColumnName("DTCHEGADA");

            builder.Property(x => x.RotaId).HasColumnName("CODROTA");

            builder.Property(x => x.MotoristaId).HasColumnName("CODMOT");

            builder.Property(x => x.VeiculoId).HasColumnName("CODVEI");

            builder.HasOne(x => x.Motorista).WithMany(x => x.OrdemCarga).HasForeignKey(c => c.MotoristaId);
            ;

            builder.HasOne(x => x.Veiculo).WithMany(x => x.OrdemCarga).HasForeignKey(c => c.VeiculoId);
            ;

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}