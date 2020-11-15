using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace CinemaAppBackend
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, UseCaseConfiguration useCaseConfiguration)
        {
            services.AddSingleton(typeof(ICinemaAppBackendRepository),useCaseConfiguration.BuildCinemaAppBackendRepository());
            return services;
        }
    }
}
