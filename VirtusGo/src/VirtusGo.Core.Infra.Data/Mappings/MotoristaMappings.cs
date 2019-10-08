using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.Motoristas;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class MotoristaMappings : EntityTypeConfiguration<Motorista>
    {
        public override void Map(EntityTypeBuilder<Motorista> builder)
        {
            builder.ToTable("TCS_MOT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CODMOT");

            builder.Property(x => x.Nome).HasColumnName("NOMEMOT").IsRequired();

            builder.Property(x => x.CPF).HasColumnName("CPF").IsRequired();

            builder.Property(x => x.CategoriaCNH).HasColumnName("CATCNH").IsRequired();

            builder.Property(x => x.NumeroCNH).HasColumnName("NROCNH").IsRequired();

            builder.Property(x => x.EnderecoId).HasColumnName("CODEND");

            builder.Property(x => x.Telefone).HasColumnName("TEL").IsRequired();

            builder.Property(x => x.DataNascimento).HasColumnName("DTNASC").IsRequired();

            builder.Property(x => x.DataVencimentoCNH).HasColumnName("DTVENCCNHM").IsRequired();

            builder.HasOne(x => x.Endereco).WithMany(x => x.Motorista).HasForeignKey(x => x.EnderecoId);

            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}