using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Extensions
{
    public static class CinemaHallSeatExtension
    {
        //If the capacity is over 50 people, the front half rows cost $12, the back half cost $10. If capacity 50 or below, all cost $10
        private static readonly int _capacityLimit = 50;
        private static readonly float _frontHalfRowPrice = 12.0f;
        private static readonly float _defaultPrice = 10.0f;
        public static float GetTicketPrice(this CinemaSeat seat, int totalCapacity)
        {
            if ((totalCapacity > _capacityLimit) && (seat.SeatNumber < (totalCapacity / 2)))
            {
                return _frontHalfRowPrice;
            }

            return _defaultPrice;
        }
    }
}
