using AutoMapper;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.Services;
using VirtusGo.Core.Domain.Cidade.Commands;
using VirtusGo.Core.Domain.Cidade.Repository;
using VirtusGo.Core.Domain.CondicaoFinanceira.Commands;
using VirtusGo.Core.Domain.CondicaoFinanceira.Repository;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Empresas.Commands;
using VirtusGo.Core.Domain.Empresas.Repository;
using VirtusGo.Core.Domain.Endereco.Commands;
using VirtusGo.Core.Domain.Endereco.Repository;
using VirtusGo.Core.Domain.EnderecoEstoque.Repository;
using VirtusGo.Core.Domain.Estado.Commands;
using VirtusGo.Core.Domain.Estado.Repository;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.ItemOrdemCarga.Repository;
using VirtusGo.Core.Domain.ItensPedidos.Repository;
using VirtusGo.Core.Domain.Motoristas.Commands;
using VirtusGo.Core.Domain.Motoristas.Repository;
using VirtusGo.Core.Domain.OrdemCarga.Repository;
using VirtusGo.Core.Domain.Parceiro.Commands;
using VirtusGo.Core.Domain.Parceiro.Repository;
using VirtusGo.Core.Domain.Pedido.Repository;
using VirtusGo.Core.Domain.Produtos.Commands;
using VirtusGo.Core.Domain.Produtos.Repository;
using VirtusGo.Core.Domain.Rastreabilidade.Repository;
using VirtusGo.Core.Domain.Rota.Repository;
using VirtusGo.Core.Domain.Veiculo.Commands;
using VirtusGo.Core.Domain.Veiculo.Repository;
using VirtusGo.Core.Infra.CrossCutting.Bus;
//using VirtusGo.Core.Infra.CrossCutting.Identity.Models;
//using VirtusGo.Core.Infra.CrossCutting.Identity.Services;
using VirtusGo.Core.Infra.Data.Context;
using VirtusGo.Core.Infra.Data.Repository;
using VirtusGo.Core.Infra.Data.UoW;

namespace VirtusGo.Core.Infra.CorssCutting.IoC
{
    public class NativeInjectorBootsrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //APSNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // ------------------------->   TODO: APPLICATION - SERVICE   <------------------------------------

            //TODO: Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(
                sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ICidadeAppService, CidadeAppService>();
            services.AddScoped<IEmpresaAppService, EmpresaAppService>();
            services.AddScoped<IEnderecoAppService, EnderecoAppService>();
            services.AddScoped<IEnderecoEstoqueAppService, EnderecoEstoqueAppService>();
            services.AddScoped<IEstadoAppService, EstadoAppService>();
            services.AddScoped<IItemOrdemCargaAppService, ItemOrdemCargaAppService>();
            services.AddScoped<IItensPedidoAppService, ItensPedidoAppService>();
            services.AddScoped<IMotoristaAppService, MotoristaAppService>();
            services.AddScoped<IOrdemCargaAppService, OrdemCargaAppService>();
            services.AddScoped<IParceiroAppService, ParceiroAppService>();
            services.AddScoped<IPedidoAppService, PedidoAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IRastreabilidadeAppService, RastreabilidadeAppService>();
            services.AddScoped<IRotaAppService, RotaAppService>();
            services.AddScoped<IVeiculoAppService, VeiculoAppService>();
            services.AddScoped<ICondicaoFinanceiraAppService, CondicaoFinanceiraAppService>();

            // ------------------------->   TODO: DOMAIN -  COMMANDS   <------------------------------------

            #region Cidade

            services.AddScoped<IHandler<RegistrarCidadeCommand>, CidadeCommandHandler>();
            services.AddScoped<IHandler<AtualizarCidadeCommand>, CidadeCommandHandler>();

            #endregion

            #region Estado

            services.AddScoped<IHandler<RegistrarEstadoCommand>, EstadoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEstadoCommand>, EstadoCommandHandler>();

            #endregion

            #region Endereco

            services.AddScoped<IHandler<RegistrarEnderecoCommand>, EnderecoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEnderecoCommand>, EnderecoCommandHandler>();

            #endregion

            #region Veiculo

            services.AddScoped<IHandler<RegistrarVeiculoCommand>, VeiculoCommandHandler>();
            services.AddScoped<IHandler<AtualizarVeiculoCommand>, VeiculoCommandHandler>();

            #endregion

            #region Produto

            services.AddScoped<IHandler<RegistrarProdutoCommand>, ProdutoCommandHandler>();
            services.AddScoped<IHandler<AtualizarProdutoCommand>, ProdutoCommandHandler>();

            #endregion

            #region Empresa

            services.AddScoped<IHandler<RegistrarEmpresaCommand>, EmpresaCommandHandler>();
            services.AddScoped<IHandler<AtualizarEmpresaCommand>, EmpresaCommandHandler>();

            #endregion

            #region Motorista

            services.AddScoped<IHandler<RegistrarMotoristaCommand>, MotoristaCommandHandler>();
            services.AddScoped<IHandler<AtualizarMotoristaCommand>, MotoristaCommandHandler>();

            #endregion

            #region Parceiro

            services.AddScoped<IHandler<RegistrarParceiroCommand>, ParceiroCommandHandler>();
            services.AddScoped<IHandler<AtualizarParceiroCommand>, ParceiroCommandHandler>();
            
            #region CondicaoFinanceira

            services.AddScoped<IHandler<RegistrarCondicaoFinanceiraCommand>, CondicaoFinanceiraCommandHandler>();
            services.AddScoped<IHandler<AtualizarCondicaoFinanceiraCommand>, CondicaoFinanceiraCommandHandler>();

            #endregion

            // ------------------------->   TODO: DOMAIN -  EVENTS   <------------------------------------

            //Beneficiario

            #region Beneficiario Events

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            #endregion

            // ------------------------->   TODO: INFRA -  DATA   <------------------------------------

            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEnderecoEstoqueRepository, EnderecoEstoqueRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IItemOrdemCargaRepository, ItemOrdemCargaRepository>();
            services.AddScoped<IItensPedidoRepository, ItensPedidoRepository>();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<IOrdemCargaRepository, OrdemCargaRepository>();
            services.AddScoped<IParceiroRepository, ParceiroRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IRastreabilidadeRepository, RastreabilidadeRepository>();
            services.AddScoped<IRotaRepository, RotaRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<ICondicaoFinanceiraRepository, CondicaoFinanceiraRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<VirtusContext>();

            // ------------------------->   TODO: INFRA -  BUS   <------------------------------------

            services.AddScoped<IBus, InMemoryBus>();


            //TODO: Infra - Identity
            //services.AddTransient<IEmailSender, EmailSender>();
            //services.AddScoped<IUser, AspNetUser>();

            ////TODO: Infra - UserClaims
            //services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyUserClaimsPrincipalFactory>();
        }
    }
}