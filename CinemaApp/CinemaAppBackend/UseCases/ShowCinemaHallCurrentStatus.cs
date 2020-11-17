using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.UseCases
{
    internal class ShowCinemaHallCurrentStatus : IShowCinemaHallCurrentStatus
    {
        public void ShowCurrentBookingStatus(CinemaHall cinemaHall)
        {
            Console.WriteLine();
            Console.WriteLine($"Current booking status for cinema hall with {cinemaHall.NoOfRows} rows and {cinemaHall.NoOfSeatsPerRow} seats per row");
            Console.WriteLine();
            var prevRow = 1;
            foreach (var seat in cinemaHall.Seats.OrderBy(x=>x.SeatNumber))
            {
                var seatNumber = Utility.Utility.ConvertFromIndex(seat.SeatNumber, cinemaHall.NoOfSeatsPerRow);
                var rowNumber = seatNumber.Item1 + 1;
                var seatNo = seatNumber.Item2 + 1;
                if (prevRow != rowNumber) // logic for adding seperator after¨row ends
                {
                    Console.WriteLine();
                    prevRow = rowNumber;
                }

                Console.ForegroundColor = seat.BookingStatus == Constants.BookingStatus.Reserved ? ConsoleColor.Red : ConsoleColor.Green;

                Console.WriteLine($"Row: {rowNumber} Seat: {seatNo} -> Status: {seat.BookingStatus}");

            }
            Console.ResetColor();
        }

        
    }
}
