using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Models
{
    public class CinemaSeat
    {
        public int SeatNumber { get; set; }
        public Constants.BookingStatus BookingStatus { get; set; }
        public float Price { get; set; }

        public CinemaSeat(int rowNo,int seatNo,int noOfSeatsPerRow,int totalCapacity)
        {
            this.SeatNumber = Utility.Utility.ConvertToIndex(rowNo, seatNo, noOfSeatsPerRow);
            this.BookingStatus = Constants.BookingStatus.Available;
            this.Price = Utility.Utility.GetTicketPrice(this.SeatNumber, totalCapacity);
        }
    }
}
