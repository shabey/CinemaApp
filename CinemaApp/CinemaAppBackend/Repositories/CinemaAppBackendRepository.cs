using System;
using System.Collections.Generic;
using System.Text;
using CinemaAppBackend.Interfaces;
using CinemaAppBackend.Models;
using CinemaAppBackend.UseCases;

namespace CinemaAppBackend.Repositories
{
    public class CinemaAppBackendRepository : ICinemaAppBackendRepository
    {
        private CinemaHall _cinemaHall;
        private readonly IInitializeCinemaHall _initializeCinemaHall;
        private readonly IShowCinemaHallBookingStatus _showCinemaHallBookingStatus;
        public CinemaAppBackendRepository()
        {
            _initializeCinemaHall = new InitializeCinemaHall();
            _showCinemaHallBookingStatus = new ShowCinemaHallBookingStatus();
            _cinemaHall = new CinemaHall();
        }

        public void InitializeCinemaHall(string noOfRows, string noOfSeatsPerRow)
        {
            try
            {

                if (_initializeCinemaHall.ValidateCinemaHallDimensions(noOfRows, noOfSeatsPerRow))
                {
                    _cinemaHall = new CinemaHall(_initializeCinemaHall, int.Parse(noOfRows),
                        int.Parse(noOfSeatsPerRow));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void ShowCurrentBookingStatus()
        {
            try
            {
                _showCinemaHallBookingStatus.ShowCurrentBookingStatus(_cinemaHall);
                Console.WriteLine();
                Console.WriteLine("Press any key to go back !!!");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
