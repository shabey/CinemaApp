using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Models
{
    public class CinemaSeat
    {
        public string SeatNumber { get; set; }
        public Constants.BookingStatus BookingStatus { get; set; }
        public float Price { get; set; }
    }
}
