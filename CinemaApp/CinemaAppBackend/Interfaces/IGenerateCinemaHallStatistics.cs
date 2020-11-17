using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Interfaces
{
    internal interface IGenerateCinemaHallStatistics
    {
        CinemaHallStatistics GetCinemaHallStatistics(CinemaHall cinemaHall);

    }
}
