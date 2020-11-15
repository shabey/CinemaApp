using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;

namespace CinemaAppBackend.UseCases
{
    public class InitializeCinemaHall:IInitializeCinemaHall
    {
        public void Initialize(Char[][] cinemaRoom, int noOfRows, int noOfSeats)
        {
            try
            {
                Validate(noOfRows,noOfSeats);

                cinemaRoom = new char[noOfRows][];
                for (var row = 0; row < noOfRows; row++)
                {
                    cinemaRoom[row] = new char[noOfSeats]; // initialize no of seats per row
                    for (var col = 0; col < cinemaRoom[row].Length; col++)
                    {
                        cinemaRoom[row][col] = 'A'; // make all seats available for booking
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        private void Validate(int noOfRows, int noOfSeats)
        {
            if (noOfRows <= 0 || noOfRows >= int.MaxValue)
            {
                throw new Exception($"Invalid no of number of rows {noOfRows} entered. Please enter a valid number of number of rows");
            }
            if (noOfSeats <= 0 || noOfSeats >= int.MaxValue)
            {
                throw new Exception($"Invalid no of seats {noOfSeats} entered. Please enter a valid number of seats");
            }
        }
    }
}
