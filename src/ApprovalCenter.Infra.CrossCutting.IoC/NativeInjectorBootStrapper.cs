

using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Application.Services;
using ApprovalCenter.Domain.Approval.EventHandler;
using ApprovalCenter.Domain.Approval.Events;
using ApprovalCenter.Domain.Approval.Interfaces.Repository;
using ApprovalCenter.Domain.Category.EventHandlers;
using ApprovalCenter.Domain.Category.Events;
using ApprovalCenter.Domain.Category.Interfaces;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Interfaces.Events;
using ApprovalCenter.Domain.Core.Interfaces.Repository.EventSourcing;
using ApprovalCenter.Domain.Core.Notifications;
using ApprovalCenter.Domain.General.Interfaces;
using ApprovalCenter.Infra.CrossCutting.Bus;
using ApprovalCenter.Infra.CrossCutting.Identity.Authorization;
using ApprovalCenter.Infra.CrossCutting.Identity.Interfaces.Services;
using ApprovalCenter.Infra.CrossCutting.Identity.Models;
using ApprovalCenter.Infra.CrossCutting.Identity.Services;
using ApprovalCenter.Infra.Data.Context;
using ApprovalCenter.Infra.Data.EventSourcing;
using ApprovalCenter.Infra.Data.Repository;
using ApprovalCenter.Infra.Data.Repository.EventSourcing;
using ApprovalCenter.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ApprovalCenter.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Application 
            services.AddScoped<ICategoryAppService, CategoryAppService>();
            services.AddScoped<IApprovalAppService, ApprovalAppService>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CategoryInsertEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryUpdateEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryDeleteEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<ApprovalInsertEvent>, ApprovalEventHandler>();
            services.AddScoped<INotificationHandler<ApprovalUpdateEvent>, ApprovalEventHandler>();
            services.AddScoped<INotificationHandler<ApprovalDeleteEvent>, ApprovalEventHandler>();

            // Infra - Data
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IApprovalRepository, ApprovalRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApprovalCenterContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
