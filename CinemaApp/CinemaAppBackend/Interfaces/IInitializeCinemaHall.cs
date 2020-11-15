using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaAppBackend.Interfaces
{
    public interface IInitializeCinemaHall
    {
        void Initialize(Char[][] cinemaRoom, int noOfRows, int noOfSeats);
    }
}
