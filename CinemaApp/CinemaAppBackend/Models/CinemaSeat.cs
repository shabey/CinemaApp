using CinemaAppBackend.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Models
{
    internal class CinemaSeat
    {
        public int SeatNumber { get; set; }
        public Constants.BookingStatus BookingStatus { get; set; }
        public float TicketPrice { get; set; }

        public CinemaSeat(int rowNo,int seatNo,int noOfSeatsPerRow,int totalCapacity)
        {
            this.SeatNumber = Utility.Utility.ConvertToIndex(rowNo, seatNo, noOfSeatsPerRow);
            this.BookingStatus = Constants.BookingStatus.Available;
            this.TicketPrice =  this.GetTicketPrice(totalCapacity);
        }

        public CinemaSeat(int seatNumber, int totalCapacity,Constants.BookingStatus bookingStatus)
        {
            this.SeatNumber = seatNumber;
            this.BookingStatus = bookingStatus;
            this.TicketPrice = this.GetTicketPrice(totalCapacity);
        }
    }
}
