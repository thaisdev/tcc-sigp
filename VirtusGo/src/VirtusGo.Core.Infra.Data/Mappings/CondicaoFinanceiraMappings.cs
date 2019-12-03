using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.CondicaoFinanceira;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class CondicaoFinanceiraMappings : EntityTypeConfiguration<CondicaoFinanceira>
    {

        public override void Map(EntityTypeBuilder<CondicaoFinanceira> builder)
        {
            builder.ToTable("TCS_CFIN");

            builder.HasKey(X => X.Id);

            builder.Property(x => x.Id).HasColumnName("CODCOND");

            builder.Property(x => x.Parcelas).IsRequired().HasColumnName("PARCELAS");

            builder.Property(x => x.Dias).IsRequired().HasColumnName("DIAS");

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(X => X.ValidationResult);
        }
    }
}