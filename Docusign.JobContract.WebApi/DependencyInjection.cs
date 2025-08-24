using Docusign.JobContract.API.Application;
using Docusign.JobContract.API.Infrastructure;
using Docusign.JobContract.API.Core;
using MyApp.Core;


namespace Docusign.JobContract.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddCoreDI(configuration);

            return services;
        }
    }
}
