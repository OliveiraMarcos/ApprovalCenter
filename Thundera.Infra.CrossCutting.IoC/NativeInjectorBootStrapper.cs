using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Thundera.Domain.Core.Interfaces.Bus;
using Thundera.Domain.Core.Interfaces.Events;
using Thundera.Domain.Core.Interfaces.Repository.EventSourcing;
using Thundera.Domain.Core.Notifications;
using Thundera.Domain.General.Interfaces;
using Thundera.Infra.CrossCutting.Bus;
using Thundera.Infra.CrossCutting.Identity.Authorization;
using Thundera.Infra.CrossCutting.Identity.Interfaces.Services;
using Thundera.Infra.CrossCutting.Identity.Models;
using Thundera.Infra.CrossCutting.Identity.Services;
using Thundera.Infra.Data.Context;
using Thundera.Infra.Data.EventSourcing;
using Thundera.Infra.Data.Repository.EventSourcing;
using Thundera.Infra.Data.UoW;

namespace Thundera.Infra.CrossCutting.IoC
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
            services.AddDbContext<ThunderaContext>();

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
