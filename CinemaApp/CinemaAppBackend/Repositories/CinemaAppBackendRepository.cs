using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using CinemaAppBackend.UseCases;

namespace CinemaAppBackend.Repositories
{
    public class CinemaAppBackendRepository:ICinemaAppBackendRepository
    {
        private readonly CinemaHall _cinemaHall;
        private readonly IInitializeCinemaHall _initializeCinemaHall;
        private readonly ICinemaHallBookingStatus _cinemaHallBookingStatus;
        public CinemaAppBackendRepository()
        {
            _initializeCinemaHall = new InitializeCinemaHall();
            _cinemaHallBookingStatus = new CinemaHallBookingStatus();
            _cinemaHall = new CinemaHall();
        }

        public void Initialize(string noOfRows, string noOfSeats)
        {
            _cinemaHall.CinemaRoom = _initializeCinemaHall.Initialize(noOfRows,noOfSeats);
        }

        public void ShowCurrentBookingStatus()
        {
           _cinemaHallBookingStatus.ShowCurrentBookingStatus(_cinemaHall.CinemaRoom);
           Console.WriteLine();
           Console.WriteLine("Press any key to go back !!!");
           Console.ReadLine();
        }
    }
}
