using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AprovationCenter.Domain.Core.Interfaces.Bus;
using AprovationCenter.Domain.Core.Interfaces.Events;
using AprovationCenter.Domain.Core.Interfaces.Repository.EventSourcing;
using AprovationCenter.Domain.Core.Notifications;
using AprovationCenter.Domain.General.Interfaces;
using AprovationCenter.Infra.CrossCutting.Bus;
using AprovationCenter.Infra.CrossCutting.Identity.Authorization;
using AprovationCenter.Infra.CrossCutting.Identity.Interfaces.Services;
using AprovationCenter.Infra.CrossCutting.Identity.Models;
using AprovationCenter.Infra.CrossCutting.Identity.Services;
using AprovationCenter.Infra.Data.Context;
using AprovationCenter.Infra.Data.EventSourcing;
using AprovationCenter.Infra.Data.Repository.EventSourcing;
using AprovationCenter.Infra.Data.UoW;

namespace AprovationCenter.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AprovationCenterContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddDbContext<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
