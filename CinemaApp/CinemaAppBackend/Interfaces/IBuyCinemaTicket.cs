﻿using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    internal interface IBuyCinemaTicket
    {
        bool IsSeatAvailableForReservation(CinemaHall cinemaHall, int seatNumber);
        void BuyTicket(CinemaHall cinemaHall, int seatNumber);
    }
}
