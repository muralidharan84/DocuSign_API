using Docusign.JobContract.API.Application.DocuSign;
using Docusign.JobContract.API.Infrastructure.Data;
using Docusign.JobContract.API.Infrastructure.Repositories;
using Docusign.JobContract.API.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyApp.Core.Interfaces;
using MyApp.Core.Options;

namespace Docusign.JobContract.API.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();

            services.AddHttpClient<IDocuSignApiClient, DocuSignService>(option =>
            {
                option.BaseAddress = new Uri("https://demo.docusign.net/restapi");
            });

            services.AddScoped<IEnvelopeLogRepository, EnvelopeLogRepository>();
            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();

            //services.AddScoped<IPdfGenerator, PdfGenerationService>();

            //services.AddHttpClient<IJokeHttpClientService, JokeHttpClientService>(option =>
            //{
            //    option.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
            //});

            return services;
        }
    }
}
