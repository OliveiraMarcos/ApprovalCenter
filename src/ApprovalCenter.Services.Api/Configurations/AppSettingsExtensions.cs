using Microsoft.Extensions.Configuration;
using ApprovalCenter.Infra.CrossCutting.Identity.Authorization.Jwt;
using Microsoft.Extensions.DependencyInjection;
using System;
using ApprovalCenter.Infra.CrossCutting.Identity.Services;

namespace ApprovalCenter.Services.Api.Configurations
{
    public static class AppSettingsExtensions
    {
        public static T GetSection<T>(this IConfiguration configuration, string name) 
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            return configuration.GetSection(name).Get<T>();
        }

        public static void AddOptionsSettings(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var appSettingsJwtSection = configuration.GetSection("Jwt");
            services.Configure<TokenConfigurations>(appSettingsJwtSection);

            var appSettingsMailConfSection = configuration.GetSection("MailConf");
            services.Configure<AuthMessageSenderOptions>(appSettingsMailConfSection);

        }
    }
}
