using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    public interface ICinemaAppBackendRepository
    {
        CinemaHall InitializeCinemaHall(string noOfRows, string noOfSeatsPerRow);
        void ShowCinemaHallCurrentStatus();

        CinemaHall BuyCinemaTicket(string rowNumber,string seatNumber);

        CinemaHallStatistics GenerateCinemaHallStatistics();
    }
}
