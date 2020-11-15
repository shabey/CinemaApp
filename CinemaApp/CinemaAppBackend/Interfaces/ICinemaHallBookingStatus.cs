using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Interfaces
{
    public interface ICinemaHallBookingStatus
    {
        void ShowCurrentBookingStatus(int[][] cinemaHall);
    }
}
