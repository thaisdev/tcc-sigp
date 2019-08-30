using AutoMapper;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Virtus.Core.Application.Services;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.Services;
using VirtusGo.Core.Domain.Beneficiarios.Commands;
using VirtusGo.Core.Domain.Beneficiarios.Events;
using VirtusGo.Core.Domain.Beneficiarios.Repository;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.CotacaoPontos.Commands;
using VirtusGo.Core.Domain.CotacaoPontos.Events;
using VirtusGo.Core.Domain.CotacaoPontos.Repository;
using VirtusGo.Core.Domain.Empresa.Commands;
using VirtusGo.Core.Domain.Empresa.Events;
using VirtusGo.Core.Domain.Empresa.Repository;
using VirtusGo.Core.Domain.EmpresaUsuarios.Command;
using VirtusGo.Core.Domain.EmpresaUsuarios.Repository;
using VirtusGo.Core.Domain.Faixas.Commands;
using VirtusGo.Core.Domain.Faixas.Events;
using VirtusGo.Core.Domain.Faixas.Repository;
using VirtusGo.Core.Domain.Interfaces;
using VirtusGo.Core.Domain.Parametro.Command;
using VirtusGo.Core.Domain.Parametro.Event;
using VirtusGo.Core.Domain.Parametro.Repository;
using VirtusGo.Core.Domain.Pontuacao.Commands;
using VirtusGo.Core.Domain.Pontuacao.Events;
using VirtusGo.Core.Domain.Pontuacao.Repository;
using VirtusGo.Core.Domain.PontuacaoFococlub.Repository;
using VirtusGo.Core.Domain.PontuacaoFocoClub.Commands;
using VirtusGo.Core.Domain.PontuacaoPdv.Commands;
using VirtusGo.Core.Domain.PontuacaoPdv.Events;
using VirtusGo.Core.Domain.PontuacaoPdv.Repository;
using VirtusGo.Core.Domain.Unidades.Commands;
using VirtusGo.Core.Domain.Unidades.Events;
using VirtusGo.Core.Domain.Unidades.Repository;
using VirtusGo.Core.Domain.UnidadeUsuarios.Commands;
using VirtusGo.Core.Domain.UnidadeUsuarios.Repository;
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
            services.AddScoped<IBeneficiarioAppService, BeneficiarioAppService>();
            services.AddScoped<ICotacaoPontosAppService, CotacaoPontosAppService>();
            services.AddScoped<IEmpresaAppService, EmpresaAppService>();
            services.AddScoped<IUnidadeAppService, UnidadeAppService>();
            services.AddScoped<IPontuacaoPdvAppService, PontuacaoPdvAppService>();
            services.AddScoped<IPontuacaoAppService, PontuacaoAppService>();
            services.AddScoped<IPontuacaoFococlubAppService, PontuacaoFococlubAppService>();
            services.AddScoped<IFaixaAppService, FaixaAppService>();
            services.AddScoped<IParametroAppService, ParametroAppService>();
            services.AddScoped<IEmpresaUsuarioAppService, EmpresaUsuarioAppService>();
            services.AddScoped<IUnidadeUsuarioAppService, UnidadeUsuarioAppService>();

            // ------------------------->   TODO: DOMAIN -  COMMANDS   <------------------------------------

            //Beneficiario

            #region Beneficiario

            services.AddScoped<IHandler<RegistrarBeneficiarioCommand>, BeneficiarioCommandHandler>();
            services.AddScoped<IHandler<AtualizarBeneficiarioCommand>, BeneficiarioCommandHandler>();
            services.AddScoped<IHandler<ExcluirBeneficiarioCommand>, BeneficiarioCommandHandler>();
            services.AddScoped<IHandler<DesativarBeneficiarioCommand>, BeneficiarioCommandHandler>();
            services.AddScoped<IHandler<ReativarBeneficiarioCommand>, BeneficiarioCommandHandler>();

            #endregion

            //Empresa

            #region Empresa

            services.AddScoped<IHandler<RegistrarEmpresaCommand>, EmpresaCommandHandler>();
            services.AddScoped<IHandler<AtualizarEmpresaCommand>, EmpresaCommandHandler>();
            services.AddScoped<IHandler<ExcluirEmpresaCommand>, EmpresaCommandHandler>();
            services.AddScoped<IHandler<DesativarEmpresaCommand>, EmpresaCommandHandler>();
            services.AddScoped<IHandler<ReativarEmpresaCommand>, EmpresaCommandHandler>();

            #endregion
            
            //Empresa Usuários

            #region Empresa Usuarios

            services.AddScoped<IHandler<RegistrarEmpresaUsuariosCommand>, EmpresaUsuariosCommandHandler>();

            #endregion

            //Faixa

            #region Faixa

            services.AddScoped<IHandler<RegistrarFaixaCommand>, FaixaCommandHandler>();
            services.AddScoped<IHandler<AtualizarFaixaCommand>, FaixaCommandHandler>();
            services.AddScoped<IHandler<ExcluirFaixaCommand>, FaixaCommandHandler>();

            #endregion

            //Unidade

            #region Unidade

            services.AddScoped<IHandler<RegistrarUnidadeCommand>, UnidadeCommandHandler>();
            services.AddScoped<IHandler<AtualizarUnidadeCommand>, UnidadeCommandHandler>();
            services.AddScoped<IHandler<ExcluirUnidadeCommand>, UnidadeCommandHandler>();
            services.AddScoped<IHandler<DesativarUnidadeCommand>, UnidadeCommandHandler>();
            services.AddScoped<IHandler<ReativarUnidadeCommand>, UnidadeCommandHandler>();

            #endregion

            //Unidade Usuários

            #region Unidade Usuarios

            services.AddScoped<IHandler<RegistrarUnidadeUsuariosCommand>, UnidadeUsuariosCommandHandler>();

            #endregion

            //Pontuacao

            #region Pontuacao

            services.AddScoped<IHandler<RegistrarPontuacaoCommand>, PontuacaoCommandHandler>();
            services.AddScoped<IHandler<AtualizarPontuacaoCommand>, PontuacaoCommandHandler>();
            services.AddScoped<IHandler<ExcluirPontuacaoCommand>, PontuacaoCommandHandler>();
            services.AddScoped<IHandler<DesativarPontuacaoCommand>, PontuacaoCommandHandler>();

            #endregion
            
            //PontuacaoFococlub

            #region PontuacaoFococlub

            services.AddScoped<IHandler<RegistrarPontuacaoFococlubCommand>, PontuacaoFococlubCommandHandler>();

            #endregion
            
            //PontuacaoPDV

            #region PontuacaoPdv

            services.AddScoped<IHandler<ExcluirPdvCommand>, PdvCommandHandler>();
            services.AddScoped<IHandler<AprovarPdvCommand>, PdvCommandHandler>();

            #endregion

            //Cotacao

            #region CotacaoPontos

            services.AddScoped<IHandler<RegistrarCotacaoPontosCommand>, CotacaoPontosCommandHandler>();
            services.AddScoped<IHandler<AtualizarCotacaoPontosCommand>, CotacaoPontosCommandHandler>();
            services.AddScoped<IHandler<ExcluirCotacaoPontosCommand>, CotacaoPontosCommandHandler>();
            services.AddScoped<IHandler<DesativarCotacaoCommand>, CotacaoPontosCommandHandler>();

            #endregion

            //Parametro

            #region Parametro

            services.AddScoped<IHandler<RegistrarParametroCommand>, ParametroCommandHandler>();
            services.AddScoped<IHandler<AtualizarParametroCommand>, ParametroCommandHandler>();
            services.AddScoped<IHandler<DesativarParametroCommand>, ParametroCommandHandler>();

            #endregion

            // ------------------------->   TODO: DOMAIN -  EVENTS   <------------------------------------

            //Beneficiario

            #region Beneficiario Events

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<BeneficiarioRegistradoEvent>, BeneficiarioEventHandler>();
            services.AddScoped<IHandler<BeneficiarioAtualizadoEvent>, BeneficiarioEventHandler>();
            services.AddScoped<IHandler<BeneficiarioExcluidoEvent>, BeneficiarioEventHandler>();
            services.AddScoped<IHandler<BeneficiarioDesativadoEvent>, BeneficiarioEventHandler>();
            services.AddScoped<IHandler<BeneficiarioReativadoEvent>, BeneficiarioEventHandler>();

            #endregion

            //Empresa

            #region Empresa Events

            services.AddScoped<IHandler<EmpresaRegistradaEvent>, EmpresaEventHandler>();
            services.AddScoped<IHandler<EmpresaAtualizadaEvent>, EmpresaEventHandler>();
            services.AddScoped<IHandler<EmpresaExcluidaEvent>, EmpresaEventHandler>();
            services.AddScoped<IHandler<EmpresaDesativadaEvent>, EmpresaEventHandler>();
            services.AddScoped<IHandler<EmpresaReativadaEvent>, EmpresaEventHandler>();

            #endregion

            //Faixa

            #region Faixa Events

            services.AddScoped<IHandler<FaixaRegistradaEvent>, FaixaEventHandler>();
            services.AddScoped<IHandler<FaixaAtualizadaEvent>, FaixaEventHandler>();
            services.AddScoped<IHandler<FaixaExcluidaEvent>, FaixaEventHandler>();

            #endregion

            //Unidade

            #region Unidade Events

            services.AddScoped<IHandler<UnidadeRegistradaEvent>, UnidadeEventHandler>();
            services.AddScoped<IHandler<UnidadeAtualizadaEvent>, UnidadeEventHandler>();
            services.AddScoped<IHandler<UnidadeExcluidaEvent>, UnidadeEventHandler>();
            services.AddScoped<IHandler<UnidadeDesativadaEvent>, UnidadeEventHandler>();
            services.AddScoped<IHandler<UnidadeReativadaEvent>, UnidadeEventHandler>();

            #endregion

            //Pontuacao

            #region Pontuacao Events

            services.AddScoped<IHandler<PontuacaoRegistradaEvent>, PontuacaoEventHandler>();
            services.AddScoped<IHandler<PontuacaoAtualizadaEvent>, PontuacaoEventHandler>();
            services.AddScoped<IHandler<PontuacaoExcluidaEvent>, PontuacaoEventHandler>();
            services.AddScoped<IHandler<PontuacaoDesativadaEvent>, PontuacaoEventHandler>();

            #endregion
            
            //PontuacaoPDV

            #region PontuacaoPdv Events

            services.AddScoped<IHandler<PdvExcluidoEvent>, PdvEventHandler>();
            services.AddScoped<IHandler<PdvAprovadoEvent>, PdvEventHandler>();

            #endregion

            //Cotacao

            #region CotacaoPontos

            services.AddScoped<IHandler<CotacaoPontosRegistradoEvent>, CotacaoPontosEventHandler>();
            services.AddScoped<IHandler<CotacaoPontosAtualizadaEvent>, CotacaoPontosEventHandler>();
            services.AddScoped<IHandler<CotacaoPontosExcluidoEvent>, CotacaoPontosEventHandler>();
            services.AddScoped<IHandler<CotacaoDesativadaEvent>, CotacaoPontosEventHandler>();

            #endregion

            //Parametro

            #region Parametro

            services.AddScoped<IHandler<ParametroRegistradoEvent>, ParametroEvenHandler>();
            services.AddScoped<IHandler<ParametroAtualizadoEvent>, ParametroEvenHandler>();
            services.AddScoped<IHandler<ParametroDesativadoEvent>, ParametroEvenHandler>();

            #endregion


            // ------------------------->   TODO: INFRA -  DATA   <------------------------------------

            services.AddScoped<IBeneficiarioRepository, BeneficiarioRepository>();
            services.AddScoped<ICotacaoPontosRepository, CotacaoPontosRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped<IPontuacaoPDVRepository, PontuacaoPdvRepository>();
            services.AddScoped<IPontuacaoRepository, PontuacaoRepository>();
            services.AddScoped<IPontuacaoFococlubRepository, PontuacaoFococlubRepository>();
            services.AddScoped<IFaixaRepository, FaixaRepository>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<IEmpresaUsuarioRepository, EmpresaUsuariosRepository>();
            services.AddScoped<IUnidadeUsuarioRepository, UnidadeUsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<VirtusContext>();
            services.AddScoped<FococlubContext>();

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