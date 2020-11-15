using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Extensions
{
    public static class CinemaHallSeatExtension
    {
        public static float GetTicketPrice(this CinemaSeat seat, int totalCapacity = 50)
        {
            if (totalCapacity > 50 && seat.SeatNumber > (totalCapacity / 2))
            {
                return 12.0f;
            }

            return 10.0f;
        }
    }
}
