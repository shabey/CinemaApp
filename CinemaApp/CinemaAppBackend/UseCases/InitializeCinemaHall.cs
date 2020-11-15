using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;

namespace CinemaAppBackend.UseCases
{
    public class InitializeCinemaHall : IInitializeCinemaHall
    {
        public int[][] Initialize(string rows, string seats)
        {
            Validate(rows, seats); //Call validation
            
            var noOfRows = int.Parse(rows); 
            var noOfSeats = int.Parse(seats);

            var cinemaRoom = new int[noOfRows][];

            for (var row = 0; row < noOfRows; row++)
            {
                cinemaRoom[row] = new int[noOfSeats]; // initialize no of seats per row
                for (var col = 0; col < cinemaRoom[row].Length; col++)
                {
                    cinemaRoom[row][col] = (int)Constants.BookingStatus.Available; // make all seats available for booking
                }
            }

            return cinemaRoom;
        }

        private void Validate(string noOfRows, string noOfSeats)
        {
            if (!int.TryParse(noOfRows, out _))
            {
                throw new ArgumentOutOfRangeException(nameof(noOfRows), $"Invalid no of number of rows “{noOfRows}” entered. Please enter a valid number of number of rows");
            }
            if (!int.TryParse(noOfSeats, out _))
            {
                throw new ArgumentOutOfRangeException(nameof(noOfSeats), $"Invalid no of seats “{noOfSeats}” entered. Please enter a valid number of seats");
            }
        }
    }
}
