using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Repositories;
using CinemaAppBackend.Services;
using CinemaAppBackend.UseCases;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace CinemaAppBackend
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IInitializeCinemaHall), typeof(InitializeCinemaHall));
            services.AddTransient(typeof(IShowCinemaHallCurrentStatus), typeof(ShowCinemaHallCurrentStatus));
            services.AddTransient(typeof(IBuyCinemaHallTicket), typeof(BuyCinemaHallHallTicket));
            services.AddTransient(typeof(IGenerateCinemaHallStatistics), typeof(GenerateCinemaHallStatistics));
            services.AddTransient(typeof(ICinemaHallValidationService), typeof(CinemaHallValidationService));
            services.AddSingleton(typeof(ICinemaAppBackendRepository),new CinemaAppBackendRepository(services.BuildServiceProvider()));
            return services;
        }
    }
}
