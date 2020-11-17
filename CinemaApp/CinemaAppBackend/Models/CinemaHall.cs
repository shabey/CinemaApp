using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;

namespace CinemaAppBackend.Models
{
    internal class CinemaHall
    {
        public int NoOfRows { get; set; }
        public int NoOfSeatsPerRow { get; set; }
        public int Capacity => this.NoOfRows * this.NoOfSeatsPerRow;
        public List<CinemaSeat> Seats { get; set; }

        public CinemaHall(int noOfRows=0,int noOfSeatsPerRow = 0)
        {
            this.NoOfRows = noOfRows;
            this.NoOfSeatsPerRow = noOfSeatsPerRow;
            Seats = new List<CinemaSeat>(Capacity);
        }
    }
}
