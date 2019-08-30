using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.EmpresaUsuarios;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class EmpresaUsuariosMappings : EntityTypeConfiguration<EmpresaUsuarios>
    {
        public override void Map(EntityTypeBuilder<EmpresaUsuarios> builder)
        {
            builder.ToTable("empresausus");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("NumChave");
            
            builder.Property(x => x.UsuarioId).HasColumnName("NumChUsuario");
            
            builder.Property(x => x.EmpresaId).HasColumnName("NumChEmpresa");

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}