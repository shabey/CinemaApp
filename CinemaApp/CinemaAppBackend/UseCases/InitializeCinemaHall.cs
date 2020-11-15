using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.UseCases
{
    public class InitializeCinemaHall : IInitializeCinemaHall
    {
        public void InitializeCinemaHallSeats(CinemaHall cinemaHall)
        {
            for (var row = 0; row < cinemaHall.NoOfRows; row++)
            {
                for (var col = 0; col < cinemaHall.NoOfSeatsPerRow; col++)
                {
                    cinemaHall.Seats.Add(new CinemaSeat(row,col,cinemaHall.NoOfSeatsPerRow,cinemaHall.Capacity));
                }
            }
        }

        public bool ValidateCinemaHallDimensions(string noOfRows, string noOfSeatsPerRows)
        {
            if (!int.TryParse(noOfRows, out _))
            {
                throw new ArgumentOutOfRangeException(nameof(noOfRows), $"Invalid no of number of rows “{noOfRows}” entered. Please enter a valid number of number of rows");
            }
            if (!int.TryParse(noOfSeatsPerRows, out _))
            {
                throw new ArgumentOutOfRangeException(nameof(noOfSeatsPerRows), $"Invalid no of seats “{noOfSeatsPerRows}” entered. Please enter a valid number of seats");
            }

            return true;
        }
    }
}
