using JobCandidateHubAPI.Data.IRepositories;
using JobCandidateHubAPI.Data.Repositories;
using JobCandidateHubAPI.Service.Interfaces;
using JobCandidateHubAPI.Service.Services;
using Microsoft.OpenApi.Models;
using Serilog;

namespace JobCandidateHubAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICandidateService, CandidateService>();
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JobCandidateHubAPI", Version = "v1" });
            });
        }

        public static void AddLoggerService(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
            );
        }
    }
}
