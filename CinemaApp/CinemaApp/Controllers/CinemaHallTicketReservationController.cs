using System;
using CinemaAppBackend.Extensions;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Utility;

namespace CinemaApp.Controllers
{
    public class CinemaHallTicketReservationController
    {
        public static void ReserveCinemaTicket(ICinemaAppBackendRepository cinemaAppBackendRepository)
        {
            try
            {
                do
                {
                    Console.Clear();
                    cinemaAppBackendRepository.ShowCinemaHallCurrentStatus();
                    Console.WriteLine();
                    Console.WriteLine("Enter “seat number” for ticket reservation");
                    Console.WriteLine();
                    Console.Write("Enter row number: ");
                    var rowNumber = Console.ReadLine();
                    Console.Write("Enter seat number: ");
                    var seatNumber = Console.ReadLine();
                    Console.WriteLine();
                    Console.Clear();
                    cinemaAppBackendRepository.BuyCinemaTicket(rowNumber, seatNumber);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Thank you for your reservation. Your seat is reserved at row {rowNumber} and seat number {seatNumber}");
                    Console.ResetColor();
                    cinemaAppBackendRepository.ShowCinemaHallCurrentStatus();
                    Console.WriteLine();
                } while (Utility.Confirm("Do you want to reserve another seat?"));
            }
            catch (Exception e)
            {
                e.HandleException($"Error reserving ticket");
            }
        }
    }
}
