using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.UseCases
{
    public class ShowCinemaHallBookingStatus : IShowCinemaHallBookingStatus
    {
        public void ShowCurrentBookingStatus(CinemaHall cinemaHall)
        {
            Validate(cinemaHall);
            Console.WriteLine($"Current booking status for cinema hall with {cinemaHall.NoOfRows} rows and {cinemaHall.NoOfSeatsPerRow} seats per row");
            Console.WriteLine();
            var prevRow = 1;
            foreach (var seat in cinemaHall.Seats.OrderBy(x=>x.SeatNumber))
            {
                var seatNumber = Utility.Utility.ConvertFromIndex(seat.SeatNumber, cinemaHall.NoOfSeatsPerRow);
                var rowNumber = seatNumber.Item1 + 1;
                var seatNo = seatNumber.Item2 + 1;
                if (prevRow != rowNumber)
                {
                    Console.WriteLine();
                    prevRow = rowNumber;
                }

                Console.WriteLine($"Row: {rowNumber} Seat: {seatNo} -> Status: {seat.BookingStatus}");

            }
        }

        private void Validate(CinemaHall cinemaHall)
        {
            if (cinemaHall == null)
            {
                throw new ArgumentNullException(nameof(cinemaHall),
                    "Cinema hall cannot be null. Kindly initialize cinema hall by selecting option A");
            }

            if (cinemaHall.NoOfRows == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cinemaHall), "No of rows in cinema cannot be 0. Kindly initialize cinema hall by selecting option A");
            }
            if (cinemaHall.NoOfSeatsPerRow == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cinemaHall), "No of seats in cinema cannot be 0. Kindly initialize cinema hall by selecting option A");
            }
        }
    }
}
