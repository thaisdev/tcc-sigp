using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Produtos;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class ProdutoMappings : EntityTypeConfiguration<Produto>
    {
        public override void Map(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("TCS_PRO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODPROD");

            builder.Property(x => x.Descricao).HasColumnName("DESCPROD").IsRequired();

            builder.Property(x => x.Unidade).HasColumnName("UNID").IsRequired();

            builder.Property(x => x.ValorUnitario).HasColumnName("VLRUNIT").IsRequired();

            builder.Property(x => x.Estoque).HasColumnName("ESTOQUE").IsRequired();

            builder.Property(x => x.NCM).HasColumnName("NCM").IsRequired();

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}