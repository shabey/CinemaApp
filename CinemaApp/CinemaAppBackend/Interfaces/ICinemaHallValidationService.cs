using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    internal interface ICinemaHallValidationService
    {
        bool ValidateCinemaHallDimensions(string noOfRows, string noOfSeatsPerRows);
        bool ValidateCinemaHall(CinemaHall cinemaHall);

        bool ValidateSeatReservation(string rowNumber, string seatNumber, CinemaHall cinemaHall);

    }
}
