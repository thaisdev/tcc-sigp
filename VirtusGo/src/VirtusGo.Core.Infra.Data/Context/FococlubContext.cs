using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.PontuacaoFococlub;
using VirtusGo.Core.Domain.PontuacaoFocoClub;
using VirtusGo.Core.Infra.Data.Extensions;
using VirtusGo.Core.Infra.Data.Mappings;

namespace VirtusGo.Core.Infra.Data.Context
{
    public class FococlubContext : DbContext
    {
        public FococlubContext(DbContextOptions<FococlubContext> options) :
            base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PontuacaoFococlubMappings());
            modelBuilder.Ignore<ValidationFailure>();
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<PontuacaoFocoClub> PontuacaoFocoClub { get; set; }
    }
}