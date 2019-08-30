using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.PontuacaoFococlub;
using VirtusGo.Core.Domain.PontuacaoFocoClub;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class PontuacaoFococlubMappings : EntityTypeConfiguration<PontuacaoFocoClub>
    {
        public override void Map(EntityTypeBuilder<PontuacaoFocoClub> builder)
        {
            builder.ToTable(("pontuacao"));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("NumChave");
            
            builder.Property(x => x.Email).HasColumnName("DesEmail");
            
            builder.Property(x => x.ValorPontos).HasColumnName("ValPontos");
            
            builder.Property(x => x.BeneficiarioId).HasColumnName("NumChBeneficiario");
            
            builder.Property(x => x.PontuacaoIdGo).HasColumnName("NumChPontuacaoFidel");
            
            builder.Property(x => x.EmpresaId).HasColumnName("NumChEmpresa");
            
            builder.Property(x => x.UnidadeId).HasColumnName("NumChFilial");
           
            builder.Property(x => x.DataCompra).HasColumnName("DatCompra");
           
            builder.Property(x => x.Datalancamento).HasColumnName("DatLancamentoFidel");
            
            builder.Property(x => x.DataInterface).HasColumnName("DatInterface");
            
            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);

        }
    }
}