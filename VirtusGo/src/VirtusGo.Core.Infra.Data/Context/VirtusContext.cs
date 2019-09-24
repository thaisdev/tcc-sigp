﻿using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Domain.Cidade;
using VirtusGo.Core.Domain.Endereco;
using VirtusGo.Core.Domain.Estado;
using VirtusGo.Core.Domain.Parceiro;
using VirtusGo.Core.Domain.Rota;
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
            modelBuilder.AddConfiguration(new CidadeMappings());
            modelBuilder.AddConfiguration(new EstadoMappings());
            modelBuilder.AddConfiguration(new EnderecoMappings());
            modelBuilder.Ignore<ValidationFailure>();
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Rota> Rota { get; set; }
        public DbSet<Parceiro> Parceiro { get; set; }
    }
}