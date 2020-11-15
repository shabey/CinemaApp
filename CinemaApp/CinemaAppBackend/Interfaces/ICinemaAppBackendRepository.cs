using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Interfaces
{
    public interface ICinemaAppBackendRepository
    {
        void InitializeCinemaHall(string noOfRows, string noOfSeatsPerRow);
        void ShowCurrentBookingStatus();
    }
}
