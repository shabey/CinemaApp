using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;

namespace CinemaAppBackend.UseCases
{
    public class CinemaHallBookingStatus:ICinemaHallBookingStatus
    {
        public void ShowCurrentBookingStatus(int[][] cinemaHall)
        {
            Validate(cinemaHall);
            Console.WriteLine($"Current booking status for cinema hall with {cinemaHall.Length} rows and {cinemaHall[0].Length} seats per row");
            for (int row = 0; row < cinemaHall.Length; row++)
            {
                var colLength = cinemaHall[row].Length;
                Console.WriteLine();
                Console.WriteLine($"Cinema hall row: {row+1}       ");
                for (int col = 0; col < colLength; col++)
                {
                    Console.Write($"(Seat number: {Utility.Utility.ConvertToIndex(row, col, colLength).ToString().PadLeft(1, '0')} Status: {Enum.GetName(typeof(Constants.BookingStatus),cinemaHall[row][col])}) ");
                }
                Console.WriteLine();
            }
        }

        private void Validate(int[][] cinemaHall)
        {
            if (cinemaHall == null)
            {
                throw new ArgumentNullException(nameof(cinemaHall),
                    "Cinema hall cannot be null. Kindly initialize cinema hall by selecting option A");
            }

            if (cinemaHall.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cinemaHall),"No of rows in cinema cannot be 0. Kindly initialize cinema hall by selecting option A");
            }
            if (cinemaHall[0].Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cinemaHall), "No of seats in cinema cannot be 0. Kindly initialize cinema hall by selecting option A");
            }
        }
    }
}
