using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.UseCases
{
    public class InitializeCinemaHall : IInitializeCinemaHall
    {
        public void InitializeCinemaHallSeats(CinemaHall cinemaHall)
        {
            for (var row = 0; row < cinemaHall.NoOfRows; row++)
            {
                for (var col = 0; col < cinemaHall.NoOfSeatsPerRow; col++)
                {
                    cinemaHall.Seats.Add(new CinemaSeat(row,col,cinemaHall.NoOfSeatsPerRow,cinemaHall.Capacity));
                }
            }
        }
    }
}
