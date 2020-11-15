using System;
using System.Reflection;
using CinemaApp.Extensions;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Repositories;

namespace CinemaApp
{
    public class Program
    {
        private static ConsoleKeyInfo _choice;
        private static ICinemaAppBackendRepository _cinemaAppBackendRepository;
        public static void Main(string[] args)
        {
            _cinemaAppBackendRepository = new CinemaAppBackendRepository();
            while (ShowOptionsMenu())
            {

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
                    return true;
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
                _cinemaAppBackendRepository.Initialize(noOfRows, noOfSeats);
                _cinemaAppBackendRepository.ShowCurrentBookingStatus();
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
            }
            catch (Exception e)
            {
                e.HandleError("Error showing current booking status for cinema hall");
            }

        }
    }
}
