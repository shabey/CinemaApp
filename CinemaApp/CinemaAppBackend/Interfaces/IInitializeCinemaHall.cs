using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    public interface IInitializeCinemaHall
    {
        bool ValidateCinemaHallDimensions(string noOfRows, string noOfSeatsPerRows); 
        void InitializeCinemaHallSeats(CinemaHall cinemaHall);
    }
}
