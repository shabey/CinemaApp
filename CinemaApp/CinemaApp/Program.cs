using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using CinemaApp.Controllers;
using CinemaAppBackend;
using CinemaAppBackend.Extensions;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Repositories;
using CinemaAppBackend.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace CinemaApp
{
    public class Program
    {
        private static ConsoleKeyInfo _choice;
        private static ICinemaAppBackendRepository _cinemaAppBackendRepository;
        private static IServiceProvider _serviceProvider;
        public static void Main(string[] args)
        {
            Log.Information($"Starting cinema hall backend app for {typeof(Program)}");

            try
            {
                Setup();
                _cinemaAppBackendRepository = _serviceProvider.GetService<ICinemaAppBackendRepository>();

                while (ShowOptionsMenu())
                {

                }
            }
            catch (Exception ex)
            {
                Log.Fatal($"Program terminated unexpectedly with exception: {ex}\n{ex.StackTrace}");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }




        private static bool ShowOptionsMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Cinemax cinema theater");
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("A)   Initialize cinema theater");
            Console.WriteLine("B)   Show cinema booking status");
            Console.WriteLine("C)   Buy a ticket for a specific seat");
            Console.WriteLine("D)   Cinema statistics");
            Console.WriteLine("E)   Exit");
            Console.Write("\r\nSelect an option: ");
            _choice = Console.ReadKey(false); // show the key as you read it
            switch (_choice.KeyChar.ToString().ToUpper())
            {
                case "A":
                    {
                        CinemaHallInitializationController.InitializeCinemaHall(_cinemaAppBackendRepository);
                        break;
                    }
                case "B":
                    {
                        CinemaHallBookingStatusController.ShowCurrentBookingStatus(_cinemaAppBackendRepository);
                        break;
                    }
                case "C":
                    {
                        CinemaHallTicketReservationController.ReserveCinemaTicket(_cinemaAppBackendRepository);
                        break;
                    }
                case "D":
                    {
                        CinemaHallStatisticsController.GenerateCinemaHallStatistics(_cinemaAppBackendRepository);
                        break;
                    }
                case "E":
                    {
                        CinemaHallExitController.ExitMenu();
                        return false;
                    }
            }

            return true;
        }

       private static void Setup()
       {
           IConfiguration configuration = new ConfigurationBuilder()
               .Build();

           Log.Logger = new LoggerConfiguration()
               .WriteTo.File("CinemaApp.log")
               .CreateLogger();

           var serviceCollection = new ServiceCollection();
           serviceCollection.AddServices();
           serviceCollection.AddLogging(configure => configure.AddSerilog());

           if (configuration["LOG_LEVEL"] == "true")
           {
               serviceCollection.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Trace);
           }
           else
           {
               serviceCollection.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Error);
           }

           _serviceProvider = serviceCollection.BuildServiceProvider();

           Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
       }

    }


}
