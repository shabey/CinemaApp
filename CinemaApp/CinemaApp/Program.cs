using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using CinemaAppBackend;
using CinemaAppBackend.Extensions;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Repositories;
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
            Setup();

            try
            {
                Log.Information($"Starting cinema hall backend app for {typeof(Program)}");
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
                        ShowCinemaHallInitializationMenu();
                        break;
                    }
                case "B":
                    {
                        ShowCurrentBookingStatus();
                        break;
                    }
                case "C":
                    {
                        ReserveCinemaTicket();
                        break;
                    }
                case "D":
                    return true;
                case "E":
                    return false;
                default:
                    return true;
            }

            return true;
        }

        private static void ShowCinemaHallInitializationMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter “number of rows” and “number of seats per row” for the cinema hall");
                Console.WriteLine();
                Console.Write("Enter no of rows: ");
                var noOfRows = Console.ReadLine();
                Console.Write("Enter no of seats: ");
                var noOfSeats = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();
                _cinemaAppBackendRepository.InitializeCinemaHall(noOfRows, noOfSeats);
                ShowCurrentBookingStatus();
            }
            catch (Exception e)
            {
                e.HandleError("Error initializing cinema hall");
            }

        }
        private static void ShowCurrentBookingStatus()
        {
            try
            {
                Console.Clear();
                _cinemaAppBackendRepository.ShowCurrentBookingStatus();
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to main menu !!!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                e.HandleError("Error showing current booking status for cinema hall");
            }

        }
        private static void ReserveCinemaTicket()
        {
            try
            {
                ConsoleKeyInfo reserveAnotherSeat;
                do
                {
                    Console.Clear();
                    _cinemaAppBackendRepository.ShowCurrentBookingStatus();
                    Console.WriteLine();
                    Console.WriteLine("Enter “seat number” for ticket reservation");
                    Console.WriteLine();
                    Console.Write("Enter row number: ");
                    var rowNumber = Console.ReadLine();
                    Console.Write("Enter seat number: ");
                    var seatNumber = Console.ReadLine();
                    Console.WriteLine();
                    Console.Clear();
                    _cinemaAppBackendRepository.ReserveCinemaTicket(rowNumber, seatNumber);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Thank you for your reservation. Your seat is reserved at row {rowNumber} and seat number {seatNumber}");
                    Console.ResetColor();
                    _cinemaAppBackendRepository.ShowCurrentBookingStatus();
                    Console.WriteLine();
                    Console.Write("Do you want to reserve another seat? (Y/N): ");
                    reserveAnotherSeat = Console.ReadKey(false); // show the key as you read it   
                } while (reserveAnotherSeat.KeyChar.ToString().ToUpper() != "N");
            }
            catch (Exception e)
            {
                e.HandleError($"Error reserving ticket");
            }
        }
        private static void Setup()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("CinemaApp.log")
                .CreateLogger();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(configure => configure.AddSerilog());

            if (configuration["LOG_LEVEL"] == "true")
            {
                services.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Trace);
            }
            else
            {
                services.Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Error);
            }

            var useCaseConfiguration = new UseCaseConfiguration().
                BuildCinemaHallValidationService().
                BuildCinemaHallInitializationService().
                BuildShowCinemaHallBookingStatusService().
                BuildCinemaTicketReservationService();


            services.AddServices(useCaseConfiguration);

        }
    }


}
