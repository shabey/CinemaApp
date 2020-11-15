using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Services
{
    public class CinemaHallValidationService:ICinemaHallValidationService
    {
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
        public bool ValidateCinemaHall(CinemaHall cinemaHall)
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

            return true;
        }

        public bool ValidateSeatReservation(string rowNumber, string seatNumber, CinemaHall cinemaHall)
        {
            if (cinemaHall == null)
            {
                throw new ArgumentNullException(nameof(cinemaHall),
                    "Cinema hall cannot be null. Kindly initialize cinema hall by selecting option A");
            }

            if (!int.TryParse(rowNumber, out var row) || row <= 0 || row > cinemaHall.NoOfRows)
            {
                throw new ArgumentOutOfRangeException(nameof(rowNumber), $"Invalid row number “{rowNumber}” entered. Please enter a valid row number");
            }
            if (!int.TryParse(seatNumber, out var seat) || seat <=0 || seat > cinemaHall.NoOfSeatsPerRow)
            {
                throw new ArgumentOutOfRangeException(nameof(rowNumber), $"Invalid seat number “{seatNumber}” entered. Please enter a valid seat number");
            }

            return true;
        }
    }
}
