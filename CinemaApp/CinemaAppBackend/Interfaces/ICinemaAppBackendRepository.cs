using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Interfaces
{
    public interface ICinemaAppBackendRepository
    {
        void Initialize(string noOfRows, string noOfSeats);
        void ShowCurrentBookingStatus();
    }
}
