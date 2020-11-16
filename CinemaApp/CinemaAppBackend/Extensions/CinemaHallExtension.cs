using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Extensions
{
    public static class CinemaHallExtension
    {
        public static int GetNumberOfPurchasedTickets(this CinemaHall cinemaHall)
        {
            return cinemaHall.Seats.Count(x => x.BookingStatus == Constants.BookingStatus.Reserved);
        }
        public static float GetPercentageOccupied(this CinemaHall cinemaHall)
        {
            return cinemaHall.Capacity > 0 ? ((float)GetNumberOfPurchasedTickets(cinemaHall) / cinemaHall.Capacity) : 0;
        }
        /// <summary>
        /// Current income (sum of reserved tickets)
        /// </summary>
        /// <param name="cinemaHall"></param>
        /// <returns></returns>
        public static float GetCurrentIncome(this CinemaHall cinemaHall)
        {
            return cinemaHall.Seats.Where(x=>x.BookingStatus == Constants.BookingStatus.Reserved).Sum(x =>x.TicketPrice);
        }
        /// <summary>
        /// Potential total income (sum of all available and reserved tickets)
        /// </summary>
        /// <param name="cinemaHall"></param>
        /// <returns></returns>
        public static float GetPotentialTotalIncome(this CinemaHall cinemaHall)
        {
            return cinemaHall.Seats.Sum(x => x.TicketPrice);
        }
    }
}
