using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Models
{
    public class CinemaHall
    {
        public char[][] CinemaRoom { get; set; }
        public List<CinemaSeat> Seats { get; set; }

        public CinemaHall()
        {
            CinemaRoom = new char[0][];
            Seats = new List<CinemaSeat>();
        }
    }
}
