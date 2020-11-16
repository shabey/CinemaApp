using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Interfaces
{
    public interface ICinemaAppBackendRepository
    {
        void InitializeCinemaHall(string noOfRows, string noOfSeatsPerRow);
        void ShowCinemaHallCurrentStatus();

        void BuyCinemaTicket(string rowNumber,string seatNumber);

        void GenerateCinemaHallStatistics();
    }
}
