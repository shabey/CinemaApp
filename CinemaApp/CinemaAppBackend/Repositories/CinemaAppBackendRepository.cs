using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;

namespace CinemaAppBackend.Repositories
{
    public class CinemaAppBackendRepository:ICinemaAppBackendRepository
    {
        private readonly CinemaHall _cinemaHall;
        private readonly IInitializeCinemaHall _initializeCinemaHall;
        public CinemaAppBackendRepository(IInitializeCinemaHall initializeCinemaHall)
        {
            _initializeCinemaHall = initializeCinemaHall;
            _cinemaHall = new CinemaHall();
        }

        public void Initialize(int rows, int noOfSeats)
        {
            _initializeCinemaHall.Initialize(_cinemaHall.CinemaRoom,rows,noOfSeats);
        }
    }
}
