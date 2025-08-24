using Docusign.JobContract.API.Core.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Options;

namespace Docusign.JobContract.API.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
            services.AddScoped<DocuSignJWTHelper>();

            return services;
        }
    }
}


