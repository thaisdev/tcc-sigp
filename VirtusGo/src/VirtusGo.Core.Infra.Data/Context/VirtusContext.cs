using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Infra.Data.Extensions;
using VirtusGo.Core.Infra.Data.Mappings;

namespace VirtusGo.Core.Infra.Data.Context
{
    public sealed class VirtusContext : DbContext
    {

        public VirtusContext(DbContextOptions<VirtusContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new BeneficiarioMappings());
            modelBuilder.Ignore<ValidationFailure>();
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Beneficiario> Beneficiarios { get; set; }
    }
}