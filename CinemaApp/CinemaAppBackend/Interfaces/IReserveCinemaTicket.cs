using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    public interface IReserveCinemaTicket
    {
        bool IsSeatAvailableForReservation(CinemaHall cinemaHall, int seatNumber);
        void ReserveTicket(CinemaHall cinemaHall, int seatNumber);
    }
}
