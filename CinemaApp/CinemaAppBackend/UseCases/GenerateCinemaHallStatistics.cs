using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Extensions;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.UseCases
{
    internal class GenerateCinemaHallStatistics:IGenerateCinemaHallStatistics
    {
        public CinemaHallStatistics GetCinemaHallStatistics(CinemaHall cinemaHall)
        {
            return new CinemaHallStatistics()
            {
                NumberOfPurchasedTickets = cinemaHall.GetNumberOfPurchasedTickets(),
                TotalNumbersOfSeats = cinemaHall.Capacity,
                PercentageOccupied = cinemaHall.GetPercentageOccupied(),
                CurrentIncome = cinemaHall.GetCurrentIncome(),
                PotentialTotalIncome = cinemaHall.GetPotentialTotalIncome()
            };
        }
    }
}
