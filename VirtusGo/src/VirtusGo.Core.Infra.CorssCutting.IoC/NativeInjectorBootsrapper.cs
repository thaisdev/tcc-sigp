using AutoMapper;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VirtusGo.Core.Application.Interfaces;
using VirtusGo.Core.Application.Services;
using VirtusGo.Core.Domain.Beneficiarios.Commands;
using VirtusGo.Core.Domain.Beneficiarios.Events;
using VirtusGo.Core.Domain.Beneficiarios.Repository;
using VirtusGo.Core.Domain.Cidade.Commands;
using VirtusGo.Core.Domain.Cidade.Repository;
using VirtusGo.Core.Domain.Core.Bus;
using VirtusGo.Core.Domain.Core.Events;
using VirtusGo.Core.Domain.Core.Notifications;
using VirtusGo.Core.Domain.Endereco.Commands;
using VirtusGo.Core.Domain.Endereco.Repository;
using VirtusGo.Core.Domain.Interfaces;
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
            services.AddScoped<ICidadeAppService, CidadeAppService>();
            services.AddScoped<IEnderecoAppService, EnderecoAppService>();

            // ------------------------->   TODO: DOMAIN -  COMMANDS   <------------------------------------

            //Beneficiario

            #region Beneficiario

            services.AddScoped<IHandler<RegistrarBeneficiarioCommand>, BeneficiarioCommandHandler>();
            services.AddScoped<IHandler<AtualizarBeneficiarioCommand>, BeneficiarioCommandHandler>();
            services.AddScoped<IHandler<ExcluirBeneficiarioCommand>, BeneficiarioCommandHandler>();
            services.AddScoped<IHandler<DesativarBeneficiarioCommand>, BeneficiarioCommandHandler>();
            services.AddScoped<IHandler<ReativarBeneficiarioCommand>, BeneficiarioCommandHandler>();

            #endregion

            #region Cidade

            services.AddScoped<IHandler<RegistrarCidadeCommand>, CidadeCommandHandler>();
            services.AddScoped<IHandler<AtualizarCidadeCommand>, CidadeCommandHandler>();

            #endregion

            #region Endereco

            services.AddScoped<IHandler<RegistrarEnderecoCommand>, EnderecoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEnderecoCommand>, EnderecoCommandHandler>();

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

            // ------------------------->   TODO: INFRA -  DATA   <------------------------------------

            services.AddScoped<IBeneficiarioRepository, BeneficiarioRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
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