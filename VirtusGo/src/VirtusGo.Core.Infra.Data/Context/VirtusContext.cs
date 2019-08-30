using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Beneficiarios;
using VirtusGo.Core.Domain.CotacaoPontos;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.EmpresaUsuarios;
using VirtusGo.Core.Domain.Faixas;
using VirtusGo.Core.Domain.Parametro;
using VirtusGo.Core.Domain.Pontuacao;
using VirtusGo.Core.Domain.PontuacaoPdv;
using VirtusGo.Core.Domain.Unidades;
using VirtusGo.Core.Domain.UnidadeUsuarios;
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
            modelBuilder.AddConfiguration(new EmpresaMappings());
            modelBuilder.AddConfiguration(new UnidadeMappings());
            modelBuilder.AddConfiguration(new CotacaoPontosMappings());
            modelBuilder.AddConfiguration(new FaixaMappings());
            modelBuilder.AddConfiguration(new PontuacaoPdvMapping());
            modelBuilder.AddConfiguration(new PontuacaoMappings());
            modelBuilder.AddConfiguration(new ParametroMappings());
            modelBuilder.AddConfiguration(new EmpresaUsuariosMappings());
            modelBuilder.AddConfiguration(new UnidadeUsuarioMappings());
            modelBuilder.Ignore<ValidationFailure>();
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Faixa> Faixas { get; set; }
        public DbSet<PontuacaoPDV> Pdv { get; set; }
        public DbSet<Pontuacao> Pontuacao { get; set; }
        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<CotacaoPontos> Cotacao { get; set; }
        public DbSet<EmpresaUsuarios> EmpresaUsuarios { get; set; }
        public DbSet<UnidadeUsuarios> UnidadeUsuarios { get; set; }
    }
}