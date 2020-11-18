using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    internal interface IBuyCinemaHallTicket
    {
        bool IsSeatAvailableForReservation(CinemaHall cinemaHall, int seatNumber);
        CinemaSeat BuyTicket(CinemaHall cinemaHall, int seatNumber);
    }
}
