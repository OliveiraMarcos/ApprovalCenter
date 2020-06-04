using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ApprovalCenter.Services.Api.Configurations
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationRoot BuildEnv(this IConfigurationBuilder builder)
        {
            var configuration = builder.Build();

            configuration.Providers.OfType<JsonConfigurationProvider>()
                .ToList().ForEach(provider =>
                {
                    var dicts = string.Join(",", provider.GetData().Keys);
                    foreach (var key in dicts.Split(","))
                    {
                        var key_env = key.Replace(":", "_").ToUpper();
                        var value = Environment.GetEnvironmentVariable(key_env);

                        if (!string.IsNullOrWhiteSpace(value))
                            provider.Set(key, value);
                    }
                });

            return configuration;
        }

        public static IDictionary<string, string> GetData(this JsonConfigurationProvider provider)
        {
            var dict = provider.GetType().BaseType
                .GetProperty("Data", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(provider);
            return (IDictionary<string, string>)dict;
        }
    }
}
