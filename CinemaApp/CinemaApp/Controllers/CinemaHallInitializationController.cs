using System;
using CinemaAppBackend.Extensions;
using CinemaAppBackend.Interfaces;

namespace CinemaApp.Controllers
{
    public static class CinemaHallInitializationController
    {
        public static void InitializeCinemaHall(ICinemaAppBackendRepository cinemaAppBackendRepository)
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
                cinemaAppBackendRepository.InitializeCinemaHall(noOfRows, noOfSeats);
                CinemaHallBookingStatusController.ShowCurrentBookingStatus(cinemaAppBackendRepository);
            }
            catch (Exception e)
            {
                e.HandleException("Error initializing cinema hall");
            }

        }
    }
}
