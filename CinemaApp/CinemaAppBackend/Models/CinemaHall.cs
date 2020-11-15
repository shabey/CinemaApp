using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Models
{
    public class CinemaHall
    {
        public int[][] CinemaRoom { get; set; }
        public List<CinemaSeat> Seats { get; set; }

        public CinemaHall()
        {
            CinemaRoom = new int[0][];
            Seats = new List<CinemaSeat>();
        }
    }
}
