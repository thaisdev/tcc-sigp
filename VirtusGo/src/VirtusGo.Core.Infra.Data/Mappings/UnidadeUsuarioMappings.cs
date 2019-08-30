using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtusGo.Core.Domain.UnidadeUsuarios;
using VirtusGo.Core.Infra.Data.Extensions;

namespace VirtusGo.Core.Infra.Data.Mappings
{
    public class UnidadeUsuarioMappings : EntityTypeConfiguration<UnidadeUsuarios>
    {
        public override void Map(EntityTypeBuilder<UnidadeUsuarios> builder)
        {
            builder.ToTable("filialusus");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("NumChave");

            builder.Property(x => x.UsuarioId).HasColumnName("NumChUsuario");

            builder.Property(x => x.UnidadeId).HasColumnName("NumChFilial");

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}
