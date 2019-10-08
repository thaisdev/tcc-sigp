using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using VirtusGo.Core.Domain.Cidade;
using VirtusGo.Core.Domain.Empresa;
using VirtusGo.Core.Domain.Endereco;
using VirtusGo.Core.Domain.EnderecoEstoque;
using VirtusGo.Core.Domain.Estado;
using VirtusGo.Core.Domain.ItemOrdemCarga;
using VirtusGo.Core.Domain.ItensPedidos;
using VirtusGo.Core.Domain.Motoristas;
using VirtusGo.Core.Domain.OrdemCarga;
using VirtusGo.Core.Domain.Parceiro;
using VirtusGo.Core.Domain.Pedido;
using VirtusGo.Core.Domain.Produtos;
using VirtusGo.Core.Domain.Rastreabilidade;
using VirtusGo.Core.Domain.Rota;
using VirtusGo.Core.Domain.Veiculo;
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
            modelBuilder.AddConfiguration(new CidadeMappings());
            modelBuilder.AddConfiguration(new EmpresaMappings());
            modelBuilder.AddConfiguration(new EnderecoMappings());
            modelBuilder.AddConfiguration(new EnderecoEstoqueMappings());
            modelBuilder.AddConfiguration(new EstadoMappings());
            modelBuilder.AddConfiguration(new ItemOrdemCargaMapping());
            modelBuilder.AddConfiguration(new ItensPedidosMappings());
            modelBuilder.AddConfiguration(new MotoristaMappings());
            modelBuilder.AddConfiguration(new OrdemCargaMapping());
            modelBuilder.AddConfiguration(new ParceiroMappings());
            modelBuilder.AddConfiguration(new PedidoMappings());
            modelBuilder.AddConfiguration(new ProdutoMappings());
            modelBuilder.AddConfiguration(new RastreabilidadeMappings());
            modelBuilder.AddConfiguration(new RotaMappings());
            modelBuilder.AddConfiguration(new VeiculoMappings());
            modelBuilder.Ignore<ValidationFailure>();
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<EnderecoEstoque> EnderecoEstoque { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<ItemOrdemCarga> ItemOrdemCarga { get; set; }
        public DbSet<ItensPedido> ItensPedidos { get; set; }
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<OrdemCarga> OrdemCarga { get; set; }
        public DbSet<Parceiro> Parceiro { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Rastreabilidade> Rastreabilidade { get; set; }
        public DbSet<Rota> Rota { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
    }
}