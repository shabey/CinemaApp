﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CinemaAppBackend.Extensions;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.UseCases
{
    internal class BuyCinemaHallHallTicket:IBuyCinemaHallTicket
    {
        public bool IsSeatAvailableForReservation(CinemaHall cinemaHall,int seatNumber)
        {
            return cinemaHall.Seats.Any(x=>x.SeatNumber == seatNumber && x.BookingStatus == Constants.BookingStatus.Available);
        }

        public CinemaSeat BuyTicket(CinemaHall cinemaHall, int seatNumber)
        {
            var cinemaSeat = cinemaHall.Seats.Find(x => x.SeatNumber == seatNumber);
            cinemaSeat.BookingStatus = Constants.BookingStatus.Reserved;
            cinemaSeat.TicketPrice = cinemaSeat.GetTicketPrice(cinemaHall.TotalCapacity);
            return cinemaSeat;
        }
    }
}
